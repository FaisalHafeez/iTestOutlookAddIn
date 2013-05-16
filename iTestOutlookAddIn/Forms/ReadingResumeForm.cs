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


namespace iTestOutlookAddIn
{
    public partial class ReadingResumeForm : Form
    {
        private string m_filePath;

        public Dictionary<String,String> ReadingResult { get; set; }

        public ReadingResumeForm(string filePath)
        {
            InitializeComponent();

            ReadingResult = new Dictionary<string, string>();

            m_filePath = filePath;
        }

        private void readingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private void readingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            FileInfo fi = new FileInfo(m_filePath);

            if (fi.Exists)
            {
                switch (fi.Extension)
                {
                    case ".pdf":
                        PDFParser parser = new PDFParser();

                        string pdfContent;

                        bool extracted = parser.ExtractText(m_filePath, out pdfContent);

                        if (extracted && !string.IsNullOrEmpty( pdfContent.Trim()) )
                        {
                            this.ReadingResult.Add("Content", pdfContent);
                            this.ReadingResult.Add("Mobile1", GetPDFRegularExpression(pdfContent.Replace(" ",""), @"0(5[012345678]|6[47]){1}(\s)?(\-)?(\s)?[^0\D]{1}\d{6}"));
                            this.ReadingResult.Add("Phone1", GetPDFRegularExpression(pdfContent.Replace(" ", ""), @"0(5[012345678]|6[47]){1}(\s)?(\-)?(\s)?[^0\D]{1}\d{6}"));
                        }

                        break;
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
                        this.ReadingResult.Add("Mobile1", GetMSWordWildCard(doc, "<[0-9][5][0-9]-[0-9]{7}>"));
                        this.ReadingResult.Add("Mobile2", GetMSWordWildCard(doc, "<[0-9][5][0-9][0-9]{7}>"));
                        this.ReadingResult.Add("Phone1", GetMSWordWildCard(doc, "<[0-9]{2}-[0-9]{7}>"));

                        app.Quit(ref objMissing, ref objMissing, ref objMissing);
                        break;
                }
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
