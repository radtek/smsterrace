using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmsTerrace.UI
{
    public partial class TxtShowFrm : Form
    {
        public TxtShowFrm()
        {
            InitializeComponent();
        }
        public void Show(string msg,string txt)
        {
            this.Show();
        }
        
        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void ShowDialog(string msg, string txt)
        {
            this.Text = txt;
            this.MsgtextBox.Text = msg;
            this.ShowDialog();
        }
    }
}