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
using HunterCV.Common;
using log4net;


namespace HunterCV.AddIn
{
    public partial class ReadingResumeForm : Form
    {
        public static readonly ILog Logger =
                LogManager.GetLogger(typeof(MainRegion));

        public Dictionary<String,String> ReadingResult { get; set; }
        private MainRegion m_region;
        private bool m_previewOnly = false;
        private Resume m_resume = null;

        public ReadingResumeForm(MainRegion region, Resume resume)
        {
            InitializeComponent();
            m_region = region;
            ReadingResult = new Dictionary<string, string>();

            m_resume = resume;
        }


        public ReadingResumeForm(MainRegion region, Resume resume, bool previewOnly)
        {
            InitializeComponent();
            m_region = region;
            ReadingResult = new Dictionary<string, string>();

            m_previewOnly = previewOnly;
            m_resume = resume;
        }

        private void readingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void readingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string fileName = null;

                //cloudy document
                if (m_resume.IsCloudy)
                {
                    var getBytesWorker = new BackgroundWorker();

                    getBytesWorker.RunWorkerCompleted += (senders, es) =>
                    {
                        fileName = Path.Combine(System.IO.Path.GetTempPath(), m_resume.FileName);
                        System.IO.File.WriteAllBytes(fileName, (byte[])es.Result);

                        ScreeningDocument(fileName);
                    };

                    getBytesWorker.DoWork += (senders, es) =>
                    {
                        es.Result = ServiceHelper.GetResumeContent(m_resume.ResumeID);
                    };

                    getBytesWorker.RunWorkerAsync();

                }
                else
                {
                    ScreeningDocument(m_resume.FileName);
                }
            }
            catch
            {
                CrossThreadUtility.InvokeControlAction<ReadingResumeForm>(this, f => f.Close());
            }
        }

        private void ScreeningDocument(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);

            try
            {
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

                            //Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                            if (MainRegion.WordApplication != null)
                            {

                                Object name = fileName;
                                Object confirmConversions = false;

                                Microsoft.Office.Interop.Word.Document doc = MainRegion.WordApplication.Documents.Open(
                                    ref name, ref confirmConversions,
                                    ref objMissing, ref objMissing, ref objMissing, ref objMissing,
                                    ref objMissing, ref objMissing, ref objMissing, ref objMissing,
                                    ref objMissing, ref objMissing, ref objMissing, ref objMissing,
                                    ref objMissing, ref objMissing
                                );

                                if (Properties.Settings.Default.AddMSCompanyLogo &&
                                    !string.IsNullOrEmpty(Properties.Settings.Default.MSLogoFilePath) &&
                                    File.Exists(Properties.Settings.Default.MSLogoFilePath))
                                {
                                    foreach (Microsoft.Office.Interop.Word.Section wordSection in doc.Content.Sections)
                                    {
                                        wordSection.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage]
                                            .Range.InlineShapes.AddPicture(Properties.Settings.Default.MSLogoFilePath);
                                    }
                                }

                                doc.Save();

                                if (!m_previewOnly)
                                {

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
                                }

                                FileInfo htmlFile = new FileInfo(fileName.ToLower().Replace(new FileInfo(fileName).Extension, ".html"));

                                object oFileName = (object)htmlFile.FullName;

                                object oFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatHTML;
                                object oCompatibilityMode = Microsoft.Office.Interop.Word.WdCompatibilityMode.wdWord2007;//.wdFormatHTML;

                                doc.SaveAs2(ref oFileName, ref oFormat, ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing,
                                ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing);

                                doc.Close(objMissing, objMissing, objMissing);
                                //app.Quit(ref objMissing, ref objMissing, ref objMissing);

                                this.ReadingResult.Add("HtmlPreviewFileName", htmlFile.FullName);

                                doc = null;
                                //GC.Collect(); // force final cleanup!
                                //GC.WaitForPendingFinalizers();
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Fatal(m_resume, ex);
            }
            finally
            {
                CrossThreadUtility.InvokeControlAction<ReadingResumeForm>(this, f => f.Close());
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
