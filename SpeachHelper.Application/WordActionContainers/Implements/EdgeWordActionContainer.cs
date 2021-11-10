using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.Infrastructure.DI;
using SpeachHelper.Infrastructure.Entitys;
using SpeachHelper.InputSimulation.Contracts;
using SpeachHelper.Persistance.Session;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SpeachHelper.Application.WordActionContainers.Implements
{
    public class EdgeWordActionContainer : IBrowserWordActionContainer
    {
        private IBrowserInputSimulation edgeInputSimulation;
        private List<Command> commands;

        public EdgeWordActionContainer()
        {
            edgeInputSimulation = ServiceLocator.GetService<IBrowserInputSimulation>();
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
            commands.Add(new Command("Верний вкладку", edgeInputSimulation.OpenLastClosedTab()));
            commands.Add(new Command("Вернись назад", edgeInputSimulation.ComeBack()));
            commands.Add(new Command("Вернись вперед", edgeInputSimulation.ComeForward()));

            //DBQuery(commands);
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

        public async void DBQuery(List<Command> commands)
        {
            ISession session = ServiceLocator.GetService<ISessionFactory>().CreateSession();

            foreach (Command command in commands)
            {
                var parametrs = new
                {
                    commandName = command.CommandName,
                    argument = command.Argument,
                };

                string insert = @"
INSERT INTO Commands
    (CommandName, Argument)
VALUES
    (@commandName, @argument)
";
                await session.ExecuteAsync(insert, parametrs);
            }
        }
    }
}