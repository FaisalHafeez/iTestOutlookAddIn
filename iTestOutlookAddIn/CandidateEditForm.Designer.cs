namespace iTestOutlookAddIn
{
    partial class CandidateEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.rtbEvents = new System.Windows.Forms.RichTextBox();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbExperience = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbFormer8200 = new System.Windows.Forms.CheckBox();
            this.Status = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbEMailAddress = new System.Windows.Forms.TextBox();
            this.mtbPhone = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.tvAreas = new System.Windows.Forms.TreeView();
            this.mtbMobile = new System.Windows.Forms.MaskedTextBox();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbJoiningDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbIdentity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tvSentToCompanies = new System.Windows.Forms.TreeView();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cbReference = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(171, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "New Candidate";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(450, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(531, 416);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(117, 292);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Add Event";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // rtbEvents
            // 
            this.rtbEvents.Location = new System.Drawing.Point(117, 185);
            this.rtbEvents.Name = "rtbEvents";
            this.rtbEvents.Size = new System.Drawing.Size(427, 101);
            this.rtbEvents.TabIndex = 11;
            this.rtbEvents.Text = "";
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Checked = true;
            this.cbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsActive.Location = new System.Drawing.Point(98, 297);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(106, 17);
            this.cbIsActive.TabIndex = 16;
            this.cbIsActive.Text = "Active candidate";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(19, 47);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(587, 356);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.cbReference);
            this.tabPage1.Controls.Add(this.cbExperience);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.cbFormer8200);
            this.tabPage1.Controls.Add(this.Status);
            this.tabPage1.Controls.Add(this.cbStatus);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.tbEMailAddress);
            this.tabPage1.Controls.Add(this.mtbPhone);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbRole);
            this.tabPage1.Controls.Add(this.tvAreas);
            this.tabPage1.Controls.Add(this.mtbMobile);
            this.tabPage1.Controls.Add(this.dtpDOB);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.cbIsActive);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tbJoiningDate);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbIdentity);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbLastName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbFirstName);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(579, 330);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // cbExperience
            // 
            this.cbExperience.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExperience.FormattingEnabled = true;
            this.cbExperience.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cbExperience.Location = new System.Drawing.Point(334, 17);
            this.cbExperience.Name = "cbExperience";
            this.cbExperience.Size = new System.Drawing.Size(57, 21);
            this.cbExperience.TabIndex = 46;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(236, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 13);
            this.label13.TabIndex = 45;
            this.label13.Text = "Year’s experience";
            // 
            // cbFormer8200
            // 
            this.cbFormer8200.AutoSize = true;
            this.cbFormer8200.Checked = true;
            this.cbFormer8200.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFormer8200.Location = new System.Drawing.Point(332, 297);
            this.cbFormer8200.Name = "cbFormer8200";
            this.cbFormer8200.Size = new System.Drawing.Size(110, 17);
            this.cbFormer8200.TabIndex = 44;
            this.cbFormer8200.Text = "Former 8200 Unit ";
            this.cbFormer8200.UseVisualStyleBackColor = true;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(41, 260);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(43, 13);
            this.Status.TabIndex = 43;
            this.Status.Text = "Status";
            // 
            // cbStatus
            // 
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(98, 257);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(192, 26);
            this.cbStatus.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Email Address";
            // 
            // tbEMailAddress
            // 
            this.tbEMailAddress.Location = new System.Drawing.Point(98, 222);
            this.tbEMailAddress.Name = "tbEMailAddress";
            this.tbEMailAddress.Size = new System.Drawing.Size(192, 20);
            this.tbEMailAddress.TabIndex = 40;
            // 
            // mtbPhone
            // 
            this.mtbPhone.Location = new System.Drawing.Point(98, 156);
            this.mtbPhone.Mask = "(99) 000-0000";
            this.mtbPhone.Name = "mtbPhone";
            this.mtbPhone.Size = new System.Drawing.Size(108, 20);
            this.mtbPhone.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(41, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Phone";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(292, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Areas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Role";
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(98, 189);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(108, 21);
            this.cbRole.TabIndex = 35;
            // 
            // tvAreas
            // 
            this.tvAreas.CheckBoxes = true;
            this.tvAreas.FullRowSelect = true;
            this.tvAreas.Location = new System.Drawing.Point(332, 126);
            this.tvAreas.Name = "tvAreas";
            this.tvAreas.Size = new System.Drawing.Size(203, 157);
            this.tvAreas.TabIndex = 34;
            this.tvAreas.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.tvAreas.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvAreas_AfterSelect);
            // 
            // mtbMobile
            // 
            this.mtbMobile.Location = new System.Drawing.Point(98, 126);
            this.mtbMobile.Mask = "(999) 000-0000";
            this.mtbMobile.Name = "mtbMobile";
            this.mtbMobile.Size = new System.Drawing.Size(108, 20);
            this.mtbMobile.TabIndex = 33;
            // 
            // dtpDOB
            // 
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOB.Location = new System.Drawing.Point(98, 93);
            this.dtpDOB.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(108, 20);
            this.dtpDOB.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Mobile";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Date of birth";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Joining Date";
            // 
            // tbJoiningDate
            // 
            this.tbJoiningDate.Location = new System.Drawing.Point(334, 54);
            this.tbJoiningDate.Name = "tbJoiningDate";
            this.tbJoiningDate.ReadOnly = true;
            this.tbJoiningDate.Size = new System.Drawing.Size(125, 20);
            this.tbJoiningDate.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "ID";
            // 
            // tbIdentity
            // 
            this.tbIdentity.Location = new System.Drawing.Point(427, 19);
            this.tbIdentity.Name = "tbIdentity";
            this.tbIdentity.Size = new System.Drawing.Size(108, 20);
            this.tbIdentity.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Last Name";
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(98, 51);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(108, 20);
            this.tbLastName.TabIndex = 21;
            this.tbLastName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbLastName_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "First Name";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(98, 15);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(108, 20);
            this.tbFirstName.TabIndex = 19;
            this.tbFirstName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbFirstName_KeyUp);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.rtbEvents);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.tvSentToCompanies);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(579, 330);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Companies";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(71, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "Events";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Sent to Companies";
            // 
            // tvSentToCompanies
            // 
            this.tvSentToCompanies.CheckBoxes = true;
            this.tvSentToCompanies.FullRowSelect = true;
            this.tvSentToCompanies.Location = new System.Drawing.Point(117, 17);
            this.tvSentToCompanies.Name = "tvSentToCompanies";
            this.tvSentToCompanies.Size = new System.Drawing.Size(181, 162);
            this.tvSentToCompanies.TabIndex = 38;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(20, 416);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(130, 13);
            this.linkLabel1.TabIndex = 31;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Click here to open resume";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(320, 416);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(124, 23);
            this.button4.TabIndex = 32;
            this.button4.Text = "Create Mail Message";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(203, 416);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(111, 23);
            this.button5.TabIndex = 33;
            this.button5.Text = "Delete Candidate";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(271, 93);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 48;
            this.label14.Text = "Reference";
            // 
            // cbReference
            // 
            this.cbReference.FormattingEnabled = true;
            this.cbReference.Items.AddRange(new object[] {
            "Facebook",
            "LinkedIn",
            "iTest Web Site",
            "Friends",
            "Ads"});
            this.cbReference.Location = new System.Drawing.Point(334, 90);
            this.cbReference.Name = "cbReference";
            this.cbReference.Size = new System.Drawing.Size(125, 21);
            this.cbReference.TabIndex = 47;
            // 
            // CandidateEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 451);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.linkLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CandidateEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Candidate";
            this.Load += new System.EventHandler(this.CandidateEditForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox rtbEvents;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbJoiningDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbIdentity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.MaskedTextBox mtbMobile;
        private System.Windows.Forms.TreeView tvAreas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox mtbPhone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbEMailAddress;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.CheckBox cbFormer8200;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TreeView tvSentToCompanies;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbExperience;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbReference;
    }
}