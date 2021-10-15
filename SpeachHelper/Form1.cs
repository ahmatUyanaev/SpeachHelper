using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Microsoft.Speech.Recognition;

using SpeachHelper.Locator;
using SpeachHelper.SpeachRecognition;

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
            var updatedGrammer = new GrammarBuilder(new Choices(grammarConteiner.GetActions().Keys.ToArray()));
            recognizer.LoadGrammar(updatedGrammer);
        }
    }
}
