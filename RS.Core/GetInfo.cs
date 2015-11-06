
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
using RS.Utils;
using RS.Models;
using System.ComponentModel;
using System.Threading.Tasks;


namespace RS.Core
{
    public class GetInfo
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                // options for information to collect
                CollectionOptions cOptions = new CollectionOptions();
                // if the user doesn't provide options, then don't run collection
                bool startCollection = false;


                //start logging;
                Logging.RsiLog("Starting log...");
                Logging.RsiLog("Number of Command Line Arguments: " + args.Length);
                int count = 0;
                foreach (string arg in args)
                {
                    count++;
                    Logging.RsiLog("Argument " + count + ": " + arg);
                }

                //set some defaults, get everything if no arguments are provided.
                if (args.Length != 0)
                {
                    cOptions.SetAllOptions(false);
                    startCollection = true;
                    foreach (string arg in args)
                    {
                        if (arg.ToUpper().Contains("/S"))
                        {
                            cOptions.ServerInfo = true;
                        }
                        if (arg.ToUpper().Contains("/R"))
                        {
                            cOptions.RsnIni = true;
                        }
                        if (arg.ToUpper().Contains("/L"))
                        {
                            cOptions.RSLogs = true;
                        }
                        if (arg.ToUpper().Contains("/E"))
                        {
                            cOptions.EventLogs = true;
                        }
                        if (arg.ToUpper().Contains("/P"))
                        {
                            cOptions.ZipFolderPath = arg.Substring(3);
                        }
                        if (arg.ToUpper().Contains("/V"))
                        {
                            cOptions.Version = arg.Substring(3);
                        }
                        if (arg.ToUpper().Contains("/W"))
                        {
                            cOptions.WebConfig = true;
                        }
                        if (arg.ToUpper().Contains("/M"))
                        {
                            cOptions.MsInfo = true;
                        }
                        if (arg.ToUpper().Contains("/?"))
                        {
                            frmHelp h = new frmHelp();
                            h.ShowDialog();
                            //global::System.Windows.Forms.MessageBox.Show("Command Line Parameters:\r\n" + 
                            //    "/S  :  Gets basic server configuration information and writes that to a text file.\r\n" +
                            //    "/R  :  Collects RSN.ini files.\r\n" +
                            //    "/L  :  Collects all Revit Server Log files.\r\n" +
                            //    "/E  :  Collects the Windows System and Application Event Logs.\r\n" +
                            //    "/W  :  Collects the web.config file and IIS Application Host Configuration file.\r\n" +
                            //    "/M  :  Collects information from msinfo.exe in a .nfo file.\r\n" +
                            //    "/P  :  Path to place the contents of the zip file containing the collected files.\r\n" +
                            //    "       The zip file will be placed on your Desktop if this is not specified.\r\n" +
                            //    @"       Usage: 'RevitServerInfo.exe /P:C:\Temp'  Enclose paths with spaces in double-quotes.\r\n" +
                            //    "/V  :  The Revit Server version you want information for.  All versions will be collected by default.\r\n" + 
                            //    "       Usage: 'RevitServerInfo.exe /V:2016'");
                            startCollection = false;
                        }
                    }
                }
                else //no arguments provided, show a dialog...
                {
                    frmOptions options = new frmOptions();
                    if (options.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                        cOptions = options.GetOptions();
                        startCollection = true;
                    }
                }

                if (startCollection)
                {
                    Logging.RsiLog(cOptions.ToString());

                    //BackgroundWorker bw = new BackgroundWorker();
                    //bw.WorkerReportsProgress = true;
                    //bw.WorkerSupportsCancellation = true;

                    //frmProgress pr = new frmProgress();
                    //pr.Canceled += new EventHandler<EventArgs>(pr.btnCancel_Click);

                    RS.Models.WindowsServer ws = new RS.Models.WindowsServer();
                    ws.CollectFiles(cOptions);
                    Logging.RsiLog("Finishing log.\r\n\r\n");
                }
                else
                {
                    Logging.RsiLog("No options provided via command line or options dialog.  Exiting.\r\n\r\n");
                }
                
            }
            catch (Exception ex)
            {
                Logging.RsiLog(ex.Message + "\r\n" + ex.StackTrace + "\r\n\r\n");
            }


        }

        //async Task<int> CollectFilesAsync(CollectionOptions cOptions, IProgress<int> progress)
        //{
        //    int processCount = await Task.Run<int>(() =>
        //        {
        //            int TempCount = 0;
                    
        //    {
			 
        //    }
        //        })
        //}

    }

}
