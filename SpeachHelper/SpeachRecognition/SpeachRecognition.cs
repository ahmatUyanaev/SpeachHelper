using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Speech.Recognition;
using SpeachHelper.Common.WordActionContainers.Implements;
using SpeachHelper.Common.DI;

namespace SpeachHelper.SpeachRecognition
{
    public class SpeachRecognizer
    {
        private  SpeechRecognitionEngine speachRecognition;

        private  EdgeWordActionContainer edgeBrowserWordActionContainer;

        private WindowsWordActionContainer windowsWordActionContainer;

        private  Dictionary<string, Action> edgeActions;
        private Dictionary<string, Action> windowsActions;


        public GrammarBuilder grammarBuilder { get; set; }

        public SpeachRecognizer()
        {
            edgeBrowserWordActionContainer = ServiceLocator.GetService<EdgeWordActionContainer>();
            windowsWordActionContainer = ServiceLocator.GetService<WindowsWordActionContainer>();

            edgeActions = edgeBrowserWordActionContainer.GetActions();
            windowsActions = windowsWordActionContainer.GetActions();

            Init();

            grammarBuilder = new GrammarBuilder();

            var joinedActions = JoinActions();

            grammarBuilder.Append(new Choices(joinedActions.ToArray()));

            speachRecognition.SpeechRecognized += SpeechRecognizer_SpeechRecognized;

            speachRecognition.LoadGrammar(new Grammar(grammarBuilder));
        }

        private void SpeechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            
            Action command;
            var text = e.Result.Text;
            if (edgeActions.TryGetValue(text, out command))
            {
                command.Invoke();
            }
            else if (windowsActions.TryGetValue(text, out command))
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

        public List<string> JoinActions()
        {
            var edgeKeys = edgeActions.Keys.ToList();
            var windowsKeys = windowsActions.Keys.ToList();
            edgeKeys.AddRange(windowsKeys);
            return edgeKeys;
        }

    }
}
