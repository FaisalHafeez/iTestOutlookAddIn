using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HunterCV.AddIn.Forms
{
    public partial class PreviewPaneForm : Form
    {
        public PreviewPaneForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.ShowPreviewPaneNote = false;
                Properties.Settings.Default.Save();
            }

            this.Close();
        }
    }
}
