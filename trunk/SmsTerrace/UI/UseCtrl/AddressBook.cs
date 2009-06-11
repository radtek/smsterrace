using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Collections;

namespace SmsTerrace.UI.UseCtrl
{
    public partial class AddressBook : UserControl
    {
        HzTerrace.BLL.relation relBLL = new HzTerrace.BLL.relation();
        public AddressBook()
        {
            InitializeComponent();
           DataTable dt=  relBLL.GetAllList().Tables[0];
            dt.Columns.Add("sexStr",typeof(string));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["sexStr"] = (bool)dt.Rows[i]["sex"] ? "男" : "女"; 
            }
            bindingSource1.DataSource = dt;
            dataGridViewX1.DataSource = bindingSource1;
            DataGridViewProcess();
        }
        void DataGridViewProcess()
        {
            dataGridViewX1.Columns["pertainUser"].Visible = false;
           
            dataGridViewX1.Columns["sex"].Visible = false;
       
            //dataGridViewX1.Columns["name"].HeaderText = "姓名";
            //dataGridViewX1.Columns["sex"].HeaderText = "性别";
            //dataGridViewX1.Columns["phone1"].HeaderText = "电话";
            //dataGridViewX1.Columns["phone2"].HeaderText = "手机";
            //dataGridViewX1.Columns["company"].HeaderText = "公司名称";
            //dataGridViewX1.Columns["email"].HeaderText = "电子邮箱";
            //dataGridViewX1.Columns["address"].HeaderText = "家庭住址";
            //dataGridViewX1.Columns["birthday"].HeaderText = "生日";
            //dataGridViewX1.Columns["remark"].HeaderText = "备注";
            Hashtable ht = new Hashtable();
            ht.Add("姓名", "name");
            ht.Add("性别", "sexStr");
            ht.Add("电话", "phone1");
            ht.Add("手机", "phone2");
            ht.Add("公司名称", "company");
            ht.Add("电子邮箱", "email");
            ht.Add("家庭住址", "address");
            ht.Add("生日", "birthday");
            ht.Add("备注", "remark");
            //设置表格列头，和可查询字段
            foreach (DictionaryEntry item in ht)
            {
                dataGridViewX1.Columns[item.Value.ToString()].HeaderText = item.Key.ToString();
                comboBoxItem1.Items.Add(item);
            }
            comboBoxItem1.Items.Insert(0,new DictionaryEntry("全部","all"));
            comboBoxItem1.DisplayMember = "Key";
        }
        
        private void buttonItem15_Click(object sender, EventArgs e)
        {

        }

        private void labelItem2_MouseMove(object sender, MouseEventArgs e)
        {
            LabelItem lable = sender as LabelItem;
            lable.BackColor = Color.FromArgb(251, 241, 170); 
        }

        private void labelItem2_MouseLeave(object sender, EventArgs e)
        {
            LabelItem lable = sender as LabelItem;
            lable.BackColor = Color.FromArgb(221, 231, 238);           
        }

        private void labelItem2_Click(object sender, EventArgs e)
        {
            LabelItem lable = sender as LabelItem;
            buttonItem15.Text = lable.Text; 
        }

        private void maskedTextBoxAdv1_TextChanged(object sender, EventArgs e)
        {
            DictionaryEntry dicE = (DictionaryEntry)comboBoxItem1.SelectedItem;
            bindingSource1.Filter = dicE.Value + "='" + maskedTextBoxAdv1.Text+"'";
        }
    }
}
