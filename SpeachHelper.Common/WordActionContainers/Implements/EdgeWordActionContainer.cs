using Ninject;
using SpeachHelper.Application.Entitys;
using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.InputSimulation.Contracts;
using SpeachHelper.InputSimulation.Implements;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace SpeachHelper.Application.WordActionContainers.Implements
{
    public class EdgeWordActionContainer : IWordActionContainer, IBrowserWordActionContainer
    {
        private IKernel ninjectKernel;

        private IBrowserInputSimulation edgeInputSimulation;
        private List<Command> commands;

        public EdgeWordActionContainer()
        {
            ninjectKernel = new StandardKernel();
            edgeInputSimulation = ninjectKernel.Get<EdgeInputSimulator>();

            FillMock();
        }

        private void FillMock()
        {
            commands = new List<Command>();

            commands.Add(new Command("Открой браузер", () => Process.Start("https://yandex.ru/"), "https://yandex.ru/"));
            commands.Add(new Command("Открой вконтакте", () => Process.Start("https://vk.com/axma_sila"), "https://vk.com/axma_sila"));
            commands.Add(new Command("Новая вкладка", edgeInputSimulation.OpenNewTabSimulate()));
            commands.Add(new Command("Закрой вкладку", edgeInputSimulation.CloseCurrentTab()));
            commands.Add(new Command("История", edgeInputSimulation.WievHistory()));
            commands.Add(new Command("Открой закрытую вкладку", edgeInputSimulation.OpenLastClosedTab()));
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
