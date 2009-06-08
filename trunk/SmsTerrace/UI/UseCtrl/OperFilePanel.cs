using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SmsTerrace.BLL;

namespace SmsTerrace.UI.UseCtrl
{
    public partial class OperFilePanel : UserControl
    {
        public OperFilePanel()
        {
            InitializeComponent();
            InitPanel();
        }
        void InitPanel()
        {
            openFileDialog1.Filter = @"文本文件|*.txt|Excal|*.xls|所有文件|*.*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
          
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {   
                //selectColumn = -1;
                labelX1.Text = "号码列：";
                string fName = openFileDialog1.FileName;
                string suffixName =fName.Substring(fName.LastIndexOf('.')).Trim().TrimStart('.').ToLower();
                maskedTextBoxAdv1.Text = fName;
                if ("txt".Equals(suffixName))
                {
                    string fileText = File.ReadAllText(fName);
                    string[] nums = fileText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    DataTable dt = new DataTable();
                    dt.Columns.Add("列1");
                    dt.Columns.Add("列2");
                    foreach (string num in nums)
                    {
                      int n=  num.IndexOf('\t');
                        
                        if (n>0)
                        {
                               string ns = num.Substring(0,n);
                               dt.Rows.Add(ns,num.Substring(n));
                        }
                        else
                        {
                            dt.Rows.Add(num,"");
                        }
                    }
                    dataGridViewX1.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    dataGridViewX1.DataSource = dt.DefaultView;
                    setColModel();
                }
                if ("xls".Equals(suffixName))
                {
                    SmsOperate so = new SmsOperate();// dataGridViewX1.DataSource= 
                    dataGridViewX1.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    dataGridViewX1.DataSource = so.FromExcel(fName, "").DefaultView;
                    setColModel();
                }
                labelX1.Text = "号码列：列1";
                dataGridViewX1.Columns[0].Selected = true;
            }
        }

        void setColModel()
        {
            foreach (DataGridViewColumn dc in dataGridViewX1.Columns)
            {
                dc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
        }

        private void dataGridViewX1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
               
            }
        }

        private int selectColumn = 0;
        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX1.SelectedColumns.Count<1)
            {
                return;
            }
            labelX1.Text = "号码列：" + dataGridViewX1.SelectedColumns[0].Name;
           selectColumn= dataGridViewX1.SelectedColumns[0].Index;
          
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(selectColumn);
          DataView dv=  dataGridViewX1.DataSource as DataView;
          if ((selectColumn + 1) > dataGridViewX1.Columns.Count || selectColumn<0)
            {
                return;
            }
            DataTable dt = new DataTable();

              string selectName=  dataGridViewX1.Columns[selectColumn].Name;
              dt = dv.ToTable(false, new string[] { selectName});
            //if (selectColumn == 1)
            //{
            //     dt= dv.ToTable(false, new string[] { "列2", "列1" });
            //}
            if (SelectedTable!=null)
            {
                SelectedTable(dt);
            } 
        }

        public delegate void SelectCol(DataTable dt);

        public event SelectCol SelectedTable;
    }
}
