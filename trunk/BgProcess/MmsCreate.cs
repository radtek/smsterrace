using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevComponents.DotNetBar;

namespace hz.Processor
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

            if (DialogResult.OK != openFileDialog1.ShowDialog())
            {
                return;
            }
            string str = openFileDialog1.FileName;
            textBox1.Text = str;
            FrameShow fs = new FrameShow();//mmsfArray.Count * 140, 0

            if (fs.add(str))
            {
                fs.Name = "fs" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                tableLayoutPanel1.Controls.Add(fs);
                mmsfArray.Add(fs);
                fs.Click += new EventHandler(fs_Click);
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
            string[] pathList=nowFs.readPathArray();
            for (int i = 0; i < pathList.Length; i++)
			{
                textBox1.Text += pathList[i]+"\n";
			}
            
            
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
                textBox1.Text = str;
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
            
            for (int i = 0; i < mmsfArray.Count; i++)
            {
                for (int j = 0; j < mmsfArray[i].readPathArray().Length; j++)
                {
                    string p = mmsfArray[i].readPathArray()[j];
                    string ext = i + "_" + j + "_" + System.IO.Path.GetExtension(p);
                    dic.Add(ext, File.ReadAllBytes(p));
                }
            }
            hz.Comm.zip.ZipFile z = new hz.Comm.zip.ZipFile();
            z.zip("F:/test.zip", dic);
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
            for (int ik = 0; ik < tableLayoutPanel1.Controls.Count; ik++)
            {
               textBox1.Text+= ((tableLayoutPanel1.Controls[ik])).GetType().ToString();
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
    }
}
