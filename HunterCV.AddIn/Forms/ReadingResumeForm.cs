using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


namespace HunterCV.AddIn
{
    public partial class ReadingResumeForm : Form
    {
        private string m_filePath;

        public Dictionary<String,String> ReadingResult { get; set; }
        private MainRegion m_region;

        public ReadingResumeForm(MainRegion region, string filePath)
        {
            InitializeComponent();
            m_region = region;
            ReadingResult = new Dictionary<string, string>();

            m_filePath = filePath;
        }

        private void readingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private void readingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                FileInfo fi = new FileInfo(m_filePath);

                if (fi.Exists)
                {
                    switch (fi.Extension)
                    {
                        //case ".pdf":
                        //    PDFParser parser = new PDFParser();

                        //    string pdfContent;

                        //    bool extracted = parser.ExtractText(m_filePath, out pdfContent);

                        //    if (extracted && !string.IsNullOrEmpty( pdfContent.Trim()) )
                        //    {
                        //        this.ReadingResult.Add("Content", pdfContent);
                        //        this.ReadingResult.Add("Mobile1", GetPDFRegularExpression(pdfContent.Replace(" ",""), @"0(5[012345678]|6[47]){1}(\s)?(\-)?(\s)?[^0\D]{1}\d{6}"));
                        //        this.ReadingResult.Add("Phone1", GetPDFRegularExpression(pdfContent.Replace(" ", ""), @"0(5[012345678]|6[47]){1}(\s)?(\-)?(\s)?[^0\D]{1}\d{6}"));
                        //    }

                        //    break;
                        case ".doc":
                        case ".docx":
                        case ".rtf":
                            Object objMissing = Type.Missing;
                            Object objTrue = true;
                            Object objFalse = true;

                            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();

                            Object name = m_filePath;
                            Object confirmConversions = false;

                            Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(
                                ref name, ref confirmConversions,
                                ref objMissing, ref objMissing, ref objMissing, ref objMissing,
                                ref objMissing, ref objMissing, ref objMissing, ref objMissing,
                                ref objMissing, ref objMissing, ref objMissing, ref objMissing,
                                ref objMissing, ref objMissing
                            );

                            this.ReadingResult.Add("Content", doc.Content.Text);

                            if (!string.IsNullOrEmpty(m_region.Settings.Where(p => p.Key == "MSWordMobile1WildCards").Single().Value))
                            {
                                this.ReadingResult.Add("MSWordMobile1WildCards", GetMSWordWildCard(doc, "<" + m_region.Settings.Where(p => p.Key == "MSWordMobile1WildCards").Single().Value + ">"));
                            }

                            if (!string.IsNullOrEmpty(m_region.Settings.Where(p => p.Key == "MSWordMobile2WildCards").Single().Value))
                            {
                                this.ReadingResult.Add("MSWordMobile2WildCards", GetMSWordWildCard(doc, "<" + m_region.Settings.Where(p => p.Key == "MSWordMobile2WildCards").Single().Value + ">"));
                            }

                            if (!string.IsNullOrEmpty(m_region.Settings.Where(p => p.Key == "MSWordPhone1WildCards").Single().Value))
                            {
                                this.ReadingResult.Add("MSWordPhone1WildCards", GetMSWordWildCard(doc, "<" + m_region.Settings.Where(p => p.Key == "MSWordPhone1WildCards").Single().Value + ">"));
                            }

                            if (!string.IsNullOrEmpty(m_region.Settings.Where(p => p.Key == "MSWordPhone2WildCards").Single().Value))
                            {
                                this.ReadingResult.Add("MSWordPhone2WildCards", GetMSWordWildCard(doc, "<" + m_region.Settings.Where(p => p.Key == "MSWordPhone2WildCards").Single().Value + ">"));
                            }

                            doc.Close(objMissing, objMissing, objMissing);
                            app.Quit(ref objMissing, ref objMissing, ref objMissing);

                            doc = null;
                            GC.Collect(); // force final cleanup!
                            GC.WaitForPendingFinalizers();
                            break;
                    }
                }
            }
            catch
            {

            }
        }

        private string GetPDFRegularExpression(string pdfContent, string regex)
        {
            Regex reg = new Regex(regex);

            if (reg.Match(pdfContent).Success)
            {
                return reg.Match(pdfContent).Value;
            }
            else
            {
                return string.Empty;
            }
        }

        private string GetMSWordWildCard(Microsoft.Office.Interop.Word.Document doc, string wildCrads)
        {
            Object objMissing = Type.Missing;
            Microsoft.Office.Interop.Word.Range rng = doc.Content;
            rng.Find.ClearFormatting();

            object ofindstop = Microsoft.Office.Interop.Word.WdFindWrap.wdFindStop;

            rng.Application.Selection.Find.Text = wildCrads;
            rng.Application.Selection.Find.Forward = true;  //even if i keep this n the next 2 lines commented, there is no change

            rng.Application.Selection.Find.MatchWildcards = true;

            rng.Application.Selection.Find.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindStop;

            bool isFound = rng.Application.Selection.Find.Execute(ref objMissing, ref objMissing, ref objMissing,
                ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing,
                ref objMissing, ref objMissing);

            if (isFound)
            {
                return rng.Application.Selection.Text;
            }
            else
            {
                return string.Empty;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            readingWorker.RunWorkerAsync();
        }

        private void ReadingResumeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
