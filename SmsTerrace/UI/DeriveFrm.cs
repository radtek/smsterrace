using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SmsTerrace.UI.UseCtrl;

namespace SmsTerrace.UI
{
    public partial class DeriveFrm : Office2007RibbonForm
    {
       public OperFilePanel ofp= new OperFilePanel();
        public DeriveFrm()
        {
            InitializeComponent();
           
           ofp.Size = new Size(597,360);
            this.ribbonPanel1.Controls.Add(ofp);
            this.Text = "号码导入";

            ofp.SelectedTable += new OperFilePanel.SelectCol(ofp_SelectedTable);
        }

        void ofp_SelectedTable(DataTable dt)
        {
           DoWorkEventArgs dw= new DoWorkEventArgs(dt);          
            DataSelectEnd(this,dw);
        }

       public event DoWorkEventHandler DataSelectEnd;
    }
}