using iTextSharp.text.pdf;
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
         
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            f.OpenPdf(pdffilepath);
            string outFile = pdffilepath.Substring(0, pdffilepath.LastIndexOf("\\"));
            outFile+= pdffilepath.Substring( pdffilepath.LastIndexOf("\\"), pdffilepath.LastIndexOf(".")- pdffilepath.LastIndexOf("\\")-1) + ".html";
            f.ToHtml(outFile);

           
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