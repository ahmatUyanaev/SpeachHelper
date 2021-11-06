using SpeachHelper.Domain.DI;
using SpeachHelper.Domain.Entitys;
using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.InputSimulation.Contracts;
using System.Collections.Generic;

namespace SpeachHelper.Application.WordActionContainers.Implements
{
    public class WindowsWordActionContainer : IWordActionContainer
    {

        private IWindowsInputSimulator windowsInputSimulator;
        private List<Command> commands;

        public WindowsWordActionContainer()
        {
            windowsInputSimulator = ServiceLocator.GetService<IWindowsInputSimulator>();
            FillMock();
        }

        private void FillMock()
        {
            commands = new List<Command>();
            commands.Add(new Command("Скопируй", windowsInputSimulator.Copy()));
            commands.Add(new Command("Вставить", windowsInputSimulator.Paste()));
            commands.Add(new Command("Переключи язык", windowsInputSimulator.ChangeLanguage()));
        }

        public List<Command> GetActions()
        {
            return commands;
        }
    }
}
