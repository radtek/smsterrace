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
        public ContactInfo()
        {
            InitializeComponent();
           AdvTree groupTree= new AdvTree();
           Node node=new Node();
           node.Text = "点击修改组别";
           Node node1 = new Node();
           node1.Text = @"<font color='#0072BC'><u>点击修改组别</u></font>";
           Node node2 = new Node();
           node2.Text = "t3";

           Node node6 = new Node();
           node6.Expanded = true;
           node6.Name = "node6";
           node6.Text = "node6";

           groupTree.Nodes.Add(node);
           groupTree.Nodes.Add(node1);
           groupTree.Nodes.Add(node6);
           advTree1.Nodes.Insert(0,node1);
           advTree1.Width = buttonX2.Width;
           controlContainerItem2.Control = advTree1;
           
        }

        private void advTree1_DoubleClick(object sender, EventArgs e)
        {
           AdvTree treeTemp= sender as AdvTree;
           buttonX2.Text = treeTemp.SelectedNode.Text;
            buttonX2.Expanded = false;
        }
    }
}