using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using hz.Processor;

namespace BgProcess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.Controls.Add(new FrameShow(500,100));
        }
        List<FrameShow> mmsfArray = new List<FrameShow>();
        private void button1_Click(object sender, EventArgs e)
        {

            if (DialogResult.OK != openFileDialog1.ShowDialog())
            {
                return;
            }
            textBox1.Text = openFileDialog1.FileName;
            FrameShow fs = new FrameShow(mmsfArray.Count * 140, 0);

            if (fs.add(textBox1.Text))
            {
                fs.Name = "fs" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                panel2.Controls.Add(fs);
                mmsfArray.Add(fs);
                fs.Click += new EventHandler(fs_Click);
            }

            //hz.Comm.zip.ZipFile zip = new hz.Comm.zip.ZipFile();
            //Dictionary<string, byte[]> f = new Dictionary<string, byte[]>();
            //f.Add("6.jpg", File.ReadAllBytes(textBox1.Text));
            //  zip.zip("F:/p.zip",f,null);
        }
        FrameShow nowFs;
        void fs_Click(object sender, EventArgs e)
        {
            FrameShow nowFsTemp = (FrameShow)sender;
            if (nowFs != null&&nowFs == nowFsTemp)
            {
                return;
            }
            if (nowFs!=null)
            {
                nowFs.BorderStyle = BorderStyle.None;
            }
            nowFs = nowFsTemp;
        }
        public void re()
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nowFs != null)
            {
                if (DialogResult.OK != openFileDialog1.ShowDialog())
                {
                    return;
                }
                textBox1.Text = openFileDialog1.FileName;
                FrameShow fs = nowFs;

                if (fs.add(textBox1.Text))
                {
                    panel2.Controls.Add(fs);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dictionary<string, byte[]> dic = new Dictionary<string, byte[]>();

            for (int i = 0; i < mmsfArray.Count; i++)
            {
                for (int j = 0; j < mmsfArray[i].readPathArray().Length;j++)
                {
                  string p=  mmsfArray[i].readPathArray()[j];
                 string ext=i+"_"+j+"_" +System.IO.Path.GetExtension(p);
                  dic.Add(ext,File.ReadAllBytes(p));
                }
            }
            hz.Comm.zip.ZipFile z = new hz.Comm.zip.ZipFile();
            z.zip("F:/test.zip",dic);
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }
    }
}