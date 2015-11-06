namespace RS.Core
{
    partial class frmOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.chkServerInfo = new System.Windows.Forms.CheckBox();
            this.chkLogFiles = new System.Windows.Forms.CheckBox();
            this.chkEventLogs = new System.Windows.Forms.CheckBox();
            this.chkRsnIni = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.opt2016 = new System.Windows.Forms.RadioButton();
            this.opt2015 = new System.Windows.Forms.RadioButton();
            this.opt2014 = new System.Windows.Forms.RadioButton();
            this.opt2013 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZipPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.ctnCancel = new System.Windows.Forms.Button();
            this.fbdZipPath = new System.Windows.Forms.FolderBrowserDialog();
            this.chkAllVersions = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkMsInfo = new System.Windows.Forms.CheckBox();
            this.chkAppHostConfig = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkServerInfo
            // 
            this.chkServerInfo.AutoSize = true;
            this.chkServerInfo.Checked = true;
            this.chkServerInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkServerInfo.Location = new System.Drawing.Point(33, 27);
            this.chkServerInfo.Name = "chkServerInfo";
            this.chkServerInfo.Size = new System.Drawing.Size(178, 17);
            this.chkServerInfo.TabIndex = 0;
            this.chkServerInfo.Text = "Basic Revit Server information";
            this.chkServerInfo.UseVisualStyleBackColor = true;
            this.chkServerInfo.CheckedChanged += new System.EventHandler(this.chkServerInfo_CheckedChanged);
            // 
            // chkLogFiles
            // 
            this.chkLogFiles.AutoSize = true;
            this.chkLogFiles.Checked = true;
            this.chkLogFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLogFiles.Location = new System.Drawing.Point(33, 50);
            this.chkLogFiles.Name = "chkLogFiles";
            this.chkLogFiles.Size = new System.Drawing.Size(129, 17);
            this.chkLogFiles.TabIndex = 1;
            this.chkLogFiles.Text = "Revit Server log files";
            this.chkLogFiles.UseVisualStyleBackColor = true;
            this.chkLogFiles.CheckedChanged += new System.EventHandler(this.chkLogFiles_CheckedChanged);
            // 
            // chkEventLogs
            // 
            this.chkEventLogs.AutoSize = true;
            this.chkEventLogs.Checked = true;
            this.chkEventLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEventLogs.Location = new System.Drawing.Point(33, 169);
            this.chkEventLogs.Name = "chkEventLogs";
            this.chkEventLogs.Size = new System.Drawing.Size(254, 17);
            this.chkEventLogs.TabIndex = 2;
            this.chkEventLogs.Text = "Windows System and Application event logs";
            this.chkEventLogs.UseVisualStyleBackColor = true;
            this.chkEventLogs.CheckedChanged += new System.EventHandler(this.chkEventLogs_CheckedChanged);
            // 
            // chkRsnIni
            // 
            this.chkRsnIni.AutoSize = true;
            this.chkRsnIni.Checked = true;
            this.chkRsnIni.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRsnIni.Location = new System.Drawing.Point(33, 73);
            this.chkRsnIni.Name = "chkRsnIni";
            this.chkRsnIni.Size = new System.Drawing.Size(87, 17);
            this.chkRsnIni.TabIndex = 3;
            this.chkRsnIni.Text = "RSN.ini files";
            this.chkRsnIni.UseVisualStyleBackColor = true;
            this.chkRsnIni.CheckedChanged += new System.EventHandler(this.chkRsnIni_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.opt2016);
            this.groupBox1.Controls.Add(this.opt2015);
            this.groupBox1.Controls.Add(this.opt2014);
            this.groupBox1.Controls.Add(this.opt2013);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(36, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 114);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Version";
            // 
            // opt2016
            // 
            this.opt2016.AutoSize = true;
            this.opt2016.Checked = true;
            this.opt2016.Location = new System.Drawing.Point(6, 90);
            this.opt2016.Name = "opt2016";
            this.opt2016.Size = new System.Drawing.Size(49, 17);
            this.opt2016.TabIndex = 3;
            this.opt2016.TabStop = true;
            this.opt2016.Text = "2016";
            this.opt2016.UseVisualStyleBackColor = true;
            this.opt2016.CheckedChanged += new System.EventHandler(this.opt2016_CheckedChanged);
            // 
            // opt2015
            // 
            this.opt2015.AutoSize = true;
            this.opt2015.Location = new System.Drawing.Point(6, 67);
            this.opt2015.Name = "opt2015";
            this.opt2015.Size = new System.Drawing.Size(49, 17);
            this.opt2015.TabIndex = 2;
            this.opt2015.Text = "2015";
            this.opt2015.UseVisualStyleBackColor = true;
            this.opt2015.CheckedChanged += new System.EventHandler(this.opt2015_CheckedChanged);
            // 
            // opt2014
            // 
            this.opt2014.AutoSize = true;
            this.opt2014.Location = new System.Drawing.Point(6, 44);
            this.opt2014.Name = "opt2014";
            this.opt2014.Size = new System.Drawing.Size(49, 17);
            this.opt2014.TabIndex = 1;
            this.opt2014.Text = "2014";
            this.opt2014.UseVisualStyleBackColor = true;
            this.opt2014.CheckedChanged += new System.EventHandler(this.opt2014_CheckedChanged);
            // 
            // opt2013
            // 
            this.opt2013.AutoSize = true;
            this.opt2013.Location = new System.Drawing.Point(6, 21);
            this.opt2013.Name = "opt2013";
            this.opt2013.Size = new System.Drawing.Size(49, 17);
            this.opt2013.TabIndex = 0;
            this.opt2013.Text = "2013";
            this.opt2013.UseVisualStyleBackColor = true;
            this.opt2013.CheckedChanged += new System.EventHandler(this.opt2013_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Path to zipped files:";
            // 
            // txtZipPath
            // 
            this.txtZipPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZipPath.Enabled = false;
            this.txtZipPath.Location = new System.Drawing.Point(127, 347);
            this.txtZipPath.Name = "txtZipPath";
            this.txtZipPath.Size = new System.Drawing.Size(313, 22);
            this.txtZipPath.TabIndex = 6;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(442, 346);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(29, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(296, 375);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // ctnCancel
            // 
            this.ctnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ctnCancel.Location = new System.Drawing.Point(392, 375);
            this.ctnCancel.Name = "ctnCancel";
            this.ctnCancel.Size = new System.Drawing.Size(90, 25);
            this.ctnCancel.TabIndex = 9;
            this.ctnCancel.Text = "Cancel";
            this.ctnCancel.UseVisualStyleBackColor = true;
            // 
            // fbdZipPath
            // 
            this.fbdZipPath.ShowNewFolderButton = false;
            // 
            // chkAllVersions
            // 
            this.chkAllVersions.AutoSize = true;
            this.chkAllVersions.Checked = true;
            this.chkAllVersions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllVersions.Location = new System.Drawing.Point(15, 201);
            this.chkAllVersions.Name = "chkAllVersions";
            this.chkAllVersions.Size = new System.Drawing.Size(298, 17);
            this.chkAllVersions.TabIndex = 10;
            this.chkAllVersions.Text = "Get information for all Revit Server versions installed.";
            this.chkAllVersions.UseVisualStyleBackColor = true;
            this.chkAllVersions.CheckedChanged += new System.EventHandler(this.chkAllVersions_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Collect the following about Revit Server:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Collect the following about Windows Server:";
            // 
            // chkMsInfo
            // 
            this.chkMsInfo.AutoSize = true;
            this.chkMsInfo.Checked = true;
            this.chkMsInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMsInfo.Location = new System.Drawing.Point(33, 146);
            this.chkMsInfo.Name = "chkMsInfo";
            this.chkMsInfo.Size = new System.Drawing.Size(169, 17);
            this.chkMsInfo.TabIndex = 13;
            this.chkMsInfo.Text = "System Information (msinfo)";
            this.chkMsInfo.UseVisualStyleBackColor = true;
            this.chkMsInfo.CheckedChanged += new System.EventHandler(this.chkMsInfo_CheckedChanged);
            // 
            // chkAppHostConfig
            // 
            this.chkAppHostConfig.AutoSize = true;
            this.chkAppHostConfig.Checked = true;
            this.chkAppHostConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAppHostConfig.Location = new System.Drawing.Point(33, 96);
            this.chkAppHostConfig.Name = "chkAppHostConfig";
            this.chkAppHostConfig.Size = new System.Drawing.Size(266, 17);
            this.chkAppHostConfig.TabIndex = 14;
            this.chkAppHostConfig.Text = "Application Host and ModelService config files";
            this.chkAppHostConfig.UseVisualStyleBackColor = true;
            this.chkAppHostConfig.CheckedChanged += new System.EventHandler(this.chkAppHostConfig_CheckedChanged);
            // 
            // frmOptions
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 412);
            this.Controls.Add(this.chkAppHostConfig);
            this.Controls.Add(this.chkMsInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkAllVersions);
            this.Controls.Add(this.ctnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtZipPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkRsnIni);
            this.Controls.Add(this.chkEventLogs);
            this.Controls.Add(this.chkLogFiles);
            this.Controls.Add(this.chkServerInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(510, 450);
            this.MinimumSize = new System.Drawing.Size(510, 450);
            this.Name = "frmOptions";
            this.Text = "Revit Server Diagnostics Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkServerInfo;
        private System.Windows.Forms.CheckBox chkLogFiles;
        private System.Windows.Forms.CheckBox chkEventLogs;
        private System.Windows.Forms.CheckBox chkRsnIni;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtZipPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button ctnCancel;
        private System.Windows.Forms.FolderBrowserDialog fbdZipPath;
        private System.Windows.Forms.CheckBox chkAllVersions;
        private System.Windows.Forms.RadioButton opt2016;
        private System.Windows.Forms.RadioButton opt2015;
        private System.Windows.Forms.RadioButton opt2014;
        private System.Windows.Forms.RadioButton opt2013;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkMsInfo;
        private System.Windows.Forms.CheckBox chkAppHostConfig;
    }
}