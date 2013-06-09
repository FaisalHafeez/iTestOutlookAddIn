namespace HunterCV.AddIn
{
    partial class HunterCVRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public HunterCVRibbon()
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
            this.group4 = this.Factory.CreateRibbonGroup();
            this.button7 = this.Factory.CreateRibbonButton();
            this.button8 = this.Factory.CreateRibbonButton();
            this.group5 = this.Factory.CreateRibbonGroup();
            this.button4 = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.button2 = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.button6 = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.btnManageAreas = this.Factory.CreateRibbonButton();
            this.button3 = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.button5 = this.Factory.CreateRibbonButton();
            this.button10 = this.Factory.CreateRibbonButton();
            this.toggleButtonFavorites = this.Factory.CreateRibbonToggleButton();
            this.InvidiaTab.SuspendLayout();
            this.group4.SuspendLayout();
            this.group5.SuspendLayout();
            this.group2.SuspendLayout();
            this.group1.SuspendLayout();
            this.group3.SuspendLayout();
            // 
            // InvidiaTab
            // 
            this.InvidiaTab.Groups.Add(this.group4);
            this.InvidiaTab.Groups.Add(this.group5);
            this.InvidiaTab.Groups.Add(this.group2);
            this.InvidiaTab.Groups.Add(this.group1);
            this.InvidiaTab.Groups.Add(this.group3);
            this.InvidiaTab.Label = "HunterCV";
            this.InvidiaTab.Name = "InvidiaTab";
            // 
            // group4
            // 
            this.group4.Items.Add(this.button7);
            this.group4.Items.Add(this.button8);
            this.group4.Label = "Openings";
            this.group4.Name = "group4";
            // 
            // button7
            // 
            this.button7.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button7.Image = global::HunterCV.AddIn.Properties.Resources.search;
            this.button7.Label = "Search";
            this.button7.Name = "button7";
            this.button7.OfficeImageId = "CreateFormWithMultipleItems";
            this.button7.ShowImage = true;
            this.button7.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button8.Image = global::HunterCV.AddIn.Properties.Resources.add;
            this.button8.Label = "New Opening";
            this.button8.Name = "button8";
            this.button8.OfficeImageId = "AccessFormModalDialog";
            this.button8.ShowImage = true;
            this.button8.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button8_Click);
            // 
            // group5
            // 
            this.group5.Items.Add(this.button4);
            this.group5.Items.Add(this.toggleButtonFavorites);
            this.group5.Label = "Candidates";
            this.group5.Name = "group5";
            // 
            // button4
            // 
            this.button4.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button4.Image = global::HunterCV.AddIn.Properties.Resources.addcandidate;
            this.button4.Label = "New Candidate";
            this.button4.Name = "button4";
            this.button4.ShowImage = true;
            this.button4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button4_Click_1);
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
            this.button2.Image = global::HunterCV.AddIn.Properties.Resources._1370557420_system_software_update;
            this.button2.Label = "ReCloud";
            this.button2.Name = "button2";
            this.button2.OfficeImageId = "RecurrenceEdit";
            this.button2.ScreenTip = "Refresh data from the cloud";
            this.button2.ShowImage = true;
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
            // 
            // group1
            // 
            this.group1.Items.Add(this.button6);
            this.group1.Items.Add(this.button1);
            this.group1.Items.Add(this.btnManageAreas);
            this.group1.Items.Add(this.button3);
            this.group1.Label = "Management";
            this.group1.Name = "group1";
            // 
            // button6
            // 
            this.button6.Image = global::HunterCV.AddIn.Properties.Resources._1370557497_bullet_black;
            this.button6.Label = "Mail Templates";
            this.button6.Name = "button6";
            this.button6.OfficeImageId = "FilePrepareMenu";
            this.button6.ShowImage = true;
            this.button6.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.Image = global::HunterCV.AddIn.Properties.Resources._1370557497_bullet_black;
            this.button1.Label = "Companies";
            this.button1.Name = "button1";
            this.button1.OfficeImageId = "CreateTableTemplatesGallery";
            this.button1.ScreenTip = "Manage companies";
            this.button1.ShowImage = true;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // btnManageAreas
            // 
            this.btnManageAreas.Description = "Manage Areas";
            this.btnManageAreas.Image = global::HunterCV.AddIn.Properties.Resources._1370557497_bullet_black;
            this.btnManageAreas.Label = "Areas";
            this.btnManageAreas.Name = "btnManageAreas";
            this.btnManageAreas.OfficeImageId = "ReviewAcceptChange";
            this.btnManageAreas.ScreenTip = "Manage areas";
            this.btnManageAreas.ShowImage = true;
            this.btnManageAreas.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnManageAreas_Click);
            // 
            // button3
            // 
            this.button3.Image = global::HunterCV.AddIn.Properties.Resources._1370557497_bullet_black;
            this.button3.Label = "Roles";
            this.button3.Name = "button3";
            this.button3.OfficeImageId = "AccessTableContacts";
            this.button3.ScreenTip = "Manage roles";
            this.button3.ShowImage = true;
            this.button3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button3_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.button5);
            this.group3.Items.Add(this.button10);
            this.group3.Label = "HunterCV";
            this.group3.Name = "group3";
            // 
            // button5
            // 
            this.button5.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button5.Image = global::HunterCV.AddIn.Properties.Resources._1370557385_onebit_47;
            this.button5.Label = "About";
            this.button5.Name = "button5";
            this.button5.OfficeImageId = "CustomActionsMenu";
            this.button5.ShowImage = true;
            this.button5.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button5_Click);
            // 
            // button10
            // 
            this.button10.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button10.Image = global::HunterCV.AddIn.Properties.Resources._1370557093_advancedsettings;
            this.button10.Label = "Settings";
            this.button10.Name = "button10";
            this.button10.OfficeImageId = "DefinePrintStyles";
            this.button10.ShowImage = true;
            this.button10.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button10_Click);
            // 
            // toggleButtonFavorites
            // 
            this.toggleButtonFavorites.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.toggleButtonFavorites.Image = global::HunterCV.AddIn.Properties.Resources._1370556717_star1;
            this.toggleButtonFavorites.Label = "Favorites";
            this.toggleButtonFavorites.Name = "toggleButtonFavorites";
            this.toggleButtonFavorites.ShowImage = true;
            this.toggleButtonFavorites.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleButtonFavorites_Click);
            // 
            // HunterCVRibbon
            // 
            this.Name = "HunterCVRibbon";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.InvidiaTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.InvidiaRibbon_Load);
            this.InvidiaTab.ResumeLayout(false);
            this.InvidiaTab.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.group5.ResumeLayout(false);
            this.group5.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab InvidiaTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnManageAreas;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button5;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button6;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button7;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button8;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button10;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group5;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button4;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleButtonFavorites;
    }

    partial class ThisRibbonCollection
    {
        internal HunterCVRibbon InvidiaRibbon
        {
            get { return this.GetRibbon<HunterCVRibbon>(); }
        }
    }
}
