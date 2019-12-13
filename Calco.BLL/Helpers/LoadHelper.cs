using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Tesseract;

namespace Calco.BLL.Helpers
{
    public class LoadHelper : ILoadHelper
    {
        private readonly string _dataFile = "tessdata";
        private readonly string _lang = "eng";

        

        public string DoOCR()

        {
            string text = string.Empty;
            using (var engine = new TesseractEngine(@"C:\jennifer\tessdata", _lang, EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(@"C:\jennifer\Untitled.png"))
                {
                    using (var page = engine.Process(img))
                    {
                        text = page.GetText();
                    }
                }
            }
            return text;
        }
    }
}
