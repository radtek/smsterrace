﻿using System;
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
        HzTerrace.Model.relation nowRel;
        public bool isAdd=true;
        public ContactInfo()
        {
            InitializeComponent();
            InitializeComponentAdded(); 
        }
        public ContactInfo(HzTerrace.Model.relation entity)
        {
            nowRel = entity;
            isAdd = false;
            ContactInfo();
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
            }
        }

        private void SetNowRelation()
        {
            textBoxX1.Text = nowRel.name;
            comboBoxEx1.SelectedText = nowRel.sex ? "男" : "女";
            dateTimeInput1.Value = nowRel.birthday;
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
            relBLL.Add(relModel);
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

        }
    }
}