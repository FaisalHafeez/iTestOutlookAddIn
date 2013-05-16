using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace iTestOutlookAddIn
{
    public partial class CVRepoRibbon
    {
        private void InvidiaRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            WindowFormRegionCollection formRegions =
        Globals.FormRegions
            [Globals.ThisAddIn.Application.ActiveExplorer()];
            formRegions.MainRegion.DoSearch(-1, true);
        }

        private void btnManageAreas_Click(object sender, RibbonControlEventArgs e)
        {
            WindowFormRegionCollection formRegions =
        Globals.FormRegions
            [Globals.ThisAddIn.Application.ActiveExplorer()];

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

            if (formRegions.MainRegion.Statuses != null)
            {
                ManageStatusesForm frm = new ManageStatusesForm(formRegions.MainRegion);
                frm.ShowDialog();
            }
        }
    }
}
