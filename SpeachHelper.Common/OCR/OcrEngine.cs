using IronOcr;
using System;

namespace SpeachHelper.Common.OCR
{
    public class OcrEngine
    {
        public OcrEngine()
        {

            var Ocr = new IronTesseract();
            Ocr.Language = OcrLanguage.Russian;

            using (var Input = new OcrInput("vk.png"))
            {
                var Result = Ocr.Read(Input);
                Console.WriteLine(Result.Text);
            }


        }
    }
}
