using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMIFilterTester
{
    public partial class frmQueryEntry : Form
    {
        public frmQueryEntry()
        {
            InitializeComponent();
        }

        public frmQueryEntry(String initText)
        {
            InitializeComponent();
            txtQuery.Text = initText;
        }

        private TimeSpan timeSpan = frmMain.timeSpan;

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            if (txtQuery.Text != "")
            {
                bool retVal = frmMain.runValidation("root\\CIMv2;"+txtQuery.Text);
                MessageBox.Show("WMI Filter evaluates to " + retVal.ToString().ToUpper() + " on the local computer \n and completed in: " + timeSpan.Hours + ":" + timeSpan.Minutes + ":" + timeSpan.Seconds + ":" + timeSpan.Milliseconds + " (hh:mm:ss:ms)", "WMI Validation Results");

            }
            else
            {
                MessageBox.Show("Enter a query!", "WMI Validation Results");
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
