using Microsoft.Speech.Recognition;
using SpeachHelper.Common.DI;
using SpeachHelper.Common.WordActionContainers.Implements;
using SpeachHelper.SpeachRecognition;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SpeachHelper
{
    public partial class MainPage : Form
    {

        public static Bitmap BM = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

        private SpeachRecognizer recognizer;

        public MainPage()
        {
            InitializeComponent();

            recognizer = ServiceLocator.GetService<SpeachRecognizer>();

            recognizer.RecognizeAsync();
        }

        private void addCommandBtnClick(object sender, System.EventArgs e)
        {
            var grammarConteiner = ServiceLocator.GetService<EdgeWordActionContainer>();
            grammarConteiner.AddBrowserWebSiteAction(wordsTextBox.Text, actionTextBox.Text);
            var updatedGrammer = new GrammarBuilder(new Choices(grammarConteiner.GetActions().Keys.ToArray()));
            recognizer.LoadGrammar(updatedGrammer);
        }

        private void MainPage_Load(object sender, System.EventArgs e)
        {

        }


    }
}
