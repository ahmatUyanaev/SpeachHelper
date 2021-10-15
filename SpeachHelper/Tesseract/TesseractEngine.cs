using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;

using HtmlAgilityPack;

using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace SpeachHelper.TesseractRecognize
{
    public class TesseractEngine
    {
        public Dictionary<string, List<int>> GetTextAndCordinates(string path)
        {
           Tesseract tesseract = new Tesseract(@"C:\Users\A-UYANAEV\Desktop\rusdata", "rus", OcrEngineMode.TesseractLstmCombined);

            tesseract.SetImage(new Image<Bgr, byte>(path));

            var Html = tesseract.GetHOCRText();

            HtmlDocument htmlSnippet = new HtmlDocument();
            htmlSnippet.LoadHtml(Html);

            Dictionary<string, List<int>> parsedHtml = new Dictionary<string, List<int>>();

            foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//span[@title]"))
            {
                var text = link.InnerText;

                HtmlAttribute att = link.Attributes["title"];

                List<int> validCordinates = new List<int>();

                var cordinates = att.Value.Remove(0, 5).Replace(";", "  ").Split(' ').Take(2);

                foreach (var num in cordinates)
                {
                    validCordinates.Add(int.Parse(num));
                }

                if (!parsedHtml.ContainsKey(text))
                {
                    parsedHtml.Add(text, validCordinates);
                }
            }

            return parsedHtml;
        }

        public Dictionary<string, Point> GetCordinates(string path)
        {
            var image = new Bitmap(@"C:\OCRTest\number.jpg");
            var ocr = new tessnet2.Tesseract();
            ocr.SetVariable("tessedit_char_whitelist", "0123456789"); // If digit only
                                                                      //@"C:\OCRTest\tessdata" contains 
                                                                      //the language package, without this the method crash and app breaks
            ocr.Init(@"C:\OCRTest\tessdata", "eng", true);
            return ocr.DoOCR(new Bitmap(path), Rectangle.Empty).ToDictionary(kvp => kvp.Text, kvp => new Point(kvp.Top, kvp.Left));   
            //Select(t => new Text {text = t.Text, Left = t.Left, Top = t.Top });
        }
    }

    class Text
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public string text { get; set; }

    }
}
