using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

namespace pdf_win.Utils
{
    public class PDFPigUtils
    {
        public static string ReadPdfTexts(string pdfPath)
        {
            StringBuilder sb = new StringBuilder();
            using (var pdf = PdfDocument.Open(pdfPath))
            {
                foreach (var page in pdf.GetPages())
                {
                    // Either extract based on order in the underlying document with newlines and spaces.
                    var text = ContentOrderTextExtractor.GetText(page);

                  
                    // Or the raw text of the page's content stream.
                    // string rawText = page.Text;
                    
                    sb.Append(text);
                    sb.Append('\n');
                }
            }
            return sb.ToString();
        }
    }
}
