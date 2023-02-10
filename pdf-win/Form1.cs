using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using System.IO;

namespace pdf_win
{
    public partial class Form1 : Form
    {
        string pdffilepath;
        int page = 1,pageCount;
        PdfReader reader;
        WebBrowser webBrowser;

        public Form1()
        {
            InitializeComponent();
        }
        private static int getpages(string path)
        {
            PdfReader reader = new PdfReader(path);
            string text = string.Empty;
            return reader.NumberOfPages;
        }
        private static string pdfText(PdfReader reader , int page)
        {
            string text = PdfTextExtractor.GetTextFromPage(reader, page);

            return  text;
        }
        void ShowInBrowser(WebBrowser webBrowser,string sHtml){
            webBrowser.DocumentText = sHtml;
            //webBrowser.Navigate(new Uri("https://www.google.com"));        
        }
        void CreateBrowser(WebBrowser webBrowser )
        {    
            webBrowser.Top = 40;
            webBrowser.Left = 0;

            webBrowser.Width = this.Width-10;
            webBrowser.Height = this.Height-webBrowser.Top;
            webBrowser.Anchor = AnchorStyles.Left | AnchorStyles.Right | 
                AnchorStyles.Bottom | AnchorStyles.Top;
            //  webBrowser.Width = this.Width;
            
            this.Controls.Add(webBrowser);
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();

            pdffilepath = openFileDialog1.FileName;
            reader = new PdfReader(pdffilepath);
            pageCount = reader.NumberOfPages;
            string s=pdfText(reader ,page);
            //Summaries[rng.Next(Summaries.Length)]

            string sHtml = "<pre>"+s+"</pre>";// "<h2 style='textalign=:center;' >Hello</h2>";
            webBrowser = new WebBrowser();
            CreateBrowser(webBrowser);
            ShowInBrowser(webBrowser, sHtml);
         
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (page > pageCount) return;
            string s = pdfText(reader, ++page);
           
            ShowInBrowser(webBrowser,s);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (page <= 1) return;
               
            string s = pdfText(reader, --page);
            ShowInBrowser(webBrowser,s);
        }
    }
}