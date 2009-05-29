using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace hz.Processor
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            MmsCreate mmc = new MmsCreate();
            this.Controls.Add(mmc);
        }
    }
}