using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS.Core
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
            lblHelpText.Text = "Command Line Parameters:\r\n" + 
                                "/S  :  Gets basic server configuration information and writes that to a text file.\r\n" +
                                "/R  :  Collects RSN.ini files.\r\n" +
                                "/L  :  Collects all Revit Server Log files.\r\n" +
                                "/E  :  Collects the Windows System and Application Event Logs.\r\n" +
                                "/W  :  Collects the web.config file and IIS Application Host Configuration file.\r\n" +
                                "/M  :  Collects information from msinfo.exe in a .nfo file.\r\n" +
                                "/P  :  Path to place the contents of the zip file containing the collected files.\r\n" +
                                "       The zip file will be placed on your Desktop if this is not specified.\r\n" +
                                "       Usage: 'RevitServerInfo.exe /P:C:\\Temp'  Enclose paths with spaces in double-quotes.\r\n" +
                                "/V  :  The Revit Server version you want information for.\r\n" + 
                                "       All versions will be collected by default if no value is provided.\r\n" + 
                                "       Usage: 'RevitServerInfo.exe /V:2016'";
            btnOk.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
