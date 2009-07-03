using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SmsTerrace.UI;
using SmsTerrace.UI.UseCtrl;
using DevComponents.DotNetBar;

namespace SmsTerrace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = @"文本文件|*.txt|Excal|*.xls|所有文件|*.*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            panel2.Controls.Add(new AddressBook());
            controlContainerItem4.Control=advTree1;
        }


        private void bar1_ItemClick(object sender, EventArgs e)
        {
            panel2.Controls.Add(new Form1());
            HzTerrace.BLL.relation relBLL = new HzTerrace.BLL.relation();
            HzTerrace.Model.relation relModel = new HzTerrace.Model.relation();
            relModel.name = "Test";
            relModel.sex = true;
            relModel.phone1 = "";
            relModel.phone2 = "";
            relModel.company = "";
            relModel.email = "";
            relModel.address = "";
            relModel.remark = "";
            relBLL.Add(relModel); //
            dataGridView1.DataSource = relBLL.GetAllList().Tables[0];
       
            /*
            Console.WriteLine(SmsTerrace.Comm.XorCoding.Decrypt(SmsTerrace.Comm.XorCoding.Encrypt("0")));
            byte[] bb = new byte[] { 1, 0, 0, 1 }; 
           
           byte[] bta=  SmsTerrace.Comm.XorCoding.XorByte(bb);
          Console.WriteLine(Convert.ToBase64String(bb));
           Console.WriteLine( Convert.ToBase64String(bta));
           Console.WriteLine(Convert.ToBase64String(SmsTerrace.Comm.XorCoding.XorByte(bta)));
            //(new SmsFrm()).Show();
             */ 
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
          
                string fName = openFileDialog1.FileName;
            
                
          
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            ScrollableControl f = new ScrollableControl();
            f.AutoScroll = true;
            f.BackColor = Color.Red;
            f.Width = 50;
            f.Height = 100;
           // f.Width=2;
            Button b1 = new Button();
            b1.Location = new Point(20,20);
            Button b2 = new Button();
            b2.Location = new Point(40, 40);
            Button b3 = new Button();
            b3.Location = new Point(60,60);
            f.Controls.Add(b1);
            f.Controls.Add(b2);
            f.Controls.Add(b3);
            this.Controls.Add(f);
            MessageBox.Show(f.Location.ToString());
           
            if (true)
            {
                return;
            }
            panel1.VerticalScroll.Visible=false;
            MessageBox.Show(panel1.VerticalScroll.Value.ToString()+"==="+panel1.VerticalScroll.Maximum);
            for (int i = 0; i < panel1.VerticalScroll.Maximum; i++)
            {
                panel1.VerticalScroll.Value = i;
                //System.Threading.Thread.Sleep(500);
                
                
            }
        }

        private void vScrollBarAdv1_Scroll(object sender, ScrollEventArgs e)
        {
           
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            hScrollBar1.BackColor = Color.Red;//.Height = 100;
            //System.Windows.Forms.SafeNativeMethods.ShowWindow(1235,222);
        }

        private void advTree1_NodeDoubleClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            buttonX2.Expanded = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hz.sms.DBUtility.NewDbHelperOleDb db=  new hz.sms.DBUtility.NewDbHelperOleDb("","no1");
            hz.sms.DBUtility.HiveOleDb db2=new hz.sms.DBUtility.HiveOleDb("dddd","no1");
            MessageBox.Show(hz.sms.DBUtility.NewDbHelperOleDb.GetDbByRecord("no2").ConnectionString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SmsTerrace.UI.FirstFrm f1 = new SmsTerrace.UI.FirstFrm();
            f1.Show();   
        }


    }
}