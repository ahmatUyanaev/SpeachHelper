using Microsoft.Speech.Recognition;
using SpeachHelper.Common.DI;
using SpeachHelper.Common.WordActionContainers.Implements;
using SpeachHelper.SpeachRecognition;
using System.Drawing;
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
            var edgeContainer = ServiceLocator.GetService<EdgeWordActionContainer>();
            var newCommand = edgeContainer.AddBrowserWebSiteAction(wordsTextBox.Text, actionTextBox.Text);
            var updatedGrammer = new GrammarBuilder(new Choices(new string[] { newCommand.CommandName }));
            recognizer.LoadGrammar(updatedGrammer);
        }

        private void MainPage_Load(object sender, System.EventArgs e)
        {

        }

        
    }
}
