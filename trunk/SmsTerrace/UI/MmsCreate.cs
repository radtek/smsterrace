using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevComponents.DotNetBar;
using hz.sms.Comm;
using SmsTerrace.UI;
using SmsTerrace.BLL;
using hz.BLL.mms;
using System.Text.RegularExpressions;
namespace HzTerrace.UI
{
    public partial class MmsCreate : UserControl
    {
        public MmsCreate()
        {
            InitializeComponent();
        }

        List<FrameShow> mmsfArray = new List<FrameShow>();
        private void button1_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.Controls.Count >= 5)
            {
                MessageBox.Show("最大帧数为5");
                return;
            }

            if (DialogResult.OK != openFileDialog1.ShowDialog())
            {
                return;
            }
            string str = openFileDialog1.FileName;

            FrameShow fs = new FrameShow();//mmsfArray.Count * 140, 0

            if (fs.add(str))
            {
                fs.Name = "fs" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                tableLayoutPanel1.Controls.Add(fs);
                mmsfArray.Add(fs);
                fs.Click += new EventHandler(fs_Click);
                fs.PanelFS.ControlAdded += new ControlEventHandler(fs_ControlAdded);
                fs.PanelFS.ControlRemoved += new ControlEventHandler(fs_ControlRemoved);
            }

        }

        void fs_ControlRemoved(object sender, ControlEventArgs e)
        {
            fs_ControlAdded(null, null);
        }

        void fs_ControlAdded(object sender, ControlEventArgs e)
        {
            string[] pathList = nowFs.readPathArray();
            listBox1.Items.Clear();
            for (int i = 0; i < pathList.Length; i++)
            {
                listBox1.Items.Add((i + 1) + " -  " + pathList[i]);
            }
        }
        FrameShow nowFs;
        void fs_Click(object sender, EventArgs e)
        {
            FrameShow nowFsTemp = (FrameShow)sender;
            if (nowFs != null && nowFs == nowFsTemp)
            {
                return;
            }
            if (nowFs != null)
            {
                nowFs.BorderStyle = BorderStyle.None;
            }
            nowFs = nowFsTemp;

            fs_ControlAdded(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nowFs != null)
            {
                if (DialogResult.OK != openFileDialog1.ShowDialog())
                {
                    return;
                }

                string str = openFileDialog1.FileName;
                FrameShow fs = nowFs;

                if (fs.add(str))
                {
                    // fs.Controls.Add(fs);
                }

            }
            else
            {
                MessageBox.Show("请先选择要编辑的帧！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dictionary<string, byte[]> dic = new Dictionary<string, byte[]>();
            int totalSize = 0;
            for (int i = 0; i < mmsfArray.Count; i++)
            {
                for (int j = 0; j < mmsfArray[i].readPathArray().Length; j++)
                {
                    string p = mmsfArray[i].readPathArray()[j];
                    string ext = i + "_" + j + "_" + System.IO.Path.GetExtension(p);
                    byte[] fileByte = File.ReadAllBytes(p);
                    totalSize += fileByte.Length;
                    dic.Add(ext, fileByte);
                }
            }
            if (totalSize > InitInfo.MMS_MAX_SIZE)
            {
                MessageBox.Show("MMS内容总大小为" + (totalSize / 1024) + "KB," + "超过限制大小！允许最大MMS为" + (InitInfo.MMS_MAX_SIZE / 1024) + "KB");
                return;
            }

            if (textBoxX1.Text.Trim().Length < 1 || textBoxX2.Text.Trim().Length < 1 || integerInput1.Value < 1)
            {
                MessageBox.Show("发送参数不正确！");
                return;
            }
            //if (phoneNums.Trim().TrimEnd(',').Length < 1)
            //{
            //    MessageBox.Show("没有可发送号码，请确认号码导入正确");
            //    return;
            //}

            backgroundWorker1.RunWorkerAsync(dic);
            this.Parent.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (nowFs != null)
            {
                tableLayoutPanel1.Controls.RemoveByKey(nowFs.Name);
                mmsfArray.Remove(nowFs);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {



            SmsTerrace.Form1 f = new SmsTerrace.Form1();
           // f.Show();
            for (int ik = 0; ik < tableLayoutPanel1.Controls.Count; ik++)
            {
                //textBox1.Text+= ((tableLayoutPanel1.Controls[ik])).GetType().ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (nowFs != null)
            {
                nowFs.clear();
            }
            //tableLayoutPanel1.HorizontalScroll.Width = 10;
        }

        private void tableLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            FrameShow fs = e.Control as FrameShow;
            fs.FirstText = "第" + tableLayoutPanel1.Controls.Count + "帧-";
        }

        private void tableLayoutPanel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                FrameShow fs = tableLayoutPanel1.Controls[i] as FrameShow;
                fs.FirstText = "第" + (i + 1) + "帧-";
            }
        }
        Random r = new Random(DateTime.Now.Millisecond);
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                if (dataGridViewX1.Rows.Count < 1)
                {
                    MessageBox.Show("请导入号码！");
                    return;
                }
                Dictionary<string, byte[]> dic = e.Argument as Dictionary<string, byte[]>;
                MmsManage mmsManage = new MmsManage();

                // phoneNums=dataGridViewX1.Rows

                StringBuilder sbu = new StringBuilder();
                foreach (DataGridViewRow item in dataGridViewX1.Rows)
                {
                    if (item.Cells.Count < 1 || item.Cells[0].Value == null)
                        continue;
                    if (PhoneNumValidate(item.Cells[0].Value.ToString().Trim()) < 0)
                    {
                        item.Cells[0].Style.BackColor = Color.Red;
                        continue;
                    }
                    sbu.Append(item.Cells[0].Value as string);
                    sbu.Append(",");
                }

                string ph = sbu.ToString().TrimEnd(',');
                phoneNums = ph;
                dic = mmsManage.MmsXmlToDic(textBoxX4.Text, ph, dic);
                byte[] zipByte = hz.sms.Comm.ZipUtile.ZipToByte(dic);
                SmsTerrace.ClientWebServer.ClientServer fk = new SmsTerrace.ClientWebServer.ClientServer();
                string mmsUserId = textBoxX1.Text;
                string mmsPwd = textBoxX2.Text;
                int mmsBid = integerInput1.Value;
                int sr = r.Next(99999);

               
                string md5pwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(mmsPwd + sr, "MD5").ToLower();
                string[] sArr = new string[] { mmsUserId, md5pwd, mmsBid.ToString(), ph, Convert.ToBase64String(zipByte), " ", " ", sr.ToString() };
                SmsTerrace.ClientWebServer.OpRespOfSendResp opR = fk.MmsToService(sArr);
                e.Result = opR;
            }
            catch (Exception ex)
            {
                LogInfoManage.AddLogInfo(4, "backgroundWorker1_DoWork发送时异常", ex.ToString());
                MessageBox.Show("发送异常！");
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Parent.Enabled = true;
            if (e.Error != null || e.Result == null)
            {
                return;
            }
            SmsTerrace.ClientWebServer.OpRespOfSendResp opR = e.Result as SmsTerrace.ClientWebServer.OpRespOfSendResp;
            MessageBox.Show(opR.State.Resp.ToString() + "\n" + opR.State.RespDesc);
            if (opR.State.Result < 0)
            {
                return;
            }
            SmsTerrace.BLL.短信记录Manage jl = new SmsTerrace.BLL.短信记录Manage();
            SmsTerrace.Model.短信记录 jlModel = new SmsTerrace.Model.短信记录();
            jlModel.号码 = phoneNums;
            jlModel.内容 = "彩信:"+opR.ReturnResult.SubmitID;
            jlModel.时间 = DateTime.Now.ToString();
            jlModel.状态 = opR.State.Result + "";
            jlModel.备注 = opR.State.Resp + opR.State.RespDesc;
            jl.Add(jlModel);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Form fo = new Form();

            //SmsTerrace.UI.UseCtrl.OperFilePanel f = new SmsTerrace.UI.UseCtrl.OperFilePanel();
            //fo.Controls.Add(f);
            //fo.Show();

            SmsTerrace.UI.DeriveFrm deriveFrm = new SmsTerrace.UI.DeriveFrm();
            deriveFrm.Show();
            deriveFrm.DataSelectEnd += new DoWorkEventHandler(deriveFrm_SelectEnd);

        }
        string phoneNums = "";
        void deriveFrm_SelectEnd(object sender, DoWorkEventArgs e)
        {

            DeriveFrm df = sender as DeriveFrm;
            DataTable dt = e.Argument as DataTable;
            df.Close();
            phoneNums = "";
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                phoneNums += (row[0].ToString() + ",");
              int newRow=  dataGridViewX1.Rows.Add(row.ItemArray[0]);
              if (PhoneNumValidate(row.ItemArray[0] as string) < 1)
                  dataGridViewX1[0, newRow].Style.BackColor = Color.LightCoral;
            }

            phoneNums = phoneNums.TrimEnd(',');
            textBoxX3.Text = "导入号码" + i;
            MessageBox.Show("已导入号码：" + i);
        }


        public int PhoneNumValidate(string phoneNum)
        {
            if (Regex.IsMatch(phoneNum, @"^(0\d{9,11})|(1\d{10})$"))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        private void 删除选中行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridViewX1.SelectedRows)
            {
                if (!item.IsNewRow)
                    dataGridViewX1.Rows.Remove(item);
            }
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewX1.SelectAll();
        }

        private void 验证号码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridViewX1.Rows)
            {
                if (item.Cells.Count < 1 || item.Cells[0].Value == null)
                    continue;
                if (PhoneNumValidate(item.Cells[0].Value.ToString().Trim()) < 0)
                {
                    item.Cells[0].Style.BackColor = Color.MediumVioletRed;
                    continue;
                }
            }
        }
        
        private void 删除错误号码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> list = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in dataGridViewX1.Rows)
            {
                if (item.IsNewRow)
                    continue;
                bool bo = item.Cells.Count < 1 || item.Cells[0].Value == null;
                if (bo||PhoneNumValidate(item.Cells[0].Value.ToString().Trim()) < 0)
                {
                   // dataGridViewX1.Rows.Remove(item);
                    list.Add(item);
                }
            }
            foreach (DataGridViewRow item in list)
            {
                dataGridViewX1.Rows.Remove(item);
            }
        }

        private void dataGridViewX1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell dgvc = dataGridViewX1[e.ColumnIndex, e.RowIndex];
            if (dgvc.OwningRow.IsNewRow)
            {
                return;
            }
            string phn = dgvc.Value as string;

            if (phn == null || PhoneNumValidate(phn.Trim()) < 0)
            {
                dataGridViewX1.CurrentCell.Style.BackColor = Color.LightCoral;
            }
            else
            {
                dataGridViewX1.CurrentCell.Style.BackColor = System.Drawing.SystemColors.Window ;
            }
        }

    }
}
