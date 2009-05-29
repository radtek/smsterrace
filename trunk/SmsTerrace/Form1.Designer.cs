namespace SmsTerrace
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.navigationPane1 = new DevComponents.DotNetBar.NavigationPane();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel1 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel2 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.buttonItem8 = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel3 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite5 = new DevComponents.DotNetBar.DockSite();
            this.dockSite6 = new DevComponents.DotNetBar.DockSite();
            this.dockSite7 = new DevComponents.DotNetBar.DockSite();
            this.dockSite8 = new DevComponents.DotNetBar.DockSite();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.dockContainerItem1 = new DevComponents.DotNetBar.DockContainerItem();
            this.panelDockContainer1 = new DevComponents.DotNetBar.PanelDockContainer();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.textBoxItem1 = new DevComponents.DotNetBar.TextBoxItem();
            this.panel1.SuspendLayout();
            this.navigationPane1.SuspendLayout();
            this.dockSite2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.bar1.SuspendLayout();
            this.panelDockContainer1.SuspendLayout();
            this.ribbonClientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(12, 12);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "buttonX1";
            this.buttonX1.Click += new System.EventHandler(this.bar1_ItemClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 157);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            this.panel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel1_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(15, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(15, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 425);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(788, 10);
            this.hScrollBar1.TabIndex = 5;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // navigationPane1
            // 
            this.navigationPane1.Controls.Add(this.navigationPanePanel1);
            this.navigationPane1.Controls.Add(this.navigationPanePanel2);
            this.navigationPane1.Controls.Add(this.navigationPanePanel3);
            this.navigationPane1.ItemPaddingBottom = 2;
            this.navigationPane1.ItemPaddingTop = 2;
            this.navigationPane1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem6,
            this.buttonItem7,
            this.buttonItem8});
            this.navigationPane1.Location = new System.Drawing.Point(13, 37);
            this.navigationPane1.Name = "navigationPane1";
            this.navigationPane1.Padding = new System.Windows.Forms.Padding(1);
            this.navigationPane1.Size = new System.Drawing.Size(150, 294);
            this.navigationPane1.TabIndex = 8;
            // 
            // 
            // 
            this.navigationPane1.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationPane1.TitlePanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navigationPane1.TitlePanel.Location = new System.Drawing.Point(1, 1);
            this.navigationPane1.TitlePanel.Name = "panelTitle";
            this.navigationPane1.TitlePanel.Size = new System.Drawing.Size(148, 24);
            this.navigationPane1.TitlePanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.navigationPane1.TitlePanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.navigationPane1.TitlePanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPane1.TitlePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPane1.TitlePanel.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
            this.navigationPane1.TitlePanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.navigationPane1.TitlePanel.Style.GradientAngle = 90;
            this.navigationPane1.TitlePanel.Style.MarginLeft = 4;
            this.navigationPane1.TitlePanel.TabIndex = 0;
            this.navigationPane1.TitlePanel.Text = "buttonItem6";
            // 
            // buttonItem6
            // 
            this.buttonItem6.Checked = true;
            this.buttonItem6.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem6.Image")));
            this.buttonItem6.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.buttonItem6.ImagePaddingHorizontal = 8;
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.OptionGroup = "navBar";
            this.buttonItem6.Text = "buttonItem6";
            // 
            // navigationPanePanel1
            // 
            this.navigationPanePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel1.Location = new System.Drawing.Point(1, 25);
            this.navigationPanePanel1.Name = "navigationPanePanel1";
            this.navigationPanePanel1.ParentItem = this.buttonItem6;
            this.navigationPanePanel1.Size = new System.Drawing.Size(148, 236);
            this.navigationPanePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.navigationPanePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.navigationPanePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel1.Style.GradientAngle = 90;
            this.navigationPanePanel1.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel1.StyleMouseDown.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.navigationPanePanel1.StyleMouseDown.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.navigationPanePanel1.StyleMouseDown.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.navigationPanePanel1.StyleMouseDown.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedText;
            this.navigationPanePanel1.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel1.StyleMouseOver.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground;
            this.navigationPanePanel1.StyleMouseOver.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground2;
            this.navigationPanePanel1.StyleMouseOver.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBorder;
            this.navigationPanePanel1.StyleMouseOver.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotText;
            this.navigationPanePanel1.TabIndex = 2;
            // 
            // buttonItem7
            // 
            this.buttonItem7.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem7.Image")));
            this.buttonItem7.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.buttonItem7.ImagePaddingHorizontal = 8;
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.OptionGroup = "navBar";
            this.buttonItem7.Text = "buttonItem7";
            // 
            // navigationPanePanel2
            // 
            this.navigationPanePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel2.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel2.Name = "navigationPanePanel2";
            this.navigationPanePanel2.ParentItem = this.buttonItem7;
            this.navigationPanePanel2.Size = new System.Drawing.Size(148, 292);
            this.navigationPanePanel2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.navigationPanePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel2.Style.GradientAngle = 90;
            this.navigationPanePanel2.TabIndex = 3;
            // 
            // buttonItem8
            // 
            this.buttonItem8.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem8.Image")));
            this.buttonItem8.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.buttonItem8.ImagePaddingHorizontal = 8;
            this.buttonItem8.Name = "buttonItem8";
            this.buttonItem8.OptionGroup = "navBar";
            this.buttonItem8.Text = "buttonItem8";
            // 
            // navigationPanePanel3
            // 
            this.navigationPanePanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel3.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel3.Name = "navigationPanePanel3";
            this.navigationPanePanel3.ParentItem = this.buttonItem8;
            this.navigationPanePanel3.Size = new System.Drawing.Size(148, 292);
            this.navigationPanePanel3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.navigationPanePanel3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel3.Style.GradientAngle = 90;
            this.navigationPanePanel3.TabIndex = 4;
            // 
            // dotNetBarManager1
            // 
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins);
            this.dotNetBarManager1.BottomDockSite = this.dockSite4;
            this.dotNetBarManager1.DefinitionName = "";
            this.dotNetBarManager1.EnableFullSizeDock = false;
            this.dotNetBarManager1.LeftDockSite = this.dockSite1;
            this.dotNetBarManager1.ParentForm = this;
            this.dotNetBarManager1.RightDockSite = this.dockSite2;
            this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.dotNetBarManager1.ToolbarBottomDockSite = this.dockSite8;
            this.dotNetBarManager1.ToolbarLeftDockSite = this.dockSite5;
            this.dotNetBarManager1.ToolbarRightDockSite = this.dockSite6;
            this.dotNetBarManager1.ToolbarTopDockSite = this.dockSite7;
            this.dotNetBarManager1.TopDockSite = this.dockSite3;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 425);
            this.dockSite1.TabIndex = 9;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Controls.Add(this.bar1);
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer(new DevComponents.DotNetBar.DocumentBaseContainer[] {
            ((DevComponents.DotNetBar.DocumentBaseContainer)(new DevComponents.DotNetBar.DocumentBarContainer(this.bar1, 239, 425)))}, DevComponents.DotNetBar.eOrientation.Horizontal);
            this.dockSite2.Location = new System.Drawing.Point(546, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(242, 425);
            this.dockSite2.TabIndex = 10;
            this.dockSite2.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(788, 0);
            this.dockSite3.TabIndex = 11;
            this.dockSite3.TabStop = false;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite4.Location = new System.Drawing.Point(0, 435);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(788, 0);
            this.dockSite4.TabIndex = 12;
            this.dockSite4.TabStop = false;
            // 
            // dockSite5
            // 
            this.dockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite5.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite5.Location = new System.Drawing.Point(0, 0);
            this.dockSite5.Name = "dockSite5";
            this.dockSite5.Size = new System.Drawing.Size(0, 435);
            this.dockSite5.TabIndex = 13;
            this.dockSite5.TabStop = false;
            // 
            // dockSite6
            // 
            this.dockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite6.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite6.Location = new System.Drawing.Point(788, 0);
            this.dockSite6.Name = "dockSite6";
            this.dockSite6.Size = new System.Drawing.Size(0, 435);
            this.dockSite6.TabIndex = 14;
            this.dockSite6.TabStop = false;
            // 
            // dockSite7
            // 
            this.dockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite7.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite7.Location = new System.Drawing.Point(0, 0);
            this.dockSite7.Name = "dockSite7";
            this.dockSite7.Size = new System.Drawing.Size(788, 0);
            this.dockSite7.TabIndex = 15;
            this.dockSite7.TabStop = false;
            // 
            // dockSite8
            // 
            this.dockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite8.Location = new System.Drawing.Point(0, 435);
            this.dockSite8.Name = "dockSite8";
            this.dockSite8.Size = new System.Drawing.Size(788, 0);
            this.dockSite8.TabIndex = 16;
            this.dockSite8.TabStop = false;
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "DotNetBar Bar (bar1)";
            this.bar1.AccessibleName = "DotNetBar Bar";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar1.AutoSyncBarCaption = true;
            this.bar1.CloseSingleTab = true;
            this.bar1.Controls.Add(this.panelDockContainer1);
            this.bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.dockContainerItem1});
            this.bar1.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer;
            this.bar1.Location = new System.Drawing.Point(3, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(239, 425);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "dockContainerItem1";
            // 
            // dockContainerItem1
            // 
            this.dockContainerItem1.Control = this.panelDockContainer1;
            this.dockContainerItem1.Name = "dockContainerItem1";
            this.dockContainerItem1.Text = "dockContainerItem1";
            // 
            // panelDockContainer1
            // 
            this.panelDockContainer1.Controls.Add(this.navigationPane1);
            this.panelDockContainer1.Location = new System.Drawing.Point(3, 23);
            this.panelDockContainer1.Name = "panelDockContainer1";
            this.panelDockContainer1.Size = new System.Drawing.Size(233, 399);
            this.panelDockContainer1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDockContainer1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelDockContainer1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.panelDockContainer1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelDockContainer1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelDockContainer1.Style.GradientAngle = 90;
            this.panelDockContainer1.TabIndex = 0;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.itemContainer1});
            this.ribbonBar1.Location = new System.Drawing.Point(13, 28);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(75, 23);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBar1.TabIndex = 17;
            this.ribbonBar1.Text = "ribbonBar1";
            // 
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonClientPanel1.Location = new System.Drawing.Point(282, 117);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.Size = new System.Drawing.Size(200, 100);
            // 
            // 
            // 
            this.ribbonClientPanel1.Style.Class = "RibbonClientPanel";
            this.ribbonClientPanel1.TabIndex = 18;
            this.ribbonClientPanel1.Text = "ribbonClientPanel1";
            // 
            // buttonItem1
            // 
            this.buttonItem1.ImagePaddingHorizontal = 8;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.textBoxItem1});
            this.buttonItem1.SubItemsExpandWidth = 14;
            this.buttonItem1.Text = "buttonItem1";
            // 
            // itemContainer1
            // 
            this.itemContainer1.Name = "itemContainer1";
            // 
            // textBoxItem1
            // 
            this.textBoxItem1.Caption = "textBoxItem1";
            this.textBoxItem1.Name = "textBoxItem1";
            this.textBoxItem1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 435);
            this.Controls.Add(this.ribbonClientPanel1);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.dockSite3);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite5);
            this.Controls.Add(this.dockSite6);
            this.Controls.Add(this.dockSite7);
            this.Controls.Add(this.dockSite8);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.navigationPane1.ResumeLayout(false);
            this.dockSite2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.bar1.ResumeLayout(false);
            this.panelDockContainer1.ResumeLayout(false);
            this.ribbonClientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private DevComponents.DotNetBar.NavigationPane navigationPane1;
        private DevComponents.DotNetBar.NavigationPanePanel navigationPanePanel1;
        private DevComponents.DotNetBar.ButtonItem buttonItem6;
        private DevComponents.DotNetBar.NavigationPanePanel navigationPanePanel2;
        private DevComponents.DotNetBar.ButtonItem buttonItem7;
        private DevComponents.DotNetBar.NavigationPanePanel navigationPanePanel3;
        private DevComponents.DotNetBar.ButtonItem buttonItem8;
        private DevComponents.DotNetBar.DotNetBarManager dotNetBarManager1;
        private DevComponents.DotNetBar.DockSite dockSite4;
        private DevComponents.DotNetBar.DockSite dockSite1;
        private DevComponents.DotNetBar.DockSite dockSite2;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.PanelDockContainer panelDockContainer1;
        private DevComponents.DotNetBar.DockContainerItem dockContainerItem1;
        private DevComponents.DotNetBar.DockSite dockSite3;
        private DevComponents.DotNetBar.DockSite dockSite5;
        private DevComponents.DotNetBar.DockSite dockSite6;
        private DevComponents.DotNetBar.DockSite dockSite7;
        private DevComponents.DotNetBar.DockSite dockSite8;
        private DevComponents.DotNetBar.Ribbon.RibbonClientPanel ribbonClientPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.TextBoxItem textBoxItem1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;

    }
}

