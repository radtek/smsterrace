using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SmsTerrace.UI
{
    public partial class FirstFrm : DevComponents.DotNetBar.Office2007Form
    {
        public FirstFrm()
        {
            InitializeComponent();
        }
        SmsFrm firFrm;
        public FirstFrm(SmsFrm chFrm)
        {
           firFrm= chFrm;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            SmsTerrace.UI.SmsFrm f = new SmsTerrace.UI.SmsFrm();
            f.Show();
            f.Disposed += new EventHandler(f_Disposed);
            this.Visible=false;
        }

        void f_Disposed(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}