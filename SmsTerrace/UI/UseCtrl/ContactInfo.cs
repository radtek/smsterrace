using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;

namespace SmsTerrace.UI.UseCtrl
{
    public partial class ContactInfo : Office2007RibbonForm
    {
        public  HzTerrace.BLL.relation relBLL = new HzTerrace.BLL.relation();
        public HzTerrace.BLL.extendInfo extBLL = new HzTerrace.BLL.extendInfo();
        HzTerrace.Model.relation nowRel;
        public bool isAdd=true;
        public ContactInfo()
        {
            InitializeComponent();
            InitializeComponentAdded(); 
        }
        public ContactInfo(HzTerrace.Model.relation entity)
        {  // ContactInfo();
            nowRel = entity;
            isAdd = false;
            InitializeComponent();
            InitializeComponentAdded(); 
        }
        private void InitializeComponentAdded()
        {
            Node node1 = new Node();
            node1.Text = @"<font color='#0072BC'><u>点击修改组别</u></font>";
            // node1.HostedControl = labelX11;
            advTree1.Nodes.Insert(0, node1);
            advTree1.Width = buttonX2.Width;
            controlContainerItem2.Control = advTree1;
            if (!isAdd)
            {
                SetNowRelation();
                InitExtView();              
            }    
        }

        private void InitExtView()
        {
            dataGridViewX1.DataSource = extBLL.GetExtendInfo(nowRel.id.Value);
           List<HzTerrace.Model.extendInfo> groupList= extBLL.GetGroupInfo(nowRel.id.Value);
           foreach (HzTerrace.Model.extendInfo item in groupList)
            {
                Node TempNode = new Node();
                TempNode.Expanded = true;
                TempNode.Name = "groupId_" + item.id;
                TempNode.Text = item.value;
                node3.Nodes.Add(TempNode);
            }

            foreach (DataGridViewColumn item in dataGridViewX1.Columns)
            {
                item.Visible = false;
            }
            // 
            // Column1
            // 
            dataGridViewX1.Columns["name"].FillWeight = 30F;
            dataGridViewX1.Columns["name"].HeaderText = "名称";
            dataGridViewX1.Columns["name"].Visible = true;
            // 
            // Column2
            // 
            dataGridViewX1.Columns["value"].HeaderText = "值";
            dataGridViewX1.Columns["value"].Visible = true;
        }

        private void SetNowRelation()
        {
            textBoxX1.Text = nowRel.name;
            comboBoxEx1.SelectedIndex = nowRel.sex ? 0 : 1;
            dateTimeInput1.Value = nowRel.birthday.GetValueOrDefault();
            textBoxX2.Text = nowRel.address;
            textBoxX3.Text = nowRel.phone1;
            textBoxX4.Text = nowRel.company;
            textBoxX5.Text = nowRel.phone2;
            textBoxX6.Text = nowRel.email;
            buttonX2.Text = nowRel.group.ToString();
            textBoxX8.Text = nowRel.remark;
        }

        private void advTree1_DoubleClick(object sender, EventArgs e)
        {
            AdvTree treeTemp = sender as AdvTree;
            buttonX2.Text = treeTemp.SelectedNode.Text;
            buttonX2.Expanded = false;
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            HzTerrace.Model.relation relModel = GetNowRelation();
            if (isAdd)
            {
                relBLL.Add(relModel);

            }
            else {
                relBLL.Update(relModel);
            }
        }

        private HzTerrace.Model.relation GetNowRelation()
        {
            string contactName = textBoxX1.Text;
            string contactSex = comboBoxEx1.SelectedText;
            DateTime contactBirthday = dateTimeInput1.Value;
            string address = textBoxX2.Text;
            string contactPhone1 = textBoxX3.Text;
            string company = textBoxX4.Text;
            string contactPhone2 = textBoxX5.Text;
            string email = textBoxX6.Text;
            string group = buttonX2.Text;
            string remark = textBoxX8.Text;
            HzTerrace.Model.relation relModel = new HzTerrace.Model.relation();
            relModel.id = nowRel.id;
            relModel.address = address;
            relModel.birthday = contactBirthday;
            relModel.company = company;
            relModel.email = email;
            relModel.group = 1;
            relModel.name = contactName;
            relModel.phone1 = contactPhone1;
            relModel.phone2 = contactPhone2;
            relModel.remark = remark;
            relModel.sex = true;
            relModel.status = 1;
            return relModel;
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            HzTerrace.Model.relation relModel = GetNowRelation();
            //extBLL.Add();
            HzTerrace.Model.extendInfo extM = new HzTerrace.Model.extendInfo();
            extM.name = "";
            extM.value = "";
            extM.sign = "group_sign";
            extM.relationId = 1;
            if (isAdd)
            {
                relBLL.Add(relModel);
            }
            else
            {
                relBLL.Update(relModel);
            }
            this.Close();
            this.Dispose();
        }
    }
}