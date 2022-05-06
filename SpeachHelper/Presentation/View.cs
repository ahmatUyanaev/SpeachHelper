using SpeachHelper.Application.BizRules;
using SpeachHelper.Application.SpeachRecognition;
using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.Forms;
using SpeachHelper.Infrastructure.DI;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeachHelper.Presentation
{
    public class View : IView
    {
        private ISpeachRecognizer recognizer;
        private ICommandsBizRules commandsBizRules;
        private readonly ICategoryBizRules _categoryBizRules; 
        private IWordActionContainer wordActionContainer;
        private MainPage mainPage;

        public string WordsTextBox { get; set; }
        public string ActionTextBox { get; set; }

        public View(MainPage mainPage)
        {
            this.mainPage = mainPage;
            commandsBizRules = ServiceLocator.GetService<ICommandsBizRules>();
            wordActionContainer = ServiceLocator.GetService<IWordActionContainer>();
            recognizer = ServiceLocator.GetService<ISpeachRecognizer>();
            _categoryBizRules = ServiceLocator.GetService<ICategoryBizRules>();
        }

        public void AddCommand()
        {
            var addCommandForm = new AddCommandForm(mainPage.FillCombobox);
            addCommandForm.Show();
        }

        public async Task DeleteCommandAsync(string commandName)
        {
            var commandId = GetCommandIdByName(commandName);
            await commandsBizRules.DeleteCommandAsync(commandId);
        }

        public void EditCommand(string commandName)
        {
            if (string.IsNullOrEmpty(commandName))
            {
                return;
            }

            var commandId = GetCommandIdByName(commandName);
            var addCommandForm = new EditCommandForm(commandId, mainPage.FillCombobox);
            addCommandForm.Show();
            recognizer.LoadGrammar(commandName);
        }

        public void SelectedItemChange(object selectedItem)
        {
            var dic = wordActionContainer.GetActions().ToDictionary(key => key.CommandName, value => value.Argument);

            if (!(selectedItem is string item))
            {
                return;
            }

            if (dic.TryGetValue(item, out string argument))
            {
                WordsTextBox = item;
                ActionTextBox = argument;
            }
        }

        public List<string> GetAllCommandNames()
        {
            return commandsBizRules.GetCommands().Select(c => c.CommandName).ToList();
        }

        private int GetCommandIdByName(string commandName)
        {
            return commandsBizRules.GetCommands().FirstOrDefault(c => c.CommandName == commandName).ID;
        }

        public void FillCombobox(ListBox ListBox, TreeView treeView)
        {
            var categoryes = Task.Run(async () => await _categoryBizRules.GetAllCategories()).Result;
            ListBox.Items.Clear();
            treeView.Nodes.Clear();

            foreach (string name in GetAllCommandNames())
            {
                ListBox.Items.Add(name);
            }

            foreach(var category in categoryes)
            {
                TreeNode treeNode = new TreeNode(category.Name);
                var commands = Task.Run(async () => await commandsBizRules.GetCommandsByCategoryId(category.Id)).Result;

                foreach (var command in commands)
                {
                    treeNode.Nodes.Add(command.CommandName);
                }

                treeView.Nodes.Add(treeNode);
            }
        }
    }
}