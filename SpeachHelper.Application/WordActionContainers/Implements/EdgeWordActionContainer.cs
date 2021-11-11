using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.Domain.Entitys;
using SpeachHelper.Infrastructure.DI;
using SpeachHelper.InputSimulation;
using SpeachHelper.InputSimulation.Contracts;
using SpeachHelper.Persistence.Repository.Contracts;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SpeachHelper.Application.WordActionContainers.Implements
{
    public class EdgeWordActionContainer : IBrowserWordActionContainer
    {
        private IBrowserInputSimulation edgeInputSimulation;
        private List<Command> commands;
        private ICommandsRepository commandsRepository;
        public EdgeWordActionContainer()
        {
            edgeInputSimulation = ServiceLocator.GetService<IBrowserInputSimulation>();
            commandsRepository = ServiceLocator.GetService<ICommandsRepository>();
        }

        private async Task<List<Command>> GetCommandsAsync()
        {
            return await commandsRepository.GetCommandsAsync();
        }

        public List<Command> GetActions()
        {
            if (commands == null)
            {
                commands = GetCommandsAsync().Result;
                MapArgument(commands);
                return commands;
            }

            return commands;
        }

        public Command AddBrowserWebSiteAction(string command, string openedSite)
        {
            commands.Add(new Command(command, () => Process.Start(openedSite)));
            return commands.Last();
        }

        public void MapArgument(List<Command> commands)
        {
            foreach (var command in commands)
            {
                if (command.CommandType == Domain.Enums.CommandType.Hotkey)
                {
                    command.Action = KeyBoard.MapToInputSimulator(command.Argument);
                }
            }
        }
    }
}