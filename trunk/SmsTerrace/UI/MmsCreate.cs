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
namespace HzTerrace.UI
{
    public partial class MmsCreate :UserControl
    {
        public MmsCreate()
        {
            InitializeComponent();
            
        }

        List<FrameShow> mmsfArray = new List<FrameShow>();
        private void button1_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.Controls.Count>=10)
            {
                MessageBox.Show("最大帧数为10");
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
            fs_ControlAdded(null,null);
        }

        void fs_ControlAdded(object sender, ControlEventArgs e)
        {
            string[] pathList = nowFs.readPathArray();
            listBox1.Items.Clear();
            for (int i = 0; i < pathList.Length; i++)
            {
                listBox1.Items.Add((i+1)+" -  "+pathList[i]);
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
           
            fs_ControlAdded(null,null);
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
                    byte[] fileByte=File.ReadAllBytes(p);
                    totalSize += fileByte.Length;
                    dic.Add(ext, fileByte);
                }
            }
            if (totalSize > InitInfo.MMS_MAX_SIZE)
            {
                MessageBox.Show("MMS内容总大小为" + (totalSize / 1024) + "KB," + "超过限制大小！允许最大MMS为" + (InitInfo.MMS_MAX_SIZE/1024)+"KB");
                return;
            }
           

           backgroundWorker1.RunWorkerAsync(dic);
          this.Parent.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (nowFs !=null)
            {
                tableLayoutPanel1.Controls.RemoveByKey(nowFs.Name);
                mmsfArray.Remove(nowFs);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SmsTerrace.Form1 f = new SmsTerrace.Form1();
            f.Show();
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
           FrameShow fs= e.Control as FrameShow;
           fs.FirstText ="第"+tableLayoutPanel1.Controls.Count+"帧-";
        }

        private void tableLayoutPanel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
               FrameShow fs= tableLayoutPanel1.Controls[i] as FrameShow;
               fs.FirstText = "第" + (i+1) + "帧-";
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            Dictionary<string, byte[]> dic = e.Argument as Dictionary<string, byte[]>;
            byte[] zipByte = hz.sms.Comm.ZipUtile.ZipToByte(dic);
            SmsTerrace.ClientWebServer.ClientServer fk = new SmsTerrace.ClientWebServer.ClientServer();
            string mmsUserId = textBoxX1.Text;
            string mmsPwd = textBoxX2.Text;
            int mmsBid = integerInput1.Value;
            if (phoneNums.Trim().TrimEnd(',').Length<1)
            {
                MessageBox.Show("没有可发送号码，请确认号码导入正确");
                return;
            }
            string[] sArr = new string[] { mmsUserId, mmsPwd, mmsBid.ToString(), phoneNums, Convert.ToBase64String(zipByte), " ", " ", "111" };
            SmsTerrace.ClientWebServer.OpRespOfSendResp opR= fk.MmsToService(sArr);
            e.Result = opR;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          this.Parent.Enabled = true;
            SmsTerrace.ClientWebServer.OpRespOfSendResp opR = e.Result as SmsTerrace.ClientWebServer.OpRespOfSendResp;
            MessageBox.Show(opR.State.Resp.ToString()+"\n"+opR.State.RespDesc);
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
            DataTable dt=e.Argument as DataTable;
            df.Close();
            phoneNums = "";
            int i=0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
               phoneNums+= (row[0].ToString()+",");
            }
            phoneNums = phoneNums.TrimEnd(',');
            textBoxX3.Text = "导入号码" + i;
            MessageBox.Show("已导入号码：" + i);

        }

       
    }
}
