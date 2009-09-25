using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DevComponents.DotNetBar;

namespace SmsTerrace.UI.UseCtrl
{
    public partial class AddNums : UserControl
    {
        public AddNums()
        {
            InitializeComponent();
        }
      
        private void buttonX4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if ((!char.IsDigit(e.KeyChar))&&e.KeyChar!='\r')
            {
                e.Handled = true;
            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
           // System.Text.RegularExpressions.Regex.Replace(textBox1.Text, @".*\d+.*\Z");
       

          Regex r = new Regex(@"^\B*(\d+).*\Z",RegexOptions.Singleline);
           textBox1.Text= r.Replace(textBox1.Text,"$1+");
           
        } 
        private void buttonX6_Click(object sender, EventArgs e)
        {
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            
        }
        public event SmsTerrace.UI.UseCtrl.OperFilePanel.SelectCol SelectedTable;

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string[] nums = textBox1.Text.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (nums.Length > 0)
            {
                dt.Columns.Add();
                for (int i = 0; i < nums.Length; i++)
                {
                    dt.Rows.Add(nums[i].Trim('\r', '\n', ' '));
                }
            }
            SelectedTable(dt);
            textBox1.Text = "";
        }

    }
}
