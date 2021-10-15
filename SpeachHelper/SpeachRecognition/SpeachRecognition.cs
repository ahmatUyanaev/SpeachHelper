using Microsoft.Speech.Recognition;
using SpeachHelper.Locator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SpeachHelper.SpeachRecognition
{
    public class SpeachRecognizer
    {
        private  SpeechRecognitionEngine speachRecognition;

        private  GrammarContainer grammarContainer;

        private  Dictionary<string, Action> actions;

        public GrammarBuilder GrammarBuilder { get; set; }

        

        public SpeachRecognizer()
        {
           

            grammarContainer = ServiceLocator.GetService<GrammarContainer>();

            actions = grammarContainer.GetActions();

            Init();

            GrammarBuilder = new GrammarBuilder();

            GrammarBuilder.Append(new Choices(actions.Keys.ToArray()));

            speachRecognition.SpeechRecognized += SpeechRecognizer_SpeechRecognized;

            speachRecognition.LoadGrammar(new Grammar(GrammarBuilder));
        }

        private void SpeechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            
            Action command;
            var text = e.Result.Text;
            if (actions.TryGetValue(text, out command))
            {
                command.Invoke();
            }

            #region
            //if (text == "Снимок")
            //{
            //    double multiple = 1.25;
            //    var width = (int)(Screen.PrimaryScreen.Bounds.Width * multiple);
            //    var height = (int)(Screen.PrimaryScreen.Bounds.Height * multiple);


            //    Bitmap printscreen = new Bitmap(width, height);

            //    Graphics graphics = Graphics.FromImage(printscreen as Image);
            //    graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            //    string savePath = @"C:\Users\A-UYANAEV\Desktop\screen.png";
            //    Size resolution = Screen.PrimaryScreen.Bounds.Size;
            //    printscreen.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);

            //    TesseractEngine teser = new TesseractEngine();

            //    cordinates = teser.GetTextAndCordinates(savePath);

            //    var gb = new GrammarBuilder();
            //    gb.Append(new Choices(cordinates.Keys.ToArray()));
            //    speachRecognition.LoadGrammar(new Grammar(gb));
            //}

            //var cordinate = new List<int>();

            //if (cordinates.TryGetValue(text, out cordinate))
            //{
            //    Cursor.Position = new Point(cordinate[0], cordinate[1]);
            //}
            #endregion

           // MessageBox.Show(e.Result.Text);
        }

        public void LoadGrammar(GrammarBuilder newGrammar)
        {
            speachRecognition.UnloadAllGrammars();
            speachRecognition.LoadGrammarAsync(new Grammar(newGrammar));
        }

        public void RecognizeAsync()
        {
            speachRecognition.RecognizeAsync(RecognizeMode.Multiple);
        }


        private void Init()
        {
            var ci = new System.Globalization.CultureInfo("ru-RU");
            speachRecognition = new SpeechRecognitionEngine(ci);
            speachRecognition.SetInputToDefaultAudioDevice();
        }

    }
}
