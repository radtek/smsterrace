using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SmsTerrace.BLL;

namespace SmsTerrace.UI.UseCtrl
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                SmsWebServiceMirror sm = new SmsWebServiceMirror();
                SmsWebService.GetBalanceResp resp = sm.GetBalance(SmsFrm.userName, SmsFrm.userPwd, SmsFrm.userExCode);
                string str = resp.ErrorDesc + "\n剩余条数:" + resp.Balance;
                MessageBox.Show(str);
            }catch(System.Net.WebException ex){
                MessageBox.Show("连接服务器失败");
            }
            catch (Exception ex)
            {
                MessageBox.Show("信息获取错误!");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                SmsWebServiceMirror sm = new SmsWebServiceMirror();
                SmsWebService.GetSmsResultResp resp = sm.GetSmsResult(SmsFrm.userName, SmsFrm.userPwd, SmsFrm.userExCode);
                string str = resp.ErrorDesc.ToString();
                MessageBox.Show(str);
            }
            catch (System.Net.WebException ex)
            {
                MessageBox.Show("连接服务器失败");
            }
            catch (Exception ex)
            {
                MessageBox.Show("信息获取错误!");
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (textBoxX2.Text.Equals("adminshow")&&textBoxX3.Text.Equals("true"))
            {
                panel1.Visible = true;
            }
            if (textBoxX2.Text.Length>6&&textBoxX2.Text.Equals(textBoxX3.Text))
            {
                try
                {
                    SmsWebServiceMirror sm = new SmsWebServiceMirror();
                    SmsWebService.SetPasswordResp resp = sm.SetPassword(SmsFrm.userName, SmsFrm.userPwd, textBoxX2.Text);
                    string str = resp.ErrorDesc.ToString();
                    MessageBox.Show(str);
                }
                catch (Exception)
                {
                    MessageBox.Show("执行失败！");
                    
                }
            }else if (textBoxX2.Text.Length<6)
            {
                MessageBox.Show("密码不可小于6位");
            }
            else
            {
                MessageBox.Show("2次输入密码不相同");
            }

        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
              SmsTerrace.DAL.短信记录Service dal=new SmsTerrace.DAL.短信记录Service();
            dal.DeleteALL();
            MessageBox.Show("OK");
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
             SmsTerrace.DAL.接收记录Service dal=new SmsTerrace.DAL.接收记录Service();
            dal.DeleteALL();
            MessageBox.Show("OK");
        }
    }
}
