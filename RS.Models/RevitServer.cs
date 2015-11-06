
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using RS.Utils;

namespace RS.Models
{
    public class RevitServer
    {
        public enum Role
        {   
            Host = 0,
            Accelerator = 1,
            Admin = 2
        }

        public List<Role> Roles { get; set; }
        public string LogFilePath { get; set; }
        public string RsnIniFilenameAndPath { get; set; }
        public string RsnIniFilename { get; set; }
        public string Version { get; set; }
        public string ProjectDataPath { get; set; }
        public string WebConfigPath { get; set; }
        public string WebConfigFilename { get; set; }
        public string WebConfigFilenameAndPath { get; set; }
        public List<string> Hosts { get; set; }
       
        public static string[] Versions()
        {
            string[] versions = { "2013", "2014", "2015", "2016" };
            return versions;
        }

        public RevitServer(string version, string roles = "")
        {
            Logging.RsiLog("Initializing RevitSever instance.  version: " + version + ", roles: " + roles);
            Version = version;
            Roles = new List<Role>();
            if (roles != string.Empty)
            {
                if (roles.Contains("Host"))
                {
                    Roles.Add(RevitServer.Role.Host);
                    //This is a Host server
                }
                if (roles.Contains("Accelerator"))
                {
                    Roles.Add(RevitServer.Role.Accelerator);
                    //This is an Acceleratorr
                }
                if (roles.Contains("Admin"))
                {
                    Roles.Add(RevitServer.Role.Admin);
                    //This is an Admin server
                }
            }

            LogFilePath = "C:\\ProgramData\\Autodesk\\Revit Server " + version + "\\Logs\\";
            RsnIniFilename = "RSN.ini";
            RsnIniFilenameAndPath = Path.Combine("C:\\ProgramData\\Autodesk\\Revit Server " + version + "\\Config\\",RsnIniFilename);
            WebConfigPath = "C:\\Program Files\\Autodesk\\Revit Server " + version + "\\Services\\ModelService\\";
            WebConfigFilename = "web.config";
            WebConfigFilenameAndPath = Path.Combine(WebConfigPath, WebConfigFilename);
            ProjectDataPath = GetProjectDataPath(version);
            Hosts = GetHosts();
        }

        public string RolesAsString()
        {
            string roles = string.Empty;
            foreach (RevitServer.Role role in Roles)
            {
                roles += role.ToString() + ", ";
            }
            if (roles.Length > 0) { roles = roles.Substring(0, roles.Length - 2); }
            return roles;
        }

        List<string> GetHosts()
        {
            int counter = 0;
            string line;
            List<string> lines = new List<string>();

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(RsnIniFilenameAndPath);
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
                counter++;
            }

            file.Close();
            return lines;
        }

        static string GetProjectDataPath(string version)
        {
            try
            {
                
                //string filename = "C:\\Program Files\\Autodesk\\Revit Server " + version + "\\Tools\\RevitServerCommand\\Config\\DataStorageService.config";
                string filename = @"C:\Program Files\Autodesk\Revit Server " + version + @"\Tools\RevitServerCommand\Config\DataStorageService.config";
                Logging.RsiLog("Getting project data path from: " + filename);
                XmlSerializer serializer = new XmlSerializer(typeof(DataStorageServiceConfiguration));
                if (System.IO.File.Exists(filename))
                {
                    // A FileStream is needed to read the XML document.
                    FileStream fs = new FileStream(filename, FileMode.Open);
                    XmlReader reader = XmlReader.Create(fs);

                    // Declare an object variable of the type to be deserialized.
                    DataStorageServiceConfiguration i;

                    // Use the Deserialize method to restore the object's state.
                    i = (DataStorageServiceConfiguration)serializer.Deserialize(reader);
                    fs.Close();
                    Logging.RsiLog("Storage Path: " + i.DefaultStoragePath);
                    return i.DefaultStoragePath;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                Logging.RsiLog(ex.Message + "\r\n" + ex.StackTrace);
                return string.Empty;
            }

        }

        [XmlRoot("DataStorageServiceConfiguration")]
        public class DataStorageServiceConfiguration
        {
            [XmlAttribute]
            public int MinChunkSizeInKB { get; set; }
            [XmlAttribute]
            public int MaxThreadsForChunking { get; set; }
            [XmlAttribute]
            public string DefaultStoragePath { get; set; }
        }
    }
}
