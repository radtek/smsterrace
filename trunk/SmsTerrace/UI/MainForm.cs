using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmsTerrace.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
           
           
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            SendSmsFrm sendSmsFrm = new SendSmsFrm();
            sendSmsFrm.ShowDialog();
        }
    }
}
