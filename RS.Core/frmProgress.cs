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
    public partial class frmProgress : Form
    {

        public frmProgress()
        {
            InitializeComponent();
        }

        public string Message
        {
            set { lblStatus.Text = value; }
        }

        public int ProgressValue
        {
            set { pBar.Value = value; }
        }

        public event EventHandler<EventArgs> Canceled;

        public void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandler<EventArgs> ea = Canceled;
            if (ea != null) { ea(this, e); }
        }
    }
}
