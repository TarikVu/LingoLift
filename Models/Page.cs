using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LingoLift.Models
{
    internal class PdfPage
    {
        public required string Text { get; set; }
        public required string Font { get; set; }
        public double FontSize { get; set; }
        public string? TranslatedText { get; set; }
         
    }

 
}
