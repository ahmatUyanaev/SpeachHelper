using SpeachHelper.Application.SpeachRecognition;
using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.Forms;
using SpeachHelper.Infrastructure.DI;
using SpeachHelper.Persistence.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpeachHelper.Presentation
{
    public class View : IView
    {
        private ISpeachRecognizer recognizer;
        private ICommandsRepository commandsRepository;
        private IWordActionContainer wordActionContainer;

        public List<string> filtredCommandNames { get; set; }

        public string WordsTextBox { get; set; }
        public string ActionTextBox { get; set; }
        private object selectedItem;

        public View()
        {
            commandsRepository = ServiceLocator.GetService<ICommandsRepository>();
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
            //if (string.IsNullOrEmpty(WordsTextBox) || string.IsNullOrEmpty(ActionTextBox))
            //{
            //    MessageBox.Show("ERROR");
            //    return;
            //}

            //if (wordActionContainer.GetActions().Select(a => a.CommandName).Contains(WordsTextBox))
            //{
            //    MessageBox.Show("такая команда уже есть");
            //    return;
            //}
            //TODO перенести логику в отдельный сервис

            var commandId = GetCommandIdByName(commandName);
            var addCommandForm = new EditCommandForm(commandId);
            addCommandForm.Show();
            //var updatedGrammer = new GrammarBuilder(new Choices(new string[] { newCommand.CommandName }));
            //recognizer.LoadGrammar(updatedGrammer);
        }

        public void SelectedItemChange()
        {
            var dic = wordActionContainer.GetActions().ToDictionary(key => key.CommandName, value => value.Argument);
            var item = selectedItem as string;

            if (dic.TryGetValue(item, out string argument))
            {
                WordsTextBox = item;
                ActionTextBox = argument;
            }
        }

        public List<string> GetAllCommandNames()
        {
            var commandNames = wordActionContainer.GetActions().Select(c => c.CommandName).ToList();
            return commandNames;
        }

        public void AddCommand()
        {
            var addCommandForm = new AddCommandForm();
            addCommandForm.Show();
        }

        public void DeleteCommand(string commandName)
        {
            var commandId = GetCommandIdByName(commandName);
            commandsRepository.DeleteCommandAsync(commandId);
        }

        private int GetCommandIdByName(string commandName)
        {
            return wordActionContainer.GetActions().Where(c => c.CommandName == commandName).FirstOrDefault().ID;
        }
    }
}