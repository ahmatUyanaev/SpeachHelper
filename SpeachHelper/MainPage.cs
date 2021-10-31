using Microsoft.Speech.Recognition;
using SpeachHelper.Common.DI;
using SpeachHelper.Common.WordActionContainers.Implements;
using SpeachHelper.SpeachRecognition;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace SpeachHelper
{
    public partial class MainPage : Form
    {

        public static Bitmap BM = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

        private SpeachRecognizer recognizer;
        private WindowsWordActionContainer windowsContainer;
        private EdgeWordActionContainer edgeContainer;

        public MainPage()
        {
            InitializeComponent();

            recognizer = ServiceLocator.GetService<SpeachRecognizer>();
            edgeContainer = ServiceLocator.GetService<EdgeWordActionContainer>();
            windowsContainer = ServiceLocator.GetService<WindowsWordActionContainer>();

            var commandNames = edgeContainer.GetActions().Select(c => c.CommandName);
            foreach (var name in commandNames)
            {
                commandsBox.Items.Add(name);
            }

            recognizer.RecognizeAsync();
        }

        private void addCommandBtnClick(object sender, System.EventArgs e)
        {
            var edgeContainer = ServiceLocator.GetService<EdgeWordActionContainer>();

            if (edgeContainer.GetActions().Select(a=>a.CommandName).Contains(wordsTextBox.Text))
            {
                MessageBox.Show("такая команда уже есть");
                return;
            }
            
            var newCommand = edgeContainer.AddBrowserWebSiteAction(wordsTextBox.Text, actionTextBox.Text);
            var updatedGrammer = new GrammarBuilder(new Choices(new string[] { newCommand.CommandName }));
            recognizer.LoadGrammar(updatedGrammer);
        }

        private void commandsBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var dic = edgeContainer.GetActions().ToDictionary(key => key.CommandName, value => value.Argument);
            var selectedItem = commandsBox.SelectedItem as string;
            string argument;

            if (dic.TryGetValue(selectedItem, out argument))
            {
                wordsTextBox.Text = selectedItem;
                actionTextBox.Text = argument;
            }
        }

        private void allRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (allRadioButton.Checked)
            {
                commandsBox.Items.Clear();

                var commandNames = edgeContainer.GetActions().Select(c => c.CommandName).ToList();
                commandNames.AddRange(windowsContainer.GetActions().Select(c => c.CommandName));

                foreach (var name in commandNames)
                {
                    commandsBox.Items.Add(name);
                }
            }
        }

        private void browserRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (browserRadioButton.Checked)
            {
                commandsBox.Items.Clear();

                var commandNames = edgeContainer.GetActions().Select(c => c.CommandName);

                foreach (var name in commandNames)
                {
                    commandsBox.Items.Add(name);
                }
            }
        }

        private void windowsRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (windowsRadioButton.Checked)
            {
                commandsBox.Items.Clear();

                var commandNames = windowsContainer.GetActions().Select(c => c.CommandName);

                foreach (var name in commandNames)
                {
                    commandsBox.Items.Add(name);
                }
            }
        }
    }
}
