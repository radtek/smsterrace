using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.WinForms;
using DevComponents.DotNetBar;
using hz.sms.Comm;
using SmsTerrace.BLL;
using SmsTerrace.IBLL;
using SmsTerrace.SmsWebService;
using SmsTerrace.UI.UseCtrl;
using SmsTerrace.Model;

namespace SmsTerrace.UI
{
    public partial class SmsFrm : Office2007RibbonForm
    {
        private UserLogin ul;
        public static string userName;

        public string UserName
        {
            get
            {
                return userName;
            }
            set { userName = value; }
        }


        void f_LoginEnd(string name, string pwd, string exCode)
        {
            UserName = name;
            UserPwd = pwd;
            UserExCode = exCode;
            this.Text = "用户名：" + UserName + "     业务代码：" + UserExCode;
        }
       public static string userPwd;

        public string UserPwd
        {
            get { return userPwd; }
            set { userPwd = value; }
        }
        public static string userExCode;

        public string UserExCode
        {
            get { return userExCode; }
            set { userExCode = value; }
        }
        SmsWebServiceMirror SmsWebSer = new SmsWebServiceMirror();
        private SmsOperate smsOperate = new SmsOperate();
       
        public SmsFrm()
        {         
            InitializeComponent();
            panelEx4.Controls.Add(new UserControl2());
            HzTerrace.UI.MmsCreate mc = new HzTerrace.UI.MmsCreate();
            ribbonPanel6.Controls.Add(mc);
            ribbonPanel6.EnabledChanged += new EventHandler(ribbonPanel1_EnabledChanged);
            InitFrm();

        }

        

        void InitFrm()
        {
            p1b1 = panelEx1.Style.BackColor1.Color;
            p1b2 = panelEx1.Style.BackColor2.Color;
            p2b1 = panelEx2.Style.BackColor1.Color;
            p1b2 = panelEx1.Style.BackColor2.Color;
            panelEx1.Style.BackColor1.Color = panelEx1.StyleMouseOver.BackColor1.Color;
            panelEx1.Style.BackColor2.Color = panelEx1.StyleMouseOver.BackColor2.Color;
            panelEx2.Style.BackColor1.Color = p2b1;
            panelEx2.Style.BackColor2.Color = p2b2;
            OperFilePanel ofp = new OperFilePanel();
            controlContainerItem5.Control = ofp;
            ofp.SelectedTable += new OperFilePanel.SelectCol(ofp_SelectedTable);

            ul = UserLogin.Create();
            ul.LoginEnd += new UserLogin.loginInfo(f_LoginEnd);
            if (UserName == null || UserName.Trim().Length < 1)
            {
                this.Text = "未登陆用户";
            }
        }

        void ofp_SelectedTable(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                 dataGridViewX1.Rows.Add(dr.ItemArray) ;
            }
            buttonItem17.Expanded=false;
        }

        private void qatCustomizeItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1");
        }

        private void office2007StartButton1_Click(object sender, EventArgs e)
        {

        }

        private bool panelEx1Open=true;
        private Color p2b1;
        private Color p2b2;
        private void panelEx2_Click(object sender, EventArgs e)
        {
            if (!panelEx1Open)//如果没有展开
            {
                return;
            }
            panelEx2.Size = new Size(574,300);
            panelEx2.Location = (new Point(panelEx2.Location.X, panelEx2.Location.Y - 200));
            panelEx1.Size = new Size(574, 100);
            panelEx1Open = false;
            panelEx2.Style.BackColor1.Color= panelEx2.StyleMouseOver.BackColor1.Color;
            panelEx2.Style.BackColor2.Color = panelEx2.StyleMouseOver.BackColor2.Color;
            panelEx1.Style.BackColor1.Color = p1b1;
            panelEx1.Style.BackColor2.Color = p1b2;

            panel1.Visible = false;
            panel2.Visible = true;
        }

        private Color p1b1;
        private Color p1b2;
        private void panelEx1_Click(object sender, EventArgs e)
        {
            if (panelEx1Open)
            {
                return;
            }
            panelEx1.Size = new Size(574, 300);
            panelEx2.Location = (new Point(panelEx2.Location.X, panelEx2.Location.Y + 200));
            panelEx2.Size = new Size(574, 100);
            panelEx1Open = true;
            panelEx1.Style.BackColor1.Color = panelEx1.StyleMouseOver.BackColor1.Color;
            panelEx1.Style.BackColor2.Color = panelEx1.StyleMouseOver.BackColor2.Color;
            panelEx2.Style.BackColor1.Color = p2b1;
            panelEx2.Style.BackColor2.Color = p2b2;
            panel1.Visible = true;
            panel2.Visible = false;
        }


        private void buttonX5_Click(object sender, EventArgs e)
        {
            string time = "";
            if (textBoxX1.Text.Trim().Length<=0)
            {
                MessageBox.Show("内容不可为空");
                return;
            }
            if (checkBoxX1.Checked&&dateTimeInput6.Value > DateTime.Parse("2000-1-1"))
            {
                time = dateTimeInput6.Value.ToShortTimeString() + " " + integerInput1 + ":" + integerInput2 + ":00";
            }
            if (textBoxX4.Text.Trim().Length>0)
            {
                sendSms(textBoxX1.Text + "[" + textBoxX4.Text + "]",time );
            }
            else
            {
                MessageBox.Show("请填写企业签名！");
            }
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            string time = "";
            if (checkBoxX1.Checked&&dateTimeInput6.Value > DateTime.Parse("2000-1-1"))
            {
                time = dateTimeInput6.Value.ToShortTimeString()+" "+integerInput1+":"+integerInput2+":00";
            }
            if (textBoxX2.Text.Trim().Length<=0)
            {
                MessageBox.Show("内容不可为空！");
                return;
            }
            sendSms(textBoxX2.Text,time);
        }


        void sendSms(string content,string sendTime)
        { 
            if (userName == null || userName.Trim().Length < 1)
            {
                ul.ShowDialog(this);
            }
            if (UserName==null||UserName.Trim().Length<1)
            {
                MessageBox.Show("请先填写发送账号");
                return;
            }
      
            StringBuilder phoneNumList = new StringBuilder();
            foreach (DataGridViewRow itemRow in dataGridViewX1.Rows)
            {
                string phoneNum = itemRow.Cells[0].Value as string;
                phoneNumList.Append(phoneNum);
                phoneNumList.AppendLine(",");
            }

            try
            {
                ribbonPanel1.Enabled = false;
                
                string[] sendParam = {UserName, userPwd, UserExCode, content, phoneNumList.ToString(), sendTime};
                backgroundWorker2.RunWorkerAsync(sendParam);
               
            }
            catch (Exception e)
            {
                Log.Error("发送短息",e.ToString()); 
                MessageBox.Show("发送失败！请查看网络连接是否正常");
                ribbonPanel1.Enabled = true;
            }
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (userName == null || userName.Trim().Length < 1)
            {
                ul.ShowDialog(this);
            }
            if (UserName == null || UserName.Trim().Length < 1)
            {
                MessageBox.Show("请先填写账号");
                return;
            }
            string[] param ={UserName,userPwd,"10000"};
            ribbonPanel2.Enabled = false;
            backgroundWorker1.RunWorkerAsync(param);
         
        }
       

        private void buttonX1_Click(object sender, EventArgs e)
        {

          DataView dv=  dataGridViewX2.DataSource as DataView;
            StringBuilder filterStr = new StringBuilder();
            filterStr.Append(" 1=1 ");
            
          if (dateTimeInput1.Value>DateTime.Parse("1975-01-01"))
            {
                filterStr.Append(" and ");
                filterStr.Append("时间>='"+dateTimeInput1.Value.ToShortDateString()+"'");
            }
            if (dateTimeInput2.Value >DateTime.Parse("1975-01-01"))
            {
                filterStr.Append(" and ");
                filterStr.Append("时间<='" + dateTimeInput1.Value.ToShortDateString()+"'");
            }
            if (textBoxX7.Text.Trim().Length > 0 && comboBoxEx1.SelectedItem!=null)
            {
                filterStr.Append(" and ");
                DevComponents.Editors.ComboItem comItem= comboBoxEx1.SelectedItem as DevComponents.Editors.ComboItem;
                filterStr.Append(comItem.Text + " like '%" + textBoxX7.Text + "%'");
            }
            dv.RowFilter = filterStr.ToString();
            labelX14.Text ="共"+ dv.Count + "行";
        }

        private void dataGridViewX2_SelectionChanged(object sender, EventArgs e)
        {
             DataView dv=  dataGridViewX2.DataSource as DataView;
            labelX15.Text ="已选中"+ dataGridViewX2.SelectedRows.Count.ToString()+"行";
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {

           
            if (dataGridViewX3.DataSource == null)
            {
                dataGridViewX3Refresh();
            }
            DataView dv = dataGridViewX3.DataSource as DataView;
            StringBuilder filterStr = new StringBuilder();
            filterStr.Append(" 1=1 ");

            if (dateTimeInput4.Value > DateTime.Parse("1975-01-01"))
            {
                filterStr.Append(" and ");
                filterStr.Append("时间>='" + dateTimeInput4.Value.ToShortDateString() + "'");
            }
            if (dateTimeInput3.Value > DateTime.Parse("1975-01-01"))
            {
                filterStr.Append(" and ");
                filterStr.Append("时间<='" + dateTimeInput3.Value.ToShortDateString() + "'");
            }
            if (textBoxX8.Text.Trim().Length > 0 && comboBoxEx2.SelectedItem != null)
            {
                filterStr.Append(" and ");
                DevComponents.Editors.ComboItem comItem = comboBoxEx2.SelectedItem as DevComponents.Editors.ComboItem;
                filterStr.Append(comItem.Text + " like '%" + textBoxX8.Text + "%'");
            }
            dv.RowFilter = filterStr.ToString();
            labelX21.Text = "已显示"+dv.Count+"行";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
          string[] param=  e.Argument as string[];//用户名，密码，查询行数S
             GetUpSmsResp gusr = SmsWebSer.GetUpSms(param[0], param[1], param[2]);
             e.Result = gusr;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GetUpSmsResp gus=e.Result as GetUpSmsResp;
            if (gus.Result!=0)
            {
                MessageBox.Show(gus.ErrorDesc.ToString());
            }
            UpSms[] us = gus.Sms;
            int newRowCount = 0;
            foreach (UpSms u in us)
            {
                smsOperate.AddMoInfo(SmsWebSer.ConvertTo接收记录(u));
                newRowCount++;
            }
            InitDataGridViewX2();
            for (int i = 1; i <= newRowCount; i++)
            {
                dataGridViewX2.Rows[i-1].DefaultCellStyle.BackColor = Color.BlueViolet;
            }
            ribbonPanel2.Enabled = true;
        }
         void InitDataGridViewX2()
         {
            DataTable dt= smsOperate.GetMoInfo("");
            dataGridViewX2.DataSource = dt.DefaultView;
             dt.DefaultView.Sort = "编号 DESC";
            dataGridViewX2.Columns["发送人"].Width = 70;
           
            labelX14.Text = "共" + dt.Rows.Count + "行";
         }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                string[] sendParam = e.Argument as string[];//

                SendResp sendResp = SmsWebSer.Send(sendParam[0], sendParam[1], sendParam[2], sendParam[3], sendParam[4], sendParam[5]);

                e.Result = new object[] { sendResp, sendParam };
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送异常！请重试");
                Log.Error("后台发送短信时",ex.ToString());
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {
                object[] objs = e.Result as object[];
                SendResp sendResp = objs[0] as SendResp;
                string[] sendInfo = objs[1] as string[];//账号，密码，业务代码，内容3，手机号，定时时间
                短信记录 mod = new 短信记录();
                mod.状态 = SmsWebSer.ConvertToStatus(sendResp.Result + "");
                mod.号码 = sendInfo[4];
                mod.内容 = sendInfo[3];
                mod.时间 = DateTime.Now.ToString();
                mod.备注 = sendInfo[2] + "_描述：" + sendResp.ErrorDesc;
                if (sendInfo[5] != null && sendInfo[5].Trim().Length > 0)
                {
                    mod.备注 += "_定时时间：" + sendInfo[5];
                }
                smsOperate.AddSmsInfo(mod);
                MessageBox.Show(sendResp.ErrorDesc.ToString());
           
            }
            catch (Exception e1)
            {
                Log.Error(e1.ToString());
            }finally
            {
                ribbonPanel1.Enabled = true;
            }
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            
        }

        private void ribbonTabItem4_Click(object sender, EventArgs e)
        {
            if (dataGridViewX3.DataSource==null)
            {
                dataGridViewX3Refresh();
            }
           
        }
       void dataGridViewX3Refresh()
       {
           DataTable dt = smsOperate.GetSmsInfo("");
          DataView dv= dt.DefaultView;
           dv.Sort = "编号 DESC";
          dataGridViewX3.DataSource = dv;
           labelX2.Text = "共" + dt.Rows.Count + "行";
           labelX21.Text = " 已显示" + dv.Count + "行";
       }

        private void checkBoxX2_Click(object sender, EventArgs e)
        {

            panel3.Enabled = !panel3.Enabled;
               
        }

        private void checkBoxX1_Click(object sender, EventArgs e)
        {
                panel4.Enabled = !panel4.Enabled;
        }

        private void ribbonTabItem2_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.DataSource==null)
            {
                InitDataGridViewX2();
            }
            
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hz.sms beta1.1");
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            labelX4.Text = "已输入字符数："+textBoxX1.Text.Length;
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            labelX5.Text = "已输入字符数：" + textBoxX2.Text.Length;
           
        }

        private void office2007StartButton1_Click_1(object sender, EventArgs e)
        {
            ul.ShowDialog(this);
        }

        private void ribbonPanel1_EnabledChanged(object sender, EventArgs e)
        {

            pictureBox1.Visible = !(ribbonPanel1.Enabled && ribbonPanel2.Enabled && ribbonPanel6.Enabled);
           
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            dataGridViewX3Refresh();
        }

        private void 删除选中行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell dc in dataGridViewX1.SelectedCells)
            {
                try
                {
                        dataGridViewX1.Rows.Remove(dc.OwningRow);
                }
                catch (Exception)
                {
                }
                
            }
            
        }


    }
}
