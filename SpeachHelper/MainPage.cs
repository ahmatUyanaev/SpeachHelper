using Microsoft.Speech.Recognition;
using SpeachHelper.Application.SpeachRecognition;
using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.Application.WordActionContainers.Implements;
using SpeachHelper.Domain.DI;
using SpeachHelper.Persistence.Repository.Contracts;
using SpeachHelper.Persistence.Repository.Implements;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeachHelper
{
    public partial class MainPage : Form
    {
        private ISpeachRecognizer recognizer;
        private IWordActionContainer windowsContainer;
        private IBrowserWordActionContainer edgeContainer;

        public MainPage()
        {
            InitializeComponent();

            var commandsRepository = ServiceLocator.GetService<ICommandsRepository>();

            //var commands = Task.Run(async() => await commandsRepository.GetCommandsAsync());

            edgeContainer = ServiceLocator.GetService<IBrowserWordActionContainer>();
            recognizer = ServiceLocator.GetService<ISpeachRecognizer>();
            windowsContainer = ServiceLocator.GetService<WindowsWordActionContainer>();

            var commandNames = edgeContainer.GetActions().Select(c => c.CommandName);
            foreach (string name in commandNames)
            {
                commandsBox.Items.Add(name);
            }

            TreeNode tovarNode = new TreeNode("Browser");

            foreach (string name in commandNames)
            {
                tovarNode.Nodes.Add(new TreeNode(name));
            }

            treeView1.Nodes.Add(tovarNode);
            recognizer.RecognizeAsync();
        }

        private void addCommandBtnClick(object sender, System.EventArgs e)
        {
            if (edgeContainer.GetActions().Select(a => a.CommandName).Contains(wordsTextBox.Text))
            {
                MessageBox.Show("такая команда уже есть");
                return;
            }
            //TODO перенести логику в отдельный сервис
            var newCommand = edgeContainer.AddBrowserWebSiteAction(wordsTextBox.Text, actionTextBox.Text);
            var updatedGrammer = new GrammarBuilder(new Choices(new string[] { newCommand.CommandName }));
            recognizer.LoadGrammar(updatedGrammer);
        }

        private void commandsBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var dic = edgeContainer.GetActions().ToDictionary(key => key.CommandName, value => value.Argument);
            var selectedItem = commandsBox.SelectedItem as string;

            if (dic.TryGetValue(selectedItem, out string argument))
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

                foreach (string name in commandNames)
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

                System.Collections.Generic.IEnumerable<string> commandNames = edgeContainer.GetActions().Select(c => c.CommandName);

                foreach (string name in commandNames)
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

                System.Collections.Generic.IEnumerable<string> commandNames = windowsContainer.GetActions().Select(c => c.CommandName);

                foreach (string name in commandNames)
                {
                    commandsBox.Items.Add(name);
                }
            }
        }

        #region trey
        private void trey_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                Activate();
                ShowInTaskbar = true;
                trey.Visible = false;
            }
        }

        private void MainPage_SizeChanged(object sender, System.EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                trey.Visible = true;
            }
        }
        #endregion
    }
}