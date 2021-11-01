using IronOcr;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("form.png"))
            {

            }
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
