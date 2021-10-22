using SpeachHelper.Common.CommandModel;
using SpeachHelper.Common.DI;
using SpeachHelper.Common.WordActionContainers.Contacts;
using SpeachHelper.InputSimulation.Contracts;
using SpeachHelper.InputSimulation.Implements;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace SpeachHelper.Common.WordActionContainers.Implements
{
    public class EdgeWordActionContainer : IWordActionContainer, IBrowserWordActionContainer
    {
        private IBrowserInputSimulation edgeInputSimulation;
        private List<Command> commands;


        public EdgeWordActionContainer()
        {
            edgeInputSimulation = ServiceLocator.GetService<EdgeInputSimulator>();
            FillMock();
        }

        private void FillMock()
        {
            commands = new List<Command>();

            commands.Add(new Command("Открой браузер", () => Process.Start("https://yandex.ru/")));
            commands.Add(new Command("Открой вконтакте", () => Process.Start("https://vk.com/axma_sila")));
            commands.Add(new Command("Новая вкладка", edgeInputSimulation.OpenNewTabSimulate()));
            commands.Add(new Command("Закрой вкладку", edgeInputSimulation.CloseCurrentTab()));
            commands.Add(new Command("История посещений", edgeInputSimulation.WievHistory()));
            commands.Add(new Command("Верни закрытую вкладку", edgeInputSimulation.OpenLastClosedTab()));
            commands.Add(new Command("Вернись назад", edgeInputSimulation.ComeBack()));
            commands.Add(new Command("Вернись вперед", edgeInputSimulation.ComeForward()));
        }

        public List<Command> GetActions()
        {
            return commands;
        }

        public Command AddBrowserWebSiteAction(string command, string openedSite)
        {
            commands.Add(new Command(command, () => Process.Start(openedSite)));
            return commands.Last();
        }
    }
}
