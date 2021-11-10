using Microsoft.Speech.Recognition;
using SpeachHelper.Application.SpeachRecognition;
using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.Application.WordActionContainers.Implements;
using SpeachHelper.Infrastructure.DI;
using SpeachHelper.Persistence.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeachHelper.Presentation
{
    public class View : IView
    {
        private ISpeachRecognizer recognizer;
        private IWordActionContainer windowsContainer;
        private ICommandsRepository commandsRepository;
        private IBrowserWordActionContainer edgeContainer;

        public List<string> filtredCommandNames { get; set; }

        public string WordsTextBox { get; set; }
        public string ActionTextBox { get; set; }
        private object selectedItem;
        public View()
        {
            commandsRepository = ServiceLocator.GetService<ICommandsRepository>();
            edgeContainer = ServiceLocator.GetService<IBrowserWordActionContainer>();
            recognizer = ServiceLocator.GetService<ISpeachRecognizer>();
            windowsContainer = ServiceLocator.GetService<WindowsWordActionContainer>();
        }

        public void Init(string wordsTextBox = null, string actionTextBox = null, object selectedItem = null)
        {
            this.ActionTextBox = actionTextBox;
            this.WordsTextBox = wordsTextBox;
            this.selectedItem = selectedItem;
        }

        public void AddCommand()
        {
            if (string.IsNullOrEmpty(WordsTextBox) || string.IsNullOrEmpty(ActionTextBox))
            {
                MessageBox.Show("ERROR");
                return;
            }

            if (edgeContainer.GetActions().Select(a => a.CommandName).Contains(WordsTextBox))
            {
                MessageBox.Show("такая команда уже есть");
                return;
            }
            //TODO перенести логику в отдельный сервис
            var newCommand = edgeContainer.AddBrowserWebSiteAction(WordsTextBox, ActionTextBox);
            Task.Run(() => commandsRepository.AddCommandAsync(newCommand));
            var updatedGrammer = new GrammarBuilder(new Choices(new string[] { newCommand.CommandName }));
            recognizer.LoadGrammar(updatedGrammer);
        }

        public void SelectedItemChange()
        {
            var dic = edgeContainer.GetActions().ToDictionary(key => key.CommandName, value => value.Argument);
            var item = selectedItem as string;

            if (dic.TryGetValue(item, out string argument))
            {
                WordsTextBox = item;
                ActionTextBox = argument;
            }
        }

        public List<string> GetAllCommandNames()
        {
            var commandNames = edgeContainer.GetActions().Select(c => c.CommandName).ToList();
            commandNames.AddRange(windowsContainer.GetActions().Select(c => c.CommandName));
            return commandNames;
        }

        public List<string> GetBrowserCommandNames()
        {
            return edgeContainer.GetActions().Select(c => c.CommandName).ToList();
        }

        public List<string> GetWindowsCommandNames()
        {
            return windowsContainer.GetActions().Select(c => c.CommandName).ToList();
        }
    }
}
