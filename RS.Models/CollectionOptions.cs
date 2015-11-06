using System;
using System.Collections.Generic;
using System.Linq;

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

using System.Text;
using System.Threading.Tasks;

namespace RS.Models
{
    public class CollectionOptions
    {
        public string Version { get; set; }
        public string ZipFolderPath { get; set; }
        public bool ServerInfo { get; set; }
        public bool RSLogs { get; set; }
        public bool RsnIni { get; set; }
        public bool EventLogs { get; set; }
        public bool WebConfig { get; set; }
        public bool MsInfo { get; set; }

        public CollectionOptions()
        {
            // By default, collect everything
            Version = string.Empty;
            ZipFolderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ServerInfo = true;
            RSLogs = true;
            RsnIni = true;
            EventLogs = true;
            WebConfig = true;
            MsInfo = true;
        }

        public void SetAllOptions(bool value)
        {
            ServerInfo = value;
            RSLogs = value;
            RsnIni = value;
            EventLogs = value;
            WebConfig = value;
            MsInfo = value;
        }

        public bool AnyOption()
        {
            return (ServerInfo || RSLogs || RsnIni || EventLogs || WebConfig || MsInfo);
        }

        public override string ToString()
        {
            string asString = "Options as configured: \r\n";
            if (Version == string.Empty)
            {
                asString += "  Version:       All Versions\r\n";
            }
            else
            {
                asString += "  Version:       " + Version + "\r\n";
            }
            asString += "  ZipFolderPath:   " + ZipFolderPath + "\r\n" +
                        "  ServerInfo:    " + ServerInfo.ToString() + "\r\n" +
                        "  RSLogs:        " + RSLogs.ToString() + "\r\n" +
                        "  RsnIni:        " + RsnIni.ToString() + "\r\n" +
                        "  EventLogs:     " + EventLogs.ToString() + "\r\n" +
                        "  MsInfo:        " + MsInfo.ToString() + "\r\n" +
                        "  WebConfig:     " + WebConfig.ToString() + "\r\n";
            return asString;
        }

    }
}
