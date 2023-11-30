using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace RTE_Import_Export.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleDataController : ControllerBase
    {
        private IWebHostEnvironment hostingEnv;

        public SampleDataController(IWebHostEnvironment env)
        {
            this.hostingEnv = env;
        }

        [HttpPost]
        [Route("Import")]
        public void Import(IFormFile UploadFiles)
        {
            if (UploadFiles != null)
            {
                string htmlString;

                using (StreamReader sr = new StreamReader(UploadFiles.OpenReadStream()))
                {
                    htmlString = sr.ReadToEnd();
                }

                string extract = ExtractBodyContent(htmlString);

                string sanitizeString = SanitizeHtmlString(extract);

                Response.Headers.Add("rtevalue", sanitizeString);
            }
        }

        private string SanitizeHtmlString(string input)
        {
            input = Regex.Replace(input, @"[^\x20-\x7E]", "");
            input = Regex.Replace(input, @"[\x00-\x08\x0B\x0C\x0E-\x1F\x7F]", "");
            input = input.Replace("\r", "").Replace("\n", "");
            return input;
        }

        public string ExtractBodyContent(string html)
        {
            int bodyStart = html.IndexOf("<body>", StringComparison.OrdinalIgnoreCase);
            int bodyEnd = html.IndexOf("</body>", StringComparison.OrdinalIgnoreCase);

            if (bodyStart >= 0 && bodyEnd >= 0)
            {
                return html.Substring(bodyStart + 6, bodyEnd - bodyStart - 6);
            }
            return html;
        }
    }
}
