namespace HunterCV.AddIn
{
    partial class ManageCompaniesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageCompaniesForm));
            this.tvCompanies = new System.Windows.Forms.TreeView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.updateWorker = new System.ComponentModel.BackgroundWorker();
            this.panelWait = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbCommision = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIdentity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRemoveContact = new System.Windows.Forms.Button();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.dgContacts = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbResumeDescription = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnRemoveResume = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnSaveResume = new System.Windows.Forms.Button();
            this.dataGridViewCV = new System.Windows.Forms.DataGridView();
            this.tbRemarks = new System.Windows.Forms.TextBox();
            this.Remarks = new System.Windows.Forms.Label();
            this.ajaxLoading = new System.Windows.Forms.PictureBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panelWait.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgContacts)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajaxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // tvCompanies
            // 
            this.tvCompanies.AllowDrop = true;
            this.tvCompanies.FullRowSelect = true;
            this.tvCompanies.HideSelection = false;
            this.tvCompanies.LabelEdit = true;
            this.tvCompanies.Location = new System.Drawing.Point(16, 54);
            this.tvCompanies.Margin = new System.Windows.Forms.Padding(4);
            this.tvCompanies.Name = "tvCompanies";
            this.tvCompanies.Size = new System.Drawing.Size(185, 326);
            this.tvCompanies.TabIndex = 35;
            this.tvCompanies.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvCompanies_ItemDrag);
            this.tvCompanies.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCompanies_AfterSelect);
            this.tvCompanies.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvCompanies_DragDrop);
            this.tvCompanies.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvCompanies_DragEnter);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(350, 394);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 34);
            this.btnClose.TabIndex = 36;
            this.btnClose.Text = "Save And Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(501, 394);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 34);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(16, 21);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(93, 25);
            this.toolStrip1.TabIndex = 41;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // updateWorker
            // 
            this.updateWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateWorker_DoWork);
            this.updateWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.updateWorker_RunWorkerCompleted);
            // 
            // panelWait
            // 
            this.panelWait.Controls.Add(this.ajaxLoading);
            this.panelWait.Location = new System.Drawing.Point(16, 395);
            this.panelWait.Margin = new System.Windows.Forms.Padding(4);
            this.panelWait.Name = "panelWait";
            this.panelWait.Size = new System.Drawing.Size(235, 33);
            this.panelWait.TabIndex = 42;
            this.panelWait.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(208, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(381, 326);
            this.tabControl1.TabIndex = 44;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Remarks);
            this.tabPage1.Controls.Add(this.tbRemarks);
            this.tabPage1.Controls.Add(this.tbCommision);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tbFax);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbPhone);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbIdentity);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbEmail);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(373, 294);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Company information";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbCommision
            // 
            this.tbCommision.Location = new System.Drawing.Point(112, 159);
            this.tbCommision.Name = "tbCommision";
            this.tbCommision.Size = new System.Drawing.Size(57, 27);
            this.tbCommision.TabIndex = 5;
            this.tbCommision.TextChanged += new System.EventHandler(this.tbCommision_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 19);
            this.label5.TabIndex = 26;
            this.label5.Text = "% Commison";
            // 
            // tbFax
            // 
            this.tbFax.Location = new System.Drawing.Point(112, 93);
            this.tbFax.Name = "tbFax";
            this.tbFax.Size = new System.Drawing.Size(172, 27);
            this.tbFax.TabIndex = 3;
            this.tbFax.TextChanged += new System.EventHandler(this.tbFax_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 19);
            this.label3.TabIndex = 24;
            this.label3.Text = "Fax";
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(112, 60);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(172, 27);
            this.tbPhone.TabIndex = 2;
            this.tbPhone.TextChanged += new System.EventHandler(this.tbPhone_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "Phone";
            // 
            // tbIdentity
            // 
            this.tbIdentity.Location = new System.Drawing.Point(112, 27);
            this.tbIdentity.Name = "tbIdentity";
            this.tbIdentity.Size = new System.Drawing.Size(172, 27);
            this.tbIdentity.TabIndex = 1;
            this.tbIdentity.TextChanged += new System.EventHandler(this.tbIdentity_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "Identity";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(112, 126);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(172, 27);
            this.tbEmail.TabIndex = 4;
            this.tbEmail.TextChanged += new System.EventHandler(this.tbEmail_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 19);
            this.label4.TabIndex = 18;
            this.label4.Text = "Email";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRemoveContact);
            this.tabPage2.Controls.Add(this.btnAddContact);
            this.tabPage2.Controls.Add(this.dgContacts);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(373, 294);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Contacts";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRemoveContact
            // 
            this.btnRemoveContact.Enabled = false;
            this.btnRemoveContact.Location = new System.Drawing.Point(177, 211);
            this.btnRemoveContact.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveContact.Name = "btnRemoveContact";
            this.btnRemoveContact.Size = new System.Drawing.Size(84, 34);
            this.btnRemoveContact.TabIndex = 39;
            this.btnRemoveContact.Text = "Remove";
            this.btnRemoveContact.UseVisualStyleBackColor = true;
            this.btnRemoveContact.Click += new System.EventHandler(this.btnRemoveContact_Click);
            // 
            // btnAddContact
            // 
            this.btnAddContact.Location = new System.Drawing.Point(26, 211);
            this.btnAddContact.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(143, 34);
            this.btnAddContact.TabIndex = 38;
            this.btnAddContact.Text = "Add Contact";
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // dgContacts
            // 
            this.dgContacts.AllowUserToAddRows = false;
            this.dgContacts.AllowUserToDeleteRows = false;
            this.dgContacts.AllowUserToResizeRows = false;
            this.dgContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgContacts.Location = new System.Drawing.Point(26, 23);
            this.dgContacts.Name = "dgContacts";
            this.dgContacts.ReadOnly = true;
            this.dgContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgContacts.Size = new System.Drawing.Size(313, 181);
            this.dgContacts.TabIndex = 0;
            this.dgContacts.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgContacts_CellContentDoubleClick);
            this.dgContacts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgContacts_CellDoubleClick);
            this.dgContacts.SelectionChanged += new System.EventHandler(this.dgContacts_SelectionChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbResumeDescription);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.btnRemoveResume);
            this.tabPage3.Controls.Add(this.btnUpload);
            this.tabPage3.Controls.Add(this.btnSaveResume);
            this.tabPage3.Controls.Add(this.dataGridViewCV);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(373, 294);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Documents";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbResumeDescription
            // 
            this.tbResumeDescription.Enabled = false;
            this.tbResumeDescription.Location = new System.Drawing.Point(191, 51);
            this.tbResumeDescription.Margin = new System.Windows.Forms.Padding(4);
            this.tbResumeDescription.Multiline = true;
            this.tbResumeDescription.Name = "tbResumeDescription";
            this.tbResumeDescription.Size = new System.Drawing.Size(145, 59);
            this.tbResumeDescription.TabIndex = 65;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Enabled = false;
            this.label17.Location = new System.Drawing.Point(191, 23);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 19);
            this.label17.TabIndex = 63;
            this.label17.Text = "Description :";
            // 
            // btnRemoveResume
            // 
            this.btnRemoveResume.Enabled = false;
            this.btnRemoveResume.Location = new System.Drawing.Point(95, 184);
            this.btnRemoveResume.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveResume.Name = "btnRemoveResume";
            this.btnRemoveResume.Size = new System.Drawing.Size(88, 32);
            this.btnRemoveResume.TabIndex = 67;
            this.btnRemoveResume.Text = "Remove";
            this.btnRemoveResume.UseVisualStyleBackColor = true;
            // 
            // btnUpload
            // 
            this.btnUpload.Enabled = false;
            this.btnUpload.Location = new System.Drawing.Point(19, 184);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(68, 32);
            this.btnUpload.TabIndex = 62;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            // 
            // btnSaveResume
            // 
            this.btnSaveResume.Enabled = false;
            this.btnSaveResume.Location = new System.Drawing.Point(236, 118);
            this.btnSaveResume.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveResume.Name = "btnSaveResume";
            this.btnSaveResume.Size = new System.Drawing.Size(100, 32);
            this.btnSaveResume.TabIndex = 66;
            this.btnSaveResume.Text = "Save";
            this.btnSaveResume.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCV
            // 
            this.dataGridViewCV.AllowDrop = true;
            this.dataGridViewCV.AllowUserToAddRows = false;
            this.dataGridViewCV.AllowUserToDeleteRows = false;
            this.dataGridViewCV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewCV.Enabled = false;
            this.dataGridViewCV.Location = new System.Drawing.Point(19, 23);
            this.dataGridViewCV.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewCV.Name = "dataGridViewCV";
            this.dataGridViewCV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCV.ShowEditingIcon = false;
            this.dataGridViewCV.Size = new System.Drawing.Size(164, 153);
            this.dataGridViewCV.TabIndex = 64;
            // 
            // tbRemarks
            // 
            this.tbRemarks.Location = new System.Drawing.Point(112, 192);
            this.tbRemarks.Multiline = true;
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRemarks.Size = new System.Drawing.Size(255, 84);
            this.tbRemarks.TabIndex = 6;
            this.tbRemarks.TextChanged += new System.EventHandler(this.tbRemarks_TextChanged);
            // 
            // Remarks
            // 
            this.Remarks.AutoSize = true;
            this.Remarks.Location = new System.Drawing.Point(33, 192);
            this.Remarks.Name = "Remarks";
            this.Remarks.Size = new System.Drawing.Size(65, 19);
            this.Remarks.TabIndex = 29;
            this.Remarks.Text = "Remarks";
            // 
            // ajaxLoading
            // 
            this.ajaxLoading.Image = ((System.Drawing.Image)(resources.GetObject("ajaxLoading.Image")));
            this.ajaxLoading.Location = new System.Drawing.Point(11, 8);
            this.ajaxLoading.Margin = new System.Windows.Forms.Padding(4);
            this.ajaxLoading.Name = "ajaxLoading";
            this.ajaxLoading.Size = new System.Drawing.Size(220, 19);
            this.ajaxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ajaxLoading.TabIndex = 25;
            this.ajaxLoading.TabStop = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Delete";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "New company";
            this.toolStripButton2.ToolTipText = "New company";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "Edit";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // ManageCompaniesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 441);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelWait);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tvCompanies);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageCompaniesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Companies";
            this.Load += new System.EventHandler(this.ManageCompaniesForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelWait.ResumeLayout(false);
            this.panelWait.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgContacts)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ajaxLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvCompanies;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.ComponentModel.BackgroundWorker updateWorker;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panelWait;
        private System.Windows.Forms.PictureBox ajaxLoading;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbCommision;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbIdentity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnRemoveContact;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.DataGridView dgContacts;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tbResumeDescription;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnRemoveResume;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnSaveResume;
        private System.Windows.Forms.DataGridView dataGridViewCV;
        private System.Windows.Forms.Label Remarks;
        private System.Windows.Forms.TextBox tbRemarks;
    }
}