
//Copyright (c) 2015 Danny Polkinhorn

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.  IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using RS.Utils;

namespace RS.Models
{
    public class WindowsServer
    {
        public List<RevitServer> RevitServers { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public string FullyQualifiedDomainName { get; set; }
        public string AppHostConfigFilenameAndPath { get; set; }
        public string AppHostConfigFilename { get; set; }

        public WindowsServer() {

            Logging.RsiLog("Initializing Windows Server object.");
            RevitServers = GetServers();
            Name = System.Environment.MachineName;
            IPAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
            FullyQualifiedDomainName = GetFQDN();
            AppHostConfigFilename = "ApplicationHost.config";
            AppHostConfigFilenameAndPath = Path.Combine(@"C:\Windows\System32\inetsrv\config\", AppHostConfigFilename);
            Logging.RsiLog("Init complete.  Server name is " + Name + ".");

        }

        public string CollectFiles(CollectionOptions cOptions)
        {
            Logging.RsiLog("WindowsServer.CollectFiles");
            
            try
            {
                //Set up the log folder and make sure it exists
                string logFileCollectionPath = Path.GetTempPath() + "Revit_Server_Diagnostics_" + Name;
                Logging.RsiLog("logFileCollectionPath: " + logFileCollectionPath);
                string zipFilePath = cOptions.ZipFolderPath + "\\Revit_Server_Diagnostics_" + Name + ".zip";
                Logging.RsiLog("zipFilePath: " + zipFilePath);
                
                if (cOptions.AnyOption())
                {
                    if (Directory.Exists(logFileCollectionPath))
                    {
                        Directory.Delete(logFileCollectionPath, true);
                    }
                    Directory.CreateDirectory(logFileCollectionPath);
                    Logging.RsiLog("Creating: " + logFileCollectionPath);
                }
                
                // collect the files
                try
                {
                    if (cOptions.ServerInfo) 
                    {
                        Logging.RsiLog("Collecting RS info...");
                        CollectServerInfo(logFileCollectionPath);
                    }
                    if (cOptions.RSLogs) 
                    {
                        Logging.RsiLog("Collecting RS Server logs...");
                        CollectLogs(logFileCollectionPath, cOptions.Version); 
                    }
                    if (cOptions.RsnIni) 
                    {
                        Logging.RsiLog("Collecting RSN.ini files...");
                        CollectRsnIni(logFileCollectionPath, cOptions.Version); 
                    }
                    if (cOptions.EventLogs) 
                    {
                        Logging.RsiLog("Collecting Windows event logs...");
                        CollectEventLogs(logFileCollectionPath); 
                    }
                    if (cOptions.MsInfo)
                    {
                        Logging.RsiLog("Collecting Windows System Information...");
                        CollectMsInfo(logFileCollectionPath);
                    }
                    if (cOptions.WebConfig)
                    {
                        Logging.RsiLog("Collecting ApplicationHost.config and web.config files...");
                        CollectAppHostConfig(logFileCollectionPath);
                        CollectWebConfig(logFileCollectionPath, cOptions.Version);
                    }
                }
                catch (Exception ex)
                {
                    Logging.RsiLog(ex.Message + "\r\n" + ex.StackTrace);
                    throw new Exception("Unable to collect some information.  Check the " + logFileCollectionPath + " folder for unzipped files and delete them.", ex);
                }


                if (cOptions.AnyOption())
                {
                    // Zip the files together

                    Console.WriteLine("Zip File Location: " + zipFilePath);
                    try
                    {
                        Logging.RsiLog("Zipping files to " + zipFilePath);
                        if (File.Exists(zipFilePath))
                        {
                            Logging.RsiLog("Deleting previous zip file: " + zipFilePath);
                            File.Delete(zipFilePath);
                        }
                        ZipFile.CreateFromDirectory(logFileCollectionPath, zipFilePath);
                        Logging.RsiLog("Files zipped.");
                    }
                    catch (Exception ex)
                    {
                        Logging.RsiLog(ex.Message);
                        throw new Exception("Unable to zip the files.  Check the " + logFileCollectionPath + " folder for unzipped files.", ex);
                    }
                    

                    // Delete the temp folder
                    try
                    {
                        Logging.RsiLog("Deleting unzipped files.");
                        Directory.Delete(logFileCollectionPath, true);
                    }
                    catch (Exception ex)
                    {
                        Logging.RsiLog(ex.Message);
                        throw new Exception("Unable to delete the files after zipping them.  Check the " + logFileCollectionPath + " folder for unzipped files and delete them.", ex);
                    }

                }

                return zipFilePath;
            }
            catch (Exception ex)
            {
                Logging.RsiLog(ex.Message);
                throw new Exception("Unable to complete the collection of all information.  Check the inner exception message for more information.", ex);
            }
            
        }

        void CollectServerInfo(string logFileCollectionPath = "")
        {
            // The Basics
            string serverInfo = "Name: " + Name + "\r\n" +
                                "IPAddress: " + IPAddress + "\r\n" +
                                "Fully Qualified Domain Name: " + FullyQualifiedDomainName + "\r\n\r\n";

            // Performance numbers
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", Name);
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes", String.Empty, Name);
            serverInfo += String.Format("Processor Usage: {0:##0} %\r\n", cpuCounter.NextValue());
            serverInfo += String.Format("Available RAM: {0} MB\r\n", ramCounter.NextValue());
            cpuCounter.Dispose();
            ramCounter.Dispose();

            // Revit Servers
            foreach (string version in RevitServer.Versions())
	        {
                serverInfo += "______________________________________________________________________________\r\n" +
                    "Revit Server " + version + "\r\n";
                bool versionExists = false;
                foreach (RevitServer rs in RevitServers)
                {
                    if (rs.Version == version) { versionExists = true; break; }
                }
                if (!versionExists)
                {
                    serverInfo += "Not Configured.\r\n" ;
                }
                else
                {
                    foreach (RevitServer rs in RevitServers)
                    {
                        if (rs.Version == version)
                        {
                            // Revit Server roles for this version
                            serverInfo += "Roles: " + rs.RolesAsString() + "\r\n";

                            // Location of project data
                            serverInfo += "Project Data Location: " + rs.ProjectDataPath + "\r\n";
                            
                            // Contents of RSN.ini
                            if (rs.Hosts.Count > 0)
                            {
                                serverInfo += "Hosts in RSN.ini:\r\n";
                                int counter = 1;
                                foreach (string host in rs.Hosts)
                                {
                                    serverInfo += "  " + counter.ToString() +".  " + host +  " - latency from this machine: " + GetPingTimeString(host) + "\r\n";
                                    counter += 1;
                                }
                            } else {
                                serverInfo += "Hosts are not properly configured, or RSN.ini is missing.";
                            }
                            
                            break;
                        }
                    }
                }
	        }
            serverInfo += GetRunningProcesses();
            serverInfo += "______________________________________________________________________________\r\n";
            
            // Write the data
            Logging.RsiLog(serverInfo);
            System.IO.File.WriteAllText(logFileCollectionPath + "\\_ServerInfo.txt", @serverInfo);
        }

        void CollectRsnIni(string logFileCollectionPath = "", string version = "")
        {
                       
            foreach (RevitServer rs in RevitServers)
            {
                if (version == string.Empty || version == rs.Version)
                {
                    if (File.Exists(rs.RsnIniFilenameAndPath)) {

                        string rsnDest = Path.Combine(logFileCollectionPath, rs.Version);
                        
                        if (!Directory.Exists(rsnDest))
                        {
                            Directory.CreateDirectory(rsnDest);
                        }
                        string destName = Path.Combine(rsnDest, rs.RsnIniFilename);
                        Logging.RsiLog("Copying '" + rs.RsnIniFilenameAndPath + "' to '" + destName + "'.");
                        File.Copy(rs.RsnIniFilenameAndPath, destName);
                    }
                }
            }
        }

        void CollectAppHostConfig(string logFileCollectionPath = "")
        {
            string fileDest = Path.Combine(logFileCollectionPath, AppHostConfigFilename);
            if (File.Exists(AppHostConfigFilenameAndPath)) { File.Copy(AppHostConfigFilenameAndPath, fileDest); }
        }

        void CollectWebConfig(string logFileCollectionPath = "", string version = "")
        {

            foreach (RevitServer rs in RevitServers)
            {
                if (version == string.Empty || version == rs.Version)
                {
                    if (File.Exists(rs.WebConfigFilenameAndPath))
                    {
                        string folderDest = Path.Combine(logFileCollectionPath,rs.Version);
                        string destFile = Path.Combine(folderDest, rs.WebConfigFilename);
                        //File.Copy(rs.AppHostFilePath, logDest);
                        Logging.RsiLog("Copying '" + rs.WebConfigFilenameAndPath + "' to '" + destFile + "'.");
                        File.Copy(rs.WebConfigFilenameAndPath, destFile);
                    }
                }
            }
        }

        void CollectLogs(string logFileCollectionPath = "", string version = "")
        {

            foreach (RevitServer rs in RevitServers)
            {
                if (version == string.Empty || version == rs.Version)
                
                {
                    Console.WriteLine("Collecting Logs for Revit Server " + rs.Version);
                    string logDest = Path.Combine(logFileCollectionPath, rs.Version);
                    if (!Directory.Exists(logDest))
                    {
                        Directory.CreateDirectory(logDest);
                    }
                    Console.WriteLine("Log Files Location: " + rs.LogFilePath);
                    string destName = string.Empty;
                    string fileName = string.Empty;
                    try
                    {
                        string[] fileList = Directory.GetFiles(rs.LogFilePath, "*.*");

                        // Copy all files.
                        foreach (string f in fileList)
                        {
                            // Remove path from the file name.
                            string fName = Path.GetFileName(f);
                            fileName = Path.Combine(rs.LogFilePath, fName);
                            destName = Path.Combine(logDest, fName);

                            // Use the Path.Combine method to safely append the file name to the path.
                            // Will overwrite if the destination file already exists.
                            Console.WriteLine("  Copying '" + fileName + "' to '" + destName);
                            File.Copy(fileName, destName, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error copying '" + fileName + "' to '" + destName + "'.\r\n" + ex.StackTrace, ex);
                    }
                    
                }
            }
            
        }

        void CollectEventLogs(string logFileCollectionPath = "")
        {
            var els = new EventLogSession();

            // this query gets the last 7 days of events
            string q = "<QueryList>" +
                            "<Query Id=\"0\" Path=\"Application\">" +
                                "<Select Path=\"Application\">*[System[TimeCreated[timediff(@SystemTime) &lt;= 604800000]]]</Select>" +
                            "</Query>" +
                        "</QueryList>";
            els.ExportLogAndMessages("Application", PathType.LogName, q, Path.Combine(logFileCollectionPath + "\\Application.evtx"), false, CultureInfo.CurrentCulture);

            // this query gets the last 7 days of events
            q = "<QueryList>" +
                            "<Query Id=\"0\" Path=\"System\">" +
                                "<Select Path=\"System\">*[System[TimeCreated[timediff(@SystemTime) &lt;= 604800000]]]</Select>" +
                            "</Query>" +
                        "</QueryList>";
            els.ExportLogAndMessages("System", PathType.LogName, q, Path.Combine(logFileCollectionPath + "\\System.evtx"), false, CultureInfo.CurrentCulture);
        }

        private void CollectMsInfo(string logFileCollectionPath = "")
        {
            Process proc = new Process();
            proc.EnableRaisingEvents = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.FileName = "msinfo32.exe";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.Arguments = "/nfo " + logFileCollectionPath + "\\msinfo.nfo";
            proc.StartInfo.WorkingDirectory = logFileCollectionPath;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();
            proc.Close();
        }

        List<RevitServer> GetServers()
        {

            List<RevitServer> servers = new List<RevitServer>();

            foreach (var version in RevitServer.Versions())
            {
                string rsrole = System.Environment.GetEnvironmentVariable("RSROLE" + version);
                if (rsrole != null)
                {
                    RevitServer rs = new RevitServer(version, rsrole);
                    servers.Add(rs);
                }
            }
            return servers;
        }

        static string GetFQDN()
        {
            string domainName = IPGlobalProperties.GetIPGlobalProperties().DomainName;
            string hostName = Dns.GetHostName();

            if (!hostName.EndsWith(domainName))  // if hostname does not already include domain name
            {
                hostName += "." + domainName;   // add the domain name part
            }

            return hostName;                    // return the fully qualified name
        }

        static string GetRunningProcesses()
        {
            string processes = "______________________________________________________________________________\r\n";
            processes += "Currently running processes:\r\n";
            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                processes += "  " + theprocess.ProcessName + ", PeakMemoryUsage: " + theprocess.PeakWorkingSet64 + "\r\n";
            }
            return processes;
        }

        static string GetPingTimeString(string nameOrIpAddress)
        {
            string s = string.Empty;
            long pt = PingTime(nameOrIpAddress);
            if (pt == 500)
            {
                return "> 500 ms or not responding.";
            } else {
                return pt.ToString() + " ms.";
            }
        }

        static long PingTime(string nameOrIpAddress)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 500;
            long roundtripTime = 500;
            PingReply reply = pingSender.Send(nameOrIpAddress, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                //Console.WriteLine("Address: {0}", reply.Address.ToString());
                //Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                roundtripTime = reply.RoundtripTime;
                //Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                //Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                //Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
            }
            return roundtripTime;
        }



    }
}
