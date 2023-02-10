
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf_win.Utils
{
    public class TextSharpUtils
    {

        public static int getpages(string path)
        {
            PdfReader reader = new PdfReader(path);

            string text = string.Empty;
            return reader.NumberOfPages;
        }
        public static string pdfText(PdfReader reader, int page)
        {
            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
            string text = PdfTextExtractor.GetTextFromPage(reader, page, strategy);

            return text;
        }

        public static string ParsePdf(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("fileName");
            using (PdfReader reader = new PdfReader(fileName))
            {
                StringBuilder sb = new StringBuilder();

                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                for (int page = 0; page < reader.NumberOfPages; page++)
                {
                    string text = PdfTextExtractor.GetTextFromPage(reader, page + 1, strategy);
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        sb.Append(Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text))));
                    }
                }

                return sb.ToString();
            }
        }
        public static string ExtractTextFromPdf(string path)
        {
            using (PdfReader reader = new PdfReader(path))
            {
                StringBuilder text = new StringBuilder();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }

                return text.ToString();
            }
        }
    }
}

