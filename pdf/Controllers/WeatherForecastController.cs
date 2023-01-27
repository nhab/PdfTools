using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pdf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            string PdfFileSpecification = "c:\\Root\\CSharpNotesForProfessionals.pdf";
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC =index,
                Summary = pdfText(PdfFileSpecification, index) //Summaries[rng.Next(Summaries.Length)]
            });
           
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get2( int page=0)
        //{
        //    string PdfFileSpecification = "c:\\Root\\CSharpNotesForProfessionals.pdf";
        //    var rng = new Random();
        //    int num = 5;
        //    return Enumerable.Range(page*num+1, (page+1*num)).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = pdfText(PdfFileSpecification, index) //Summaries[rng.Next(Summaries.Length)]
        //    });

        //}

        private static int getpages(string path)
        {
            PdfReader reader = new PdfReader(path);
            string text = string.Empty;
            return reader.NumberOfPages;
        }
        private static string pdfText(string path,int page)
        {
            PdfReader reader = new PdfReader(path);
            string text = PdfTextExtractor.GetTextFromPage(reader, page);
            
            reader.Close();
            return text;
        }
    }
}
