namespace HunterCV.AddIn
{
    partial class ManagePositionStatusesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagePositionStatusesForm));
            this.tvStatuses = new System.Windows.Forms.TreeView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.updateWorker = new System.ComponentModel.BackgroundWorker();
            this.panelWait = new System.Windows.Forms.Panel();
            this.ajaxLoading = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.panelWait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ajaxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // tvStatuses
            // 
            this.tvStatuses.AllowDrop = true;
            this.tvStatuses.FullRowSelect = true;
            this.tvStatuses.HideSelection = false;
            this.tvStatuses.LabelEdit = true;
            this.tvStatuses.Location = new System.Drawing.Point(16, 54);
            this.tvStatuses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tvStatuses.Name = "tvStatuses";
            this.tvStatuses.Size = new System.Drawing.Size(405, 326);
            this.tvStatuses.TabIndex = 35;
            this.tvStatuses.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvStatuses_ItemDrag);
            this.tvStatuses.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvStatuses_DragDrop);
            this.tvStatuses.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvStatuses_DragEnter);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(188, 390);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 34);
            this.btnClose.TabIndex = 36;
            this.btnClose.Text = "Save And Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(339, 390);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.toolStrip1.Location = new System.Drawing.Point(16, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(93, 25);
            this.toolStrip1.TabIndex = 41;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.ToolTipText = "New status";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // updateWorker
            // 
            this.updateWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateWorker_DoWork);
            this.updateWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.updateWorker_RunWorkerCompleted);
            // 
            // panelWait
            // 
            this.panelWait.Controls.Add(this.ajaxLoading);
            this.panelWait.Location = new System.Drawing.Point(191, 17);
            this.panelWait.Margin = new System.Windows.Forms.Padding(4);
            this.panelWait.Name = "panelWait";
            this.panelWait.Size = new System.Drawing.Size(235, 33);
            this.panelWait.TabIndex = 42;
            this.panelWait.Visible = false;
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
            // ManagePositionStatusesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 441);
            this.Controls.Add(this.panelWait);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tvStatuses);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManagePositionStatusesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Position Statuses";
            this.Load += new System.EventHandler(this.ManageStatusesForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelWait.ResumeLayout(false);
            this.panelWait.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ajaxLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvStatuses;
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
    }
}