namespace SmsTerrace.UI.UseCtrl
{
    partial class UserControl2
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(22, 19);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "查询余额";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Location = new System.Drawing.Point(375, 50);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(100, 21);
            this.textBoxX1.TabIndex = 1;
            this.textBoxX1.Visible = false;
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(375, 19);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "labelX1";
            this.labelX1.Visible = false;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(127, 19);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.TabIndex = 3;
            this.buttonX2.Text = "发送统计";
            this.buttonX2.Visible = false;
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(254, 94);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(75, 23);
            this.buttonX3.TabIndex = 4;
            this.buttonX3.Text = "提交密码";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // textBoxX2
            // 
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Location = new System.Drawing.Point(127, 63);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.PasswordChar = '*';
            this.textBoxX2.Size = new System.Drawing.Size(100, 21);
            this.textBoxX2.TabIndex = 6;
            // 
            // textBoxX3
            // 
            // 
            // 
            // 
            this.textBoxX3.Border.Class = "TextBoxBorder";
            this.textBoxX3.Location = new System.Drawing.Point(127, 94);
            this.textBoxX3.Name = "textBoxX3";
            this.textBoxX3.PasswordChar = '*';
            this.textBoxX3.Size = new System.Drawing.Size(100, 21);
            this.textBoxX3.TabIndex = 7;
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(29, 63);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "重设密码:";
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(29, 94);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 9;
            this.labelX3.Text = "确认密码:";
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Location = new System.Drawing.Point(3, 32);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(96, 23);
            this.buttonX4.TabIndex = 10;
            this.buttonX4.Text = "清空发送记录";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX5.Location = new System.Drawing.Point(128, 32);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(97, 23);
            this.buttonX5.TabIndex = 11;
            this.buttonX5.Text = "清空接收记录";
            this.buttonX5.Click += new System.EventHandler(this.buttonX5_Click);
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(3, 3);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 12;
            this.labelX4.Text = "系统操作";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonX5);
            this.panel1.Controls.Add(this.labelX4);
            this.panel1.Controls.Add(this.buttonX4);
            this.panel1.Location = new System.Drawing.Point(29, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 86);
            this.panel1.TabIndex = 13;
            this.panel1.Visible = false;
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.textBoxX3);
            this.Controls.Add(this.textBoxX2);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.buttonX1);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(478, 358);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.Panel panel1;
    }
}
