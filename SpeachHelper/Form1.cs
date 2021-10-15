using System.Windows.Forms;

using SpeachHelper.TesseractRecognize;
using SpeachHelper.SpeachRecognition;
using System.Drawing;
using SpeachHelper.Locator;
using Microsoft.Speech.Recognition;
using System.Linq;

namespace SpeachHelper
{
    public partial class Form1 : Form
    {
        public static Bitmap BM = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);


        
        private SpeachRecognizer recognizer;

        public Form1()
        {
            InitializeComponent();

            InputSimulater input = new InputSimulater();

            recognizer = ServiceLocator.GetService<SpeachRecognizer>();

            
            recognizer.RecognizeAsync();

            
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var grammarConteiner = ServiceLocator.GetService<GrammarContainer>();
            grammarConteiner.AddAction(textBox1.Text, textBox2.Text);
            recognizer.GrammarBuilder = new GrammarBuilder(new Choices(grammarConteiner.GetActions().Keys.ToArray()));
            recognizer.LoadGrammar(recognizer.GrammarBuilder);
            //переделать загрузку граматики
        }
    }
}
