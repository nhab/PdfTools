using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using System.IO;
using pdf_win.Utils;

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
      
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();

            pdffilepath = openFileDialog1.FileName;
            reader = new PdfReader(pdffilepath);
            pageCount = reader.NumberOfPages;
            string s= TextSharpUtils.pdfText(reader ,page);
            //Summaries[rng.Next(Summaries.Length)]

            string sHtml = "<pre>"+s+"</pre>";// "<h2 style='textalign=:center;' >Hello</h2>";
            webBrowser = new WebBrowser();
            BrowserUtils.CreateBrowser(ref webBrowser, this.Width, this.Height, 40);
             this.Controls.Add(webBrowser);
            BrowserUtils.ShowInBrowser(webBrowser, sHtml);
         
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (page > pageCount) return;
            string s = TextSharpUtils.pdfText(reader, ++page);

            BrowserUtils.ShowInBrowser(webBrowser,s);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (page <= 1) return;
               
            string s = TextSharpUtils.pdfText(reader, --page);
            BrowserUtils.ShowInBrowser(webBrowser,s);
        }
    }
}