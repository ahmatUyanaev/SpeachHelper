using Microsoft.Speech.Recognition;
using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.Domain.Entitys;
using SpeachHelper.Infrastructure.DI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SpeachHelper.Application.SpeachRecognition
{
    public class SpeachRecognizer : ISpeachRecognizer, IDisposable
    {
        private SpeechRecognitionEngine speachRecognition;
        private IWordActionContainer wordActionContainer;
        public GrammarBuilder grammarBuilder { get; set; }


        private Dictionary<string, Action> actions;
        private List<Command> commands;
        private List<string> _history;
        private Stopwatch _stopwatch;


        public SpeachRecognizer()
        {
            wordActionContainer = ServiceLocator.GetService<IWordActionContainer>(); ;

            commands = wordActionContainer.GetActions();

            actions = commands.ToDictionary(x => x.CommandName, y => y.Action);

            _history = new List<string>();
            _history.Add("Алиса");

            _stopwatch = new Stopwatch();

            Init();
        }

        private void SpeechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string text = e.Result.Text;

            if (text == "Алиса")
            {
                _stopwatch.Start();
            }
            else if(_history.Last() == "Алиса")
            {
                _stopwatch.Stop();
                var timeFilter = _stopwatch.Elapsed.TotalSeconds > 7;
                _stopwatch.Reset();
                if (timeFilter) 
                {
                    return;
                }
            }

            if (_history.Last() != "Алиса")
            {
                _history.Add(text);
                return;
            }

            _history.Add(text);

            if (actions.TryGetValue(text, out Action action))
            {
                action.Invoke();
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

        public void LoadGrammar(string newCommand)
        {
            var updatedGrammer = new GrammarBuilder(new Choices(new string[] { newCommand }));
            speachRecognition.LoadGrammarAsync(new Grammar(updatedGrammer));
            UpdateActions();
        }

        public void RecognizeAsync()
        {
            speachRecognition.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void Init()
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ru-RU");
            speachRecognition = new SpeechRecognitionEngine(ci);
            speachRecognition.SetInputToDefaultAudioDevice();

            grammarBuilder = new GrammarBuilder();

            grammarBuilder.Append(new Choices(commands.Select(c => c.CommandName).ToArray()));

            speachRecognition.SpeechRecognized += SpeechRecognizer_SpeechRecognized;

            speachRecognition.LoadGrammar(new Grammar(grammarBuilder));
        }

        private void UpdateActions()
        {
            actions = wordActionContainer.GetActions().ToDictionary(x => x.CommandName, y => y.Action);
        }

        public void Dispose()
        {
            speachRecognition.Dispose();
        }
    }
}