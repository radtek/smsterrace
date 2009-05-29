using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmsTerrace.UI.UseCtrl
{
    public partial class UserLogin :Form
    {
        private UserLogin()
        {
            InitializeComponent();
            ProgressPanel pp = new ProgressPanel();
            pp.Show();
        }

        private static UserLogin ul;
        public static UserLogin Create()
        {
            if (ul==null)
            {
                ul = new UserLogin(); 
            }
            return ul;
        }

        public delegate void loginInfo(string name, string pwd, string exCode);
        public event loginInfo LoginEnd;
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text.Trim().Length < 1 || textBoxX2.Text.Trim().Length < 1 || textBoxX3.Text.Trim().Length < 1)
            {
                MessageBox.Show("填写有误！");
                return;
            }
            LoginEnd(textBoxX1.Text,textBoxX2.Text,textBoxX3.Text);
            this.Visible = false;
            this.Owner.Focus();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            
            this.Owner.Focus();
        }
    }
}
