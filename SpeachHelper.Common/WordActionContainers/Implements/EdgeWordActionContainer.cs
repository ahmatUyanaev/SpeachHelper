using SpeachHelper.Application.DI;
using SpeachHelper.Application.Entitys;
using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.InputSimulation.Contracts;
using SpeachHelper.Persistance.Session;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace SpeachHelper.Application.WordActionContainers.Implements
{
    public class EdgeWordActionContainer : IWordActionContainer, IBrowserWordActionContainer
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
            commands.Add(new Command("Открой закрытую вкладку", edgeInputSimulation.OpenLastClosedTab()));
            commands.Add(new Command("Вернись назад", edgeInputSimulation.ComeBack()));
            commands.Add(new Command("Вернись вперед", edgeInputSimulation.ComeForward()));

            ConcurrentBag<Command> ts = new ConcurrentBag<Command>();

            foreach (Command item in commands)
            {
                ts.Add(item);
            }

            DBQuery(ts);
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

        public async void DBQuery(ConcurrentBag<Command> commands)
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
