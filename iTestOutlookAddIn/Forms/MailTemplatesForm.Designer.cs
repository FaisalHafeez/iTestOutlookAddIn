namespace iTestOutlookAddIn.Forms
{
    partial class MailTemplatesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailTemplatesForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbIncludeAttachments = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbrFont = new System.Windows.Forms.ToolStripButton();
            this.tspColor = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbrLeft = new System.Windows.Forms.ToolStripButton();
            this.tbrCenter = new System.Windows.Forms.ToolStripButton();
            this.tbrRight = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbrBold = new System.Windows.Forms.ToolStripButton();
            this.tbrItalic = new System.Windows.Forms.ToolStripButton();
            this.tbrUnderline = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.rtbDoc = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.FontDialog1 = new System.Windows.Forms.FontDialog();
            this.panelWait = new System.Windows.Forms.Panel();
            this.lblWaitStatus = new System.Windows.Forms.Label();
            this.ajaxLoading = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.panelWait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ajaxLoading)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbIncludeAttachments);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbTitle);
            this.groupBox1.Controls.Add(this.ToolStrip1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbSubject);
            this.groupBox1.Controls.Add(this.rtbDoc);
            this.groupBox1.Location = new System.Drawing.Point(246, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 398);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Template properties";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cbIncludeAttachments
            // 
            this.cbIncludeAttachments.AutoSize = true;
            this.cbIncludeAttachments.Location = new System.Drawing.Point(96, 88);
            this.cbIncludeAttachments.Name = "cbIncludeAttachments";
            this.cbIncludeAttachments.Size = new System.Drawing.Size(139, 17);
            this.cbIncludeAttachments.TabIndex = 8;
            this.cbIncludeAttachments.Text = "Include CV attachments";
            this.cbIncludeAttachments.UseVisualStyleBackColor = true;
            this.cbIncludeAttachments.CheckedChanged += new System.EventHandler(this.cbIncludeAttachments_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(93, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(443, 46);
            this.label4.TabIndex = 7;
            this.label4.Text = "* - You can use special reserved expressions as : {FIRSTNAME}, {LASTNAME}, {EMAIL" +
    "}, {PHONE}, {MOBILE} and {CANDIDATENUMBER} which will be replaced with candidate" +
    " details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Template Title :";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(96, 29);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(181, 20);
            this.tbTitle.TabIndex = 5;
            this.tbTitle.TextChanged += new System.EventHandler(this.tbTitle_TextChanged);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbrFont,
            this.tspColor,
            this.ToolStripSeparator4,
            this.tbrLeft,
            this.tbrCenter,
            this.tbrRight,
            this.ToolStripSeparator2,
            this.tbrBold,
            this.tbrItalic,
            this.tbrUnderline});
            this.ToolStrip1.Location = new System.Drawing.Point(96, 117);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(208, 25);
            this.ToolStrip1.TabIndex = 4;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // tbrFont
            // 
            this.tbrFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrFont.Image = ((System.Drawing.Image)(resources.GetObject("tbrFont.Image")));
            this.tbrFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrFont.Name = "tbrFont";
            this.tbrFont.Size = new System.Drawing.Size(23, 22);
            this.tbrFont.Text = "Font";
            this.tbrFont.Click += new System.EventHandler(this.tbrFont_Click);
            // 
            // tspColor
            // 
            this.tspColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tspColor.Image = ((System.Drawing.Image)(resources.GetObject("tspColor.Image")));
            this.tspColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspColor.Name = "tspColor";
            this.tspColor.Size = new System.Drawing.Size(23, 22);
            this.tspColor.Text = "toolStripButton1";
            this.tspColor.Click += new System.EventHandler(this.tspColor_Click);
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tbrLeft
            // 
            this.tbrLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrLeft.Image = ((System.Drawing.Image)(resources.GetObject("tbrLeft.Image")));
            this.tbrLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrLeft.Name = "tbrLeft";
            this.tbrLeft.Size = new System.Drawing.Size(23, 22);
            this.tbrLeft.Text = "Left";
            this.tbrLeft.Click += new System.EventHandler(this.tbrLeft_Click);
            // 
            // tbrCenter
            // 
            this.tbrCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrCenter.Image = ((System.Drawing.Image)(resources.GetObject("tbrCenter.Image")));
            this.tbrCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrCenter.Name = "tbrCenter";
            this.tbrCenter.Size = new System.Drawing.Size(23, 22);
            this.tbrCenter.Text = "Center";
            this.tbrCenter.Click += new System.EventHandler(this.tbrCenter_Click);
            // 
            // tbrRight
            // 
            this.tbrRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrRight.Image = ((System.Drawing.Image)(resources.GetObject("tbrRight.Image")));
            this.tbrRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrRight.Name = "tbrRight";
            this.tbrRight.Size = new System.Drawing.Size(23, 22);
            this.tbrRight.Text = "Right";
            this.tbrRight.Click += new System.EventHandler(this.tbrRight_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbrBold
            // 
            this.tbrBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrBold.Image = ((System.Drawing.Image)(resources.GetObject("tbrBold.Image")));
            this.tbrBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrBold.Name = "tbrBold";
            this.tbrBold.Size = new System.Drawing.Size(23, 22);
            this.tbrBold.Text = "Bold";
            this.tbrBold.Click += new System.EventHandler(this.tbrBold_Click);
            // 
            // tbrItalic
            // 
            this.tbrItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrItalic.Image = ((System.Drawing.Image)(resources.GetObject("tbrItalic.Image")));
            this.tbrItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrItalic.Name = "tbrItalic";
            this.tbrItalic.Size = new System.Drawing.Size(23, 22);
            this.tbrItalic.Text = "Italic";
            this.tbrItalic.Click += new System.EventHandler(this.tbrItalic_Click);
            // 
            // tbrUnderline
            // 
            this.tbrUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbrUnderline.Image = ((System.Drawing.Image)(resources.GetObject("tbrUnderline.Image")));
            this.tbrUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrUnderline.Name = "tbrUnderline";
            this.tbrUnderline.Size = new System.Drawing.Size(23, 22);
            this.tbrUnderline.Text = "Underline";
            this.tbrUnderline.Click += new System.EventHandler(this.tbrUnderline_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mail Body * :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mail Subject :";
            // 
            // tbSubject
            // 
            this.tbSubject.Location = new System.Drawing.Point(96, 55);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(440, 20);
            this.tbSubject.TabIndex = 1;
            this.tbSubject.TextChanged += new System.EventHandler(this.tbSubject_TextChanged);
            // 
            // rtbDoc
            // 
            this.rtbDoc.Location = new System.Drawing.Point(96, 145);
            this.rtbDoc.Name = "rtbDoc";
            this.rtbDoc.Size = new System.Drawing.Size(440, 190);
            this.rtbDoc.TabIndex = 0;
            this.rtbDoc.Text = "";
            this.rtbDoc.TextChanged += new System.EventHandler(this.rtbDoc_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(607, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save and Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(725, 420);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panelWait
            // 
            this.panelWait.Controls.Add(this.lblWaitStatus);
            this.panelWait.Controls.Add(this.ajaxLoading);
            this.panelWait.Location = new System.Drawing.Point(246, 421);
            this.panelWait.Name = "panelWait";
            this.panelWait.Size = new System.Drawing.Size(194, 24);
            this.panelWait.TabIndex = 54;
            this.panelWait.Visible = false;
            // 
            // lblWaitStatus
            // 
            this.lblWaitStatus.AutoSize = true;
            this.lblWaitStatus.Location = new System.Drawing.Point(27, 6);
            this.lblWaitStatus.Margin = new System.Windows.Forms.Padding(5, 7, 3, 0);
            this.lblWaitStatus.Name = "lblWaitStatus";
            this.lblWaitStatus.Size = new System.Drawing.Size(69, 13);
            this.lblWaitStatus.TabIndex = 23;
            this.lblWaitStatus.Text = "please wait...";
            // 
            // ajaxLoading
            // 
            this.ajaxLoading.Image = ((System.Drawing.Image)(resources.GetObject("ajaxLoading.Image")));
            this.ajaxLoading.Location = new System.Drawing.Point(3, 3);
            this.ajaxLoading.Name = "ajaxLoading";
            this.ajaxLoading.Size = new System.Drawing.Size(16, 16);
            this.ajaxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ajaxLoading.TabIndex = 22;
            this.ajaxLoading.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 401);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Exists Templates";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(136, 222);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(14, 222);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "New Template";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(14, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(197, 186);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // MailTemplatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(812, 451);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panelWait);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MailTemplatesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Mail Templates";
            this.Load += new System.EventHandler(this.MailTemplate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.panelWait.ResumeLayout(false);
            this.panelWait.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ajaxLoading)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.RichTextBox rtbDoc;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton tbrFont;
        private System.Windows.Forms.ToolStripButton tspColor;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        internal System.Windows.Forms.ToolStripButton tbrLeft;
        internal System.Windows.Forms.ToolStripButton tbrCenter;
        internal System.Windows.Forms.ToolStripButton tbrRight;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton tbrBold;
        internal System.Windows.Forms.ToolStripButton tbrItalic;
        internal System.Windows.Forms.ToolStripButton tbrUnderline;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog FontDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelWait;
        private System.Windows.Forms.Label lblWaitStatus;
        private System.Windows.Forms.PictureBox ajaxLoading;
        private System.Windows.Forms.CheckBox cbIncludeAttachments;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
    }
}