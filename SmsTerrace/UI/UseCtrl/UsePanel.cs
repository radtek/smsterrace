using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SmsTerrace.UI.UseCtrl
{
   public class UsePanel:Panel
    {
        Control mainControl;
        Control[] childControl;
       public  UsePanel(Control mainCtrl, params Control[] childCtrl)
        {
            mainControl = mainCtrl;
            childControl = childCtrl;
            Init();
        }
       Panel childsPanel = new Panel();
       void Init(){
           mainControl.Location = (new Point(5, 5));
           mainControl.Click += new EventHandler(mainControl_Click);
           childsPanel.AutoSize = true;
           for (int i = 0; i < childControl.Length; i++)
           {
               childsPanel.Controls.Add(childControl[i]);
               childControl[i].Location = (new Point(30, 15 * i + 15 + mainControl.Size.Height));
           }
           this.Controls.Add(mainControl);
           this.Controls.Add(childsPanel);
           this.BackColor = Color.Blue;
       }

       void mainControl_Click(object sender, EventArgs e)
       {
           childsPanel.Visible = !childsPanel.Visible;
           this.Size = new Size(0,0);
           this.Refresh();
       }
    }
}
