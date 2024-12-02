using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;
using UglyToad.PdfPig;
using LingoLift.Models;
using System.Windows.Controls;
using System.Web;
using System.Windows.Media;
using System.Net.Http;

namespace LingoLift.Services
{
    public class PdfManager
    {
        private readonly List<PdfPage> _pages;

        public PdfManager()
        {
            _pages = [];
        }

        public void LoadPdf(string filePath)
        {
            using var pdf = PdfDocument.Open(filePath);
            foreach (var page in pdf.GetPages())
            {
                string[] temp = page.Letters[0].FontName!.Split('+');
                string font = temp[^1];
                double fontsize = page.Letters[0].FontSize;
                string text = ContentOrderTextExtractor.GetText(page);

                _pages.Add(new PdfPage()
                {
                    Text = text,
                    Font = font,
                    FontSize = fontsize
                });
            }
            TranslatePdf("es");

        }

        public async void TranslatePdf(string targetLanguage)
        {
            // Define the endpoint
            var url = "https://libretranslate.com/translate";

            // Create HttpClient instance
            using (HttpClient client = new HttpClient())
            {
                // Create the JSON payload
                var payload = new
                {
                    q = "Hello!",
                    source = "en",
                    target = "es"
                };

                // Serialize the payload to JSON
                string jsonPayload = System.Text.Json.JsonSerializer.Serialize(payload);

                // Set up the request content
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                try
                {
                    // Send the POST request
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    // Ensure success status code
                    response.EnsureSuccessStatusCode();

                    // Read and output the response
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Translated Text: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
            
    }
}
