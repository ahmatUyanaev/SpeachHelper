using SpeachHelper.Application.WordActionContainers.Contacts;
using SpeachHelper.Domain.Entitys;
using SpeachHelper.Infrastructure.DI;
using SpeachHelper.Persistence.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeachHelper.Application.BizRules
{
    public class CommandsBizRules : ICommandsBizRules
    {
        private ICommandsRepository commandsRepository;
        private IWordActionContainer wordActionContainer;
        public CommandsBizRules()
        {
            commandsRepository = ServiceLocator.GetService<ICommandsRepository>();
            wordActionContainer = ServiceLocator.GetService<IWordActionContainer>();
        }

        public async Task AddCommandAsync(Command command)
        {
            var insertedId = await commandsRepository.AddCommandAsync(command);
            command.SetId(insertedId);
            wordActionContainer.AddCommand(command);
        }

        public async Task DeleteCommandAsync(int commandId)
        {
            wordActionContainer.DeleteCommand(commandId);
            await commandsRepository.DeleteCommandAsync(commandId);
        }

        public async Task EditCommandAsync(int commandId, Command editedCommand)
        {
            wordActionContainer.EditCommand(commandId, editedCommand);
            await commandsRepository.EditCommandAsync(commandId, editedCommand);
        }

        public IEnumerable<Command> GetCommands()
        {
            return commandsRepository.GetCommands();
        }

        public async Task<IEnumerable<Command>> GetCommandsAsync()
        {
            return await commandsRepository.GetCommandsAsync();
        }

        public Command GetCommandById(int commandId)
        {
            return commandsRepository.GetCommandById(commandId);
        }

        public async Task<IEnumerable<Command>> GetCommandsByCategoryId(int categoryId)
        {
            return await commandsRepository.GetCommandsByCategoryId(categoryId);
        }
    }
}