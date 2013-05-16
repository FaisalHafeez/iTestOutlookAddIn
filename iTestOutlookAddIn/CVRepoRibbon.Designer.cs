namespace iTestOutlookAddIn
{
    partial class CVRepoRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public CVRepoRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InvidiaTab = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnManageAreas = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.button3 = this.Factory.CreateRibbonButton();
            this.button4 = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.button2 = this.Factory.CreateRibbonButton();
            this.InvidiaTab.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            // 
            // InvidiaTab
            // 
            this.InvidiaTab.Groups.Add(this.group1);
            this.InvidiaTab.Groups.Add(this.group2);
            this.InvidiaTab.Label = "CVRepo";
            this.InvidiaTab.Name = "InvidiaTab";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnManageAreas);
            this.group1.Items.Add(this.button1);
            this.group1.Items.Add(this.button3);
            this.group1.Items.Add(this.button4);
            this.group1.Label = "Management";
            this.group1.Name = "group1";
            // 
            // btnManageAreas
            // 
            this.btnManageAreas.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnManageAreas.Description = "Manage Areas";
            this.btnManageAreas.Label = "Manage Areas";
            this.btnManageAreas.Name = "btnManageAreas";
            this.btnManageAreas.OfficeImageId = "ReviewAcceptChange";
            this.btnManageAreas.ScreenTip = "Manage areas";
            this.btnManageAreas.ShowImage = true;
            this.btnManageAreas.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnManageAreas_Click);
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Label = "Manage Companies";
            this.button1.Name = "button1";
            this.button1.OfficeImageId = "CreateTableTemplatesGallery";
            this.button1.ScreenTip = "Manage companies";
            this.button1.ShowImage = true;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button3.Label = "Manage Roles";
            this.button3.Name = "button3";
            this.button3.OfficeImageId = "AccessTableContacts";
            this.button3.ScreenTip = "Manage roles";
            this.button3.ShowImage = true;
            this.button3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button4.Label = "Manage Statuses";
            this.button4.Name = "button4";
            this.button4.OfficeImageId = "CopyToPersonalContacts";
            this.button4.ScreenTip = "Manage statuses";
            this.button4.ShowImage = true;
            this.button4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button4_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.button2);
            this.group2.Label = "Data";
            this.group2.Name = "group2";
            // 
            // button2
            // 
            this.button2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button2.Label = "Refresh";
            this.button2.Name = "button2";
            this.button2.OfficeImageId = "TableSharePointListsRefreshList";
            this.button2.ShowImage = true;
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
            // 
            // CVRepoRibbon
            // 
            this.Name = "CVRepoRibbon";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.InvidiaTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.InvidiaRibbon_Load);
            this.InvidiaTab.ResumeLayout(false);
            this.InvidiaTab.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab InvidiaTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnManageAreas;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button4;
    }

    partial class ThisRibbonCollection
    {
        internal CVRepoRibbon InvidiaRibbon
        {
            get { return this.GetRibbon<CVRepoRibbon>(); }
        }
    }
}
