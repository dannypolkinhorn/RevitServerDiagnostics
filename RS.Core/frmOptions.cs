using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RS.Models;

namespace RS.Core
{
    public partial class frmOptions : Form
    {

        CollectionOptions cOptions;

        public frmOptions()
        {
            InitializeComponent();

            cOptions = new CollectionOptions();
            txtZipPath.Text = cOptions.ZipFolderPath;

        }

        public CollectionOptions GetOptions()
        {
            return cOptions;
        }
        

        // Zip file path
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (fbdZipPath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtZipPath.Text = fbdZipPath.SelectedPath;
                cOptions.ZipFolderPath = fbdZipPath.SelectedPath;
            }
        }


        //Check boxes
        private void chkServerInfo_CheckedChanged(object sender, EventArgs e)
        {
            cOptions.ServerInfo = chkServerInfo.Checked;
        }
        private void chkLogFiles_CheckedChanged(object sender, EventArgs e)
        {
            cOptions.RSLogs = chkLogFiles.Checked;
        }
        private void chkEventLogs_CheckedChanged(object sender, EventArgs e)
        {
            cOptions.EventLogs = chkEventLogs.Checked;
        }
        private void chkRsnIni_CheckedChanged(object sender, EventArgs e)
        {
            cOptions.RsnIni = chkRsnIni.Checked;
        }
        private void chkAppHostConfig_CheckedChanged(object sender, EventArgs e)
        {
            cOptions.WebConfig = chkAppHostConfig.Checked;
        }
        private void chkMsInfo_CheckedChanged(object sender, EventArgs e)
        {
            cOptions.MsInfo = chkMsInfo.Checked;
        }


        // Versions
        private void chkAllVersions_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = !chkAllVersions.Checked;

            if (chkAllVersions.Checked) { cOptions.Version = string.Empty; }
        }
        private void opt2016_CheckedChanged(object sender, EventArgs e)
        {
            if (opt2016.Checked && !chkAllVersions.Checked)
            {
                cOptions.Version = "2016";
            }
        }
        private void opt2015_CheckedChanged(object sender, EventArgs e)
        {
            if (opt2015.Checked && !chkAllVersions.Checked)
            {
                cOptions.Version = "2015";
            }
        }
        private void opt2014_CheckedChanged(object sender, EventArgs e)
        {
            if (opt2014.Checked && !chkAllVersions.Checked)
            {
                cOptions.Version = "2014";
            }
        }
        private void opt2013_CheckedChanged(object sender, EventArgs e)
        {
            if (opt2013.Checked && !chkAllVersions.Checked)
            {
                cOptions.Version = "2013";
            }
        }









    }
}
