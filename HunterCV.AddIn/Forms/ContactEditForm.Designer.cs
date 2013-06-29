namespace HunterCV.AddIn.Forms
{
    partial class ContactEditForm
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
            this.components = new System.ComponentModel.Container();
            this.tbFax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPosition = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Details = new System.Windows.Forms.GroupBox();
            this.tbMobile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Remarks = new System.Windows.Forms.Label();
            this.tbRemarks = new System.Windows.Forms.TextBox();
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Details.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFax
            // 
            this.tbFax.Location = new System.Drawing.Point(94, 130);
            this.tbFax.Name = "tbFax";
            this.tbFax.Size = new System.Drawing.Size(172, 26);
            this.tbFax.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 18);
            this.label3.TabIndex = 32;
            this.label3.Text = "Fax";
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(94, 66);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(172, 26);
            this.tbPhone.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 31;
            this.label2.Text = "Phone";
            // 
            // tbPosition
            // 
            this.tbPosition.Location = new System.Drawing.Point(94, 198);
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(172, 26);
            this.tbPosition.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Position";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(94, 163);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(172, 26);
            this.tbEmail.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 18);
            this.label4.TabIndex = 29;
            this.label4.Text = "Email";
            // 
            // Details
            // 
            this.Details.Controls.Add(this.tbMobile);
            this.Details.Controls.Add(this.label6);
            this.Details.Controls.Add(this.Remarks);
            this.Details.Controls.Add(this.tbRemarks);
            this.Details.Controls.Add(this.tbFullName);
            this.Details.Controls.Add(this.label5);
            this.Details.Controls.Add(this.tbPhone);
            this.Details.Controls.Add(this.tbFax);
            this.Details.Controls.Add(this.label4);
            this.Details.Controls.Add(this.label3);
            this.Details.Controls.Add(this.tbEmail);
            this.Details.Controls.Add(this.label1);
            this.Details.Controls.Add(this.label2);
            this.Details.Controls.Add(this.tbPosition);
            this.Details.Location = new System.Drawing.Point(12, 12);
            this.Details.Name = "Details";
            this.Details.Size = new System.Drawing.Size(365, 305);
            this.Details.TabIndex = 33;
            this.Details.TabStop = false;
            this.Details.Text = "Contact details";
            // 
            // tbMobile
            // 
            this.tbMobile.Location = new System.Drawing.Point(94, 98);
            this.tbMobile.Name = "tbMobile";
            this.tbMobile.Size = new System.Drawing.Size(172, 26);
            this.tbMobile.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 18);
            this.label6.TabIndex = 38;
            this.label6.Text = "Mobile";
            // 
            // Remarks
            // 
            this.Remarks.AutoSize = true;
            this.Remarks.Location = new System.Drawing.Point(26, 236);
            this.Remarks.Name = "Remarks";
            this.Remarks.Size = new System.Drawing.Size(61, 18);
            this.Remarks.TabIndex = 36;
            this.Remarks.Text = "Remarks";
            // 
            // tbRemarks
            // 
            this.tbRemarks.Location = new System.Drawing.Point(94, 236);
            this.tbRemarks.Multiline = true;
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRemarks.Size = new System.Drawing.Size(255, 52);
            this.tbRemarks.TabIndex = 7;
            // 
            // tbFullName
            // 
            this.tbFullName.Location = new System.Drawing.Point(94, 34);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Size = new System.Drawing.Size(172, 26);
            this.tbFullName.TabIndex = 1;
            this.tbFullName.Validating += new System.ComponentModel.CancelEventHandler(this.tbFullName_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 18);
            this.label5.TabIndex = 34;
            this.label5.Text = "Full Name";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(301, 323);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 31);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(214, 323);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 31);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // ContactEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 364);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.Details);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContactEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ContactEditForm_FormClosing);
            this.Details.ResumeLayout(false);
            this.Details.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbFax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox Details;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Remarks;
        private System.Windows.Forms.TextBox tbRemarks;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbMobile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}