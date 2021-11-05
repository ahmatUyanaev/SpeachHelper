using Microsoft.Speech.Recognition;
using Ninject;
using SpeachHelper.Application.SpeachRecognition;
using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.Application.WordActionContainers.Implements;
using SpeachHelper.InputSimulation.Contracts;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SpeachHelper
{
    public partial class MainPage : Form
    {
        private IKernel ninjectKernel;

        private ISpeachRecognizer recognizer;
        private IWordActionContainer windowsContainer;
        private IWordActionContainer edgeContainer;

        public MainPage()
        {
            InitializeComponent();

            ninjectKernel = new StandardKernel();

            edgeContainer = ninjectKernel.Get<EdgeWordActionContainer>();
            recognizer = ninjectKernel.Get<SpeachRecognizer>();
            windowsContainer = ninjectKernel.Get<WindowsWordActionContainer>();

            var commandNames = edgeContainer.GetActions().Select(c => c.CommandName);
            foreach (var name in commandNames)
            {
                commandsBox.Items.Add(name);
            }

            TreeNode tovarNode = new TreeNode("Browser");

            foreach (var name in commandNames)
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
            var newCommand = ((EdgeWordActionContainer)edgeContainer).AddBrowserWebSiteAction(wordsTextBox.Text, actionTextBox.Text);
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

        private void trey_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                this.Activate();
                this.ShowInTaskbar = true;
                trey.Visible = false;
            }
        }

        private void MainPage_SizeChanged(object sender, System.EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                trey.Visible = true;
            }
        }
    }
}
