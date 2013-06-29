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
    public partial class ContactEditForm : Form
    {
        private Contact m_contact = null;

        public Contact Entity
        {
            get
            {
                return m_contact;
            }
        }

        private bool ValidateFullName()
        {
            bool bStatus = true;
            if (tbFullName.Text.Trim() == "")
            {
                errorProvider1.SetError(tbFullName, "Please enter full name");
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(tbFullName, "");
            }
            return bStatus;
        }

        public ContactEditForm(Contact contact)
        {
            InitializeComponent();

            m_contact = contact;

            this.tbFullName.DataBindings.Add("Text", m_contact, "FullName", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbPhone.DataBindings.Add("Text", m_contact, "Phone", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbMobile.DataBindings.Add("Text", m_contact, "Mobile", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbFax.DataBindings.Add("Text", m_contact, "Fax", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbEmail.DataBindings.Add("Text", m_contact, "Email", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbPosition.DataBindings.Add("Text", m_contact, "Position", false, DataSourceUpdateMode.OnPropertyChanged);
            this.tbRemarks.DataBindings.Add("Text", m_contact, "Remarks", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool blValidFullName = ValidateFullName();

            if (!blValidFullName)
            {
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbFullName_Validating(object sender, CancelEventArgs e)
        {
            ValidateFullName();
        }

        private void ContactEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (!ValidateFullName())
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
