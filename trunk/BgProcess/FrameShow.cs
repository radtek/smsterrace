using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DevComponents.DotNetBar;

namespace hz.Processor
{
    public partial class FrameShow : UserControl
    {
        public FrameShow(int x, int y)
        {
            InitializeComponent();
            panel1.Click += new EventHandler(imgLabelx_Click);
            this.Location = new System.Drawing.Point(x, y);

        }
        public void SetFootText(string text)
        {
            FootText = text;
        }
        string firstText;

        public string FirstText
        {
            get { return firstText; }
            set
            {
                firstText = value;
                Text = firstText + footText;
            }
        }
        string footText;

        public string FootText
        {
            get { return footText; }
            set
            {
                footText = value;
                Text = firstText + footText;
            }
        }
       

        public string Text
        {
            get { return groupBox1.Text; }
            set { groupBox1.Text = value; }
        }
        public FrameShow()
        {
            InitializeComponent();
            panel1.Click += new EventHandler(imgLabelx_Click);

        }
        List<string> filePathArray = new List<string>();
        public int count()
        {
            return filePathArray.Count;
        }
        public string[] readPathArray()
        {
            return filePathArray.ToArray();
        }
        public bool add(string path)
        {
            if (!Regex.IsMatch(System.IO.Path.GetExtension(path).ToLower(), "^(.jpg|.gif|.txt|.mid|.midi)$"))
            {
                MessageBox.Show("不支持格式！");
                return false;
            }
            filePathArray.Add(path);
            ReShow(filePathArray);
            return true;
        }
        public void clear()
        {
            filePathArray.Clear();
            panel1.Controls.Clear();
            this.SetFootText("共"+filePathArray.Count + "个元素");
        }
        public void ReShow(List<string> pathArray)
        {
            panel1.Controls.Clear();
            for (int i = pathArray.Count - 1; i >= 0; i--)
            {
                string extName = System.IO.Path.GetExtension(pathArray[i]).ToLower();
                int typei = 0;
                Regex rx1 = new Regex("^(.jpg|.gif)$");
                Regex rx2 = new Regex("^(.txt)$");
                Regex rx3 = new Regex("^(.mid|.midi)$");
                if (rx1.IsMatch(extName))
                {
                    panel1.Controls.Add(imgL(pathArray[i]));
                }
                else if (rx2.IsMatch(extName))
                {
                    panel1.Controls.Add(textL(pathArray[i]));

                }
                else if (rx3.IsMatch(extName))
                {

                }
                else
                {
                    MessageBox.Show("不支持的文件格式");

                }

            }
            this.SetFootText("共"+filePathArray.Count + "个元素");
        }
        public LabelX imgL(string imgPath)
        {
            LabelX imgLabelx = new LabelX();
            imgLabelx.BackColor = System.Drawing.Color.Transparent;
            imgLabelx.BackgroundImage = System.Drawing.Image.FromFile(imgPath);//((System.Drawing.Image)(resources.GetObject("imgLabelx.BackgroundImage")));
            imgLabelx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            imgLabelx.Dock = System.Windows.Forms.DockStyle.Top;
            imgLabelx.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            imgLabelx.Location = new System.Drawing.Point(0, 0);
            imgLabelx.Name = "imgLabelx";
            imgLabelx.Size = new System.Drawing.Size(124, 65);
            imgLabelx.Click += new EventHandler(imgLabelx_Click); ;
            imgLabelx.WordWrap = true;
            return imgLabelx;
        }

        void imgLabelx_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
        public LabelX textL(string textPath)
        {
            LabelX textLabelx = new LabelX();
            textLabelx.BackColor = System.Drawing.Color.Transparent;
            textLabelx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            textLabelx.Dock = System.Windows.Forms.DockStyle.Top;

            //  textLabelx.Location = new System.Drawing.Point(0, 64);
            // textLabelx.Name = "labelX2";
            textLabelx.Size = new System.Drawing.Size(124, 85);
            textLabelx.Click += new EventHandler(imgLabelx_Click);
            textLabelx.Text = System.IO.File.ReadAllText(textPath);
            textLabelx.WordWrap = true;
            return textLabelx;
        }

        private void FrameShow_Click(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.FixedSingle;
        }


    }
}
