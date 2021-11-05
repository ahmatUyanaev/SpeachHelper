using Microsoft.Speech.Recognition;
using Ninject;
using SpeachHelper.Application.Entitys;
using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.Application.WordActionContainers.Implements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeachHelper.Application.SpeachRecognition
{
    public class SpeachRecognizer : ISpeachRecognizer
    {
        private SpeechRecognitionEngine speachRecognition;

        private IWordActionContainer edgeBrowserWordActionContainer;

        private IWordActionContainer windowsWordActionContainer;

        private Dictionary<string, Action> actions;
        private List<Command> commands;

        public GrammarBuilder grammarBuilder { get; set; }

        public SpeachRecognizer()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Get<EdgeWordActionContainer>();
            edgeBrowserWordActionContainer = ninjectKernel.Get<EdgeWordActionContainer>(); ;
            windowsWordActionContainer = ninjectKernel.Get<WindowsWordActionContainer>();

            commands = edgeBrowserWordActionContainer.GetActions();
            commands.AddRange(windowsWordActionContainer.GetActions());

            actions = commands.ToDictionary(x => x.CommandName, y => y.Action);

            Init();

            grammarBuilder = new GrammarBuilder();

            grammarBuilder.Append(new Choices(commands.Select(c => c.CommandName).ToArray()));

            speachRecognition.SpeechRecognized += SpeechRecognizer_SpeechRecognized;

            speachRecognition.LoadGrammar(new Grammar(grammarBuilder));
        }

        private void SpeechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var text = e.Result.Text;
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

        public void LoadGrammar(GrammarBuilder newGrammar)
        {
            speachRecognition.LoadGrammarAsync(new Grammar(newGrammar));
            UpdateActions();
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

        private void UpdateActions()
        {
            actions = commands.ToDictionary(x => x.CommandName, y => y.Action);
        }

    }
}
