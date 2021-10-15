using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Speech.Recognition;

namespace SpeachRecognition
{
    public class SpeachRecognition
    {
        private static SpeechRecognitionEngine speachRecognition;

        public SpeachRecognition()
        {
            var ci = new System.Globalization.CultureInfo("ru-RU");
            speachRecognition = new SpeechRecognitionEngine(ci);
            speachRecognition.SetInputToDefaultAudioDevice();
            var gb = new GrammarBuilder();
            gb.Append(new Choices(new string[] { "ниже", "выше", "синий" }));

           // Cursor.Position = new Point(1000, 222);

            speachRecognition.LoadGrammar(new Grammar(gb));
        }

        public void RecognizeAsync()
        {
            speachRecognition.RecognizeAsync();
        }
    }
}
