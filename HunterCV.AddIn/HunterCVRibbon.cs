using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using HunterCV.AddIn.Forms;
using System.Windows.Forms;
using HunterCV.Common;

namespace HunterCV.AddIn
{
    public partial class HunterCVRibbon
    {
        private void InvidiaRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            WindowFormRegionCollection formRegions =
        Globals.FormRegions
            [Globals.ThisAddIn.Application.ActiveExplorer()];

            if (formRegions.MainRegion.IsRoleWorkerBusy || formRegions.MainRegion.IsCandidatesWorkerBusy)
            {
                return;
            }

            formRegions.MainRegion.DoSearch(-1, true);
        }

        private void btnManageAreas_Click(object sender, RibbonControlEventArgs e)
        {
            WindowFormRegionCollection formRegions =
        Globals.FormRegions
            [Globals.ThisAddIn.Application.ActiveExplorer()];

            if (formRegions.MainRegion.IsRoleWorkerBusy || formRegions.MainRegion.IsCandidatesWorkerBusy)
            {
                return;
            }

            if (formRegions.MainRegion.Areas != null)
            {
                ManageAreasForm frm = new ManageAreasForm(formRegions.MainRegion);
                frm.ShowDialog();
            }
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            WindowFormRegionCollection formRegions =
        Globals.FormRegions
            [Globals.ThisAddIn.Application.ActiveExplorer()];

            if (formRegions.MainRegion.IsRoleWorkerBusy || formRegions.MainRegion.IsCandidatesWorkerBusy)
            {
                return;
            }

            if (formRegions.MainRegion.Companies != null)
            {
                ManageCompaniesForm frm = new ManageCompaniesForm(formRegions.MainRegion);
                frm.ShowDialog();
            }
        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            WindowFormRegionCollection formRegions =
        Globals.FormRegions
            [Globals.ThisAddIn.Application.ActiveExplorer()];

            if (formRegions.MainRegion.IsRoleWorkerBusy || formRegions.MainRegion.IsCandidatesWorkerBusy)
            {
                return;
            }

            if (formRegions.MainRegion.Roles != null)
            {
                ManageRolesForm frm = new ManageRolesForm(formRegions.MainRegion);
                frm.ShowDialog();
            }
        }

        private void button4_Click(object sender, RibbonControlEventArgs e)
        {
            WindowFormRegionCollection formRegions =
        Globals.FormRegions
            [Globals.ThisAddIn.Application.ActiveExplorer()];

            if (formRegions.MainRegion.IsRoleWorkerBusy || formRegions.MainRegion.IsCandidatesWorkerBusy)
            {
                return;
            }

            if (formRegions.MainRegion.CandidatesStatuses != null)
            {
                ManageCandidateStatusesForm frm = new ManageCandidateStatusesForm(formRegions.MainRegion);
                frm.ShowDialog();
            }
        }

        private void button5_Click(object sender, RibbonControlEventArgs e)
        {
            AboutBox frm = new AboutBox();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, RibbonControlEventArgs e)
        {
            WindowFormRegionCollection formRegions =
        Globals.FormRegions
            [Globals.ThisAddIn.Application.ActiveExplorer()];

            if (formRegions.MainRegion.IsRoleWorkerBusy || formRegions.MainRegion.IsCandidatesWorkerBusy)
            {
                return;
            }

            MailTemplatesForm frm = new MailTemplatesForm(formRegions.MainRegion);
            frm.ShowDialog();
        }

        private void button7_Click(object sender, RibbonControlEventArgs e)
        {
            WindowFormRegionCollection formRegions =
        Globals.FormRegions
            [Globals.ThisAddIn.Application.ActiveExplorer()];

            if (formRegions.MainRegion.IsRoleWorkerBusy || formRegions.MainRegion.IsCandidatesWorkerBusy)
            {
                return;
            }

            PositionsForm frm = new PositionsForm(formRegions.MainRegion, FormOpenMode.Normal);
            frm.Show();
        }

        private void button8_Click(object sender, RibbonControlEventArgs e)
        {
            WindowFormRegionCollection formRegions =
                    Globals.FormRegions
                    [Globals.ThisAddIn.Application.ActiveExplorer()];

            if (formRegions.MainRegion.IsRoleWorkerBusy || formRegions.MainRegion.IsCandidatesWorkerBusy)
            {
                return;
            }

            int number = int.Parse(formRegions.MainRegion.Settings.Where(p => p.Key == "PositionsStartIndex").Single().Value);

            Guid guid = Guid.NewGuid();

            if (formRegions.MainRegion.Positions.Count() > 0)
            {
                while ( formRegions.MainRegion.Positions.Any( p => p.PositionNumber == number ) )
                {
                    number ++;
                }
            }

            var position = new Position
            {
                PositionNumber = number,
                PositionID = guid,
                Username = ServiceHelper.LastLogin.Username,
                IsNew = true,
                PublishedAt = DateTime.Today,
                Status = "Open"
            };

            PositionEditForm frm = new PositionEditForm(formRegions.MainRegion, position);
            frm.Show();
        }

        private void button9_Click(object sender, RibbonControlEventArgs e)
        {
            WindowFormRegionCollection formRegions =
        Globals.FormRegions
            [Globals.ThisAddIn.Application.ActiveExplorer()];

            if (formRegions.MainRegion.IsRoleWorkerBusy || formRegions.MainRegion.IsCandidatesWorkerBusy)
            {
                return;
            }

            if (formRegions.MainRegion.CandidatesStatuses != null)
            {
                ManagePositionStatusesForm frm = new ManagePositionStatusesForm(formRegions.MainRegion);
                frm.ShowDialog();
            }
        }

        private void button10_Click(object sender, RibbonControlEventArgs e)
        {
            WindowFormRegionCollection formRegions =
        Globals.FormRegions
            [Globals.ThisAddIn.Application.ActiveExplorer()];

            if (formRegions.MainRegion.IsRoleWorkerBusy)
            {
                return;
            }

            SettingsForm frm = new SettingsForm(formRegions.MainRegion);
            frm.ShowDialog();
        }

        private void button4_Click_1(object sender, RibbonControlEventArgs e)
        {
            WindowFormRegionCollection formRegions =
       Globals.FormRegions
           [Globals.ThisAddIn.Application.ActiveExplorer()];

            if (formRegions.MainRegion.IsRoleWorkerBusy || formRegions.MainRegion.IsCandidatesWorkerBusy)
            {
                return;
            }

            Guid guid = Guid.NewGuid();

            Candidate newCandidate = new Candidate();
            newCandidate.Username = ServiceHelper.LastLogin.Username;
            newCandidate.RegistrationDate = DateTime.Today;
            newCandidate.CandidateID = guid;
            newCandidate.CandidatePositions = new List<CandidatePosition>();

            newCandidate.Status = "Classification";

            CandidateEditForm form = new CandidateEditForm(true, formRegions.MainRegion, newCandidate);
            form.Show();

        }

        private void toggleButtonFavorites_Click(object sender, RibbonControlEventArgs e)
        {
            WindowFormRegionCollection formRegions =
       Globals.FormRegions
           [Globals.ThisAddIn.Application.ActiveExplorer()];

            if (formRegions.MainRegion.IsRoleWorkerBusy || formRegions.MainRegion.IsCandidatesWorkerBusy)
            {
                return;
            }

            formRegions.MainRegion.FilterFavorites = toggleButtonFavorites.Checked;
            formRegions.MainRegion.DoSearch(-1);
        }

    }
}
