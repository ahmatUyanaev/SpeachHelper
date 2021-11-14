using SpeachHelper.Application.BizRules;
using SpeachHelper.Application.SpeachRecognition;
using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.Forms;
using SpeachHelper.Infrastructure.DI;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SpeachHelper.Presentation
{
    public class View : IView
    {
        private ISpeachRecognizer recognizer;
        private ICommandsBizRules commandsBizRules;
        private IWordActionContainer wordActionContainer;
        private MainPage mainPage;

        public List<string> filtredCommandNames { get; set; }

        public string WordsTextBox { get; set; }
        public string ActionTextBox { get; set; }
        private object selectedItem;

        public View(MainPage mainPage)
        {
            this.mainPage = mainPage;
            commandsBizRules = ServiceLocator.GetService<ICommandsBizRules>();
            wordActionContainer = ServiceLocator.GetService<IWordActionContainer>();
            recognizer = ServiceLocator.GetService<ISpeachRecognizer>();
        }

        public void Init(string wordsTextBox = null, string actionTextBox = null, object selectedItem = null)
        {
            this.ActionTextBox = actionTextBox;
            this.WordsTextBox = wordsTextBox;
            this.selectedItem = selectedItem;
        }

        public void EditCommand(string commandName)
        {
            var commandId = GetCommandIdByName(commandName);
            var addCommandForm = new EditCommandForm(commandId);
            addCommandForm.Show();
            recognizer.LoadGrammar(commandName);
        }

        public void SelectedItemChange()
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

        public void AddCommand()
        {
            var addCommandForm = new AddCommandForm(mainPage);
            addCommandForm.Show();
        }

        public void DeleteCommand(string commandName)
        {
            var commandId = GetCommandIdByName(commandName);
            commandsBizRules.DeleteCommandAsync(commandId);
        }

        private int GetCommandIdByName(string commandName)
        {
            return commandsBizRules.GetCommands().Where(c => c.CommandName == commandName).FirstOrDefault().ID;
        }

        public void FillCombobox(ListBox ListBox)
        {
            ListBox.Items.Clear();
            foreach (string name in GetAllCommandNames())
            {
                ListBox.Items.Add(name);
            }
        }
    }
}