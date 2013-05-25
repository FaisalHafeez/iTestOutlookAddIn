namespace HunterCV.AddIn.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PositionsStartIndex = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CandidatesStartIndex = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTablePageSize = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PhoneFormat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MobileFormat = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.MSWordPhone2WildCards = new System.Windows.Forms.TextBox();
            this.MSWordPhone1WildCards = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.MSWordMobile2WildCards = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.MSWordMobile1WildCards = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbUseProxy = new System.Windows.Forms.CheckBox();
            this.tbProxyPort = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbProxyAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelWait = new System.Windows.Forms.Panel();
            this.ajaxLoading = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelWait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ajaxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 17);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(527, 367);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PositionsStartIndex);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.CandidatesStartIndex);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tbTablePageSize);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.PhoneFormat);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.MobileFormat);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(519, 336);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PositionsStartIndex
            // 
            this.PositionsStartIndex.Location = new System.Drawing.Point(236, 222);
            this.PositionsStartIndex.Mask = "00000";
            this.PositionsStartIndex.Name = "PositionsStartIndex";
            this.PositionsStartIndex.Size = new System.Drawing.Size(75, 26);
            this.PositionsStartIndex.TabIndex = 10;
            this.PositionsStartIndex.Tag = "cloud";
            this.PositionsStartIndex.ValidatingType = typeof(int);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 222);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Openings # starts counter";
            // 
            // CandidatesStartIndex
            // 
            this.CandidatesStartIndex.Location = new System.Drawing.Point(236, 174);
            this.CandidatesStartIndex.Mask = "00000";
            this.CandidatesStartIndex.Name = "CandidatesStartIndex";
            this.CandidatesStartIndex.Size = new System.Drawing.Size(75, 26);
            this.CandidatesStartIndex.TabIndex = 8;
            this.CandidatesStartIndex.Tag = "cloud";
            this.CandidatesStartIndex.ValidatingType = typeof(int);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 177);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "Candidates # starts counter";
            // 
            // tbTablePageSize
            // 
            this.tbTablePageSize.Location = new System.Drawing.Point(236, 131);
            this.tbTablePageSize.Mask = "00";
            this.tbTablePageSize.Name = "tbTablePageSize";
            this.tbTablePageSize.Size = new System.Drawing.Size(57, 26);
            this.tbTablePageSize.TabIndex = 6;
            this.tbTablePageSize.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Table page size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Phone number display format";
            // 
            // PhoneFormat
            // 
            this.PhoneFormat.Location = new System.Drawing.Point(236, 83);
            this.PhoneFormat.Margin = new System.Windows.Forms.Padding(4);
            this.PhoneFormat.Name = "PhoneFormat";
            this.PhoneFormat.Size = new System.Drawing.Size(132, 26);
            this.PhoneFormat.TabIndex = 2;
            this.PhoneFormat.Tag = "cloud";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mobile number display format";
            // 
            // MobileFormat
            // 
            this.MobileFormat.Location = new System.Drawing.Point(236, 39);
            this.MobileFormat.Margin = new System.Windows.Forms.Padding(4);
            this.MobileFormat.Name = "MobileFormat";
            this.MobileFormat.Size = new System.Drawing.Size(132, 26);
            this.MobileFormat.TabIndex = 0;
            this.MobileFormat.Tag = "cloud";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.MSWordPhone2WildCards);
            this.tabPage3.Controls.Add(this.MSWordPhone1WildCards);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.MSWordMobile2WildCards);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.MSWordMobile1WildCards);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(519, 336);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Resume screening";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // MSWordPhone2WildCards
            // 
            this.MSWordPhone2WildCards.Location = new System.Drawing.Point(279, 166);
            this.MSWordPhone2WildCards.Margin = new System.Windows.Forms.Padding(4);
            this.MSWordPhone2WildCards.Name = "MSWordPhone2WildCards";
            this.MSWordPhone2WildCards.Size = new System.Drawing.Size(171, 26);
            this.MSWordPhone2WildCards.TabIndex = 12;
            this.MSWordPhone2WildCards.Tag = "cloud";
            // 
            // MSWordPhone1WildCards
            // 
            this.MSWordPhone1WildCards.Location = new System.Drawing.Point(279, 122);
            this.MSWordPhone1WildCards.Margin = new System.Windows.Forms.Padding(4);
            this.MSWordPhone1WildCards.Name = "MSWordPhone1WildCards";
            this.MSWordPhone1WildCards.Size = new System.Drawing.Size(171, 26);
            this.MSWordPhone1WildCards.TabIndex = 11;
            this.MSWordPhone1WildCards.Tag = "cloud";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 169);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(221, 18);
            this.label11.TabIndex = 10;
            this.label11.Text = "MS Word Phone wildcard pattern 2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 125);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(221, 18);
            this.label8.TabIndex = 9;
            this.label8.Text = "MS Word Phone wildcard pattern 1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 84);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(225, 18);
            this.label10.TabIndex = 8;
            this.label10.Text = "MS Word Mobile wildcard pattern 2";
            // 
            // MSWordMobile2WildCards
            // 
            this.MSWordMobile2WildCards.Location = new System.Drawing.Point(279, 81);
            this.MSWordMobile2WildCards.Margin = new System.Windows.Forms.Padding(4);
            this.MSWordMobile2WildCards.Name = "MSWordMobile2WildCards";
            this.MSWordMobile2WildCards.Size = new System.Drawing.Size(171, 26);
            this.MSWordMobile2WildCards.TabIndex = 6;
            this.MSWordMobile2WildCards.Tag = "cloud";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 40);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(225, 18);
            this.label9.TabIndex = 5;
            this.label9.Text = "MS Word Mobile wildcard pattern 1";
            // 
            // MSWordMobile1WildCards
            // 
            this.MSWordMobile1WildCards.Location = new System.Drawing.Point(279, 37);
            this.MSWordMobile1WildCards.Margin = new System.Windows.Forms.Padding(4);
            this.MSWordMobile1WildCards.Name = "MSWordMobile1WildCards";
            this.MSWordMobile1WildCards.Size = new System.Drawing.Size(171, 26);
            this.MSWordMobile1WildCards.TabIndex = 4;
            this.MSWordMobile1WildCards.Tag = "cloud";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbUseProxy);
            this.tabPage2.Controls.Add(this.tbProxyPort);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.tbProxyAddress);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(519, 336);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advanced";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbUseProxy
            // 
            this.cbUseProxy.AutoSize = true;
            this.cbUseProxy.Location = new System.Drawing.Point(35, 52);
            this.cbUseProxy.Name = "cbUseProxy";
            this.cbUseProxy.Size = new System.Drawing.Size(88, 22);
            this.cbUseProxy.TabIndex = 0;
            this.cbUseProxy.Text = "Use Proxy";
            this.cbUseProxy.UseVisualStyleBackColor = true;
            this.cbUseProxy.CheckedChanged += new System.EventHandler(this.cbUseProxy_CheckedChanged);
            // 
            // tbProxyPort
            // 
            this.tbProxyPort.Location = new System.Drawing.Point(281, 92);
            this.tbProxyPort.Mask = "0000";
            this.tbProxyPort.Name = "tbProxyPort";
            this.tbProxyPort.Size = new System.Drawing.Size(57, 26);
            this.tbProxyPort.TabIndex = 6;
            this.tbProxyPort.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.tbProxyPort.ValidatingType = typeof(int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 95);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Port";
            // 
            // tbProxyAddress
            // 
            this.tbProxyAddress.Location = new System.Drawing.Point(97, 92);
            this.tbProxyAddress.Name = "tbProxyAddress";
            this.tbProxyAddress.Size = new System.Drawing.Size(121, 26);
            this.tbProxyAddress.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 94);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Address";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 392);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(443, 392);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelWait
            // 
            this.panelWait.Controls.Add(this.ajaxLoading);
            this.panelWait.Location = new System.Drawing.Point(20, 392);
            this.panelWait.Margin = new System.Windows.Forms.Padding(4);
            this.panelWait.Name = "panelWait";
            this.panelWait.Size = new System.Drawing.Size(259, 33);
            this.panelWait.TabIndex = 55;
            this.panelWait.Visible = false;
            // 
            // ajaxLoading
            // 
            this.ajaxLoading.Image = ((System.Drawing.Image)(resources.GetObject("ajaxLoading.Image")));
            this.ajaxLoading.Location = new System.Drawing.Point(19, 8);
            this.ajaxLoading.Margin = new System.Windows.Forms.Padding(4);
            this.ajaxLoading.Name = "ajaxLoading";
            this.ajaxLoading.Size = new System.Drawing.Size(220, 19);
            this.ajaxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ajaxLoading.TabIndex = 25;
            this.ajaxLoading.TabStop = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 441);
            this.Controls.Add(this.panelWait);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panelWait.ResumeLayout(false);
            this.panelWait.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ajaxLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MobileFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PhoneFormat;
        private System.Windows.Forms.Panel panelWait;
        private System.Windows.Forms.PictureBox ajaxLoading;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tbTablePageSize;
        private System.Windows.Forms.CheckBox cbUseProxy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbProxyAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox tbProxyPort;
        private System.Windows.Forms.MaskedTextBox PositionsStartIndex;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox CandidatesStartIndex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox MSWordMobile2WildCards;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox MSWordMobile1WildCards;
        private System.Windows.Forms.TextBox MSWordPhone2WildCards;
        private System.Windows.Forms.TextBox MSWordPhone1WildCards;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
    }
}