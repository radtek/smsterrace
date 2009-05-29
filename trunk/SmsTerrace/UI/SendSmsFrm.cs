using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SmsTerrace.UI.UseCtrl;
using SmsTerrace.BLL;
using SmsTerrace.SmsWebService;

namespace SmsTerrace.UI
{
    public partial class SendSmsFrm : Form
    {
        SmsWebServiceMirror SmsWebSer = new SmsWebServiceMirror();
        public SendSmsFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder phoneNumList = new StringBuilder();
            foreach (DataGridViewRow itemRow in  dataGridView1.Rows)
            {
               string phoneNum= itemRow.Cells[1].Value as string;
               phoneNumList.Append(phoneNum);
               phoneNumList.AppendLine(",");
            }
            SendResp sendResp = SmsWebSer.Send("whw", "whw", "6", textBox1.Text, phoneNumList.ToString(), "");
            MessageBox.Show(sendResp.ErrorDesc.ToString());
        }
    }
}
