using SpeachHelper.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpeachHelper.Persistence.Repository.Contracts
{
    public interface ICommandsRepository
    {
        Task<List<Command>> GetCommandsAsync();

        Task<int> AddCommandAsync(Command command);

        Task DeleteCommandAsync(int commandId);

        Task EditCommandAsync(int commandId, Command newCommand);

        Task<Command> GetCommandByIdAsync(int commandId);

        Command GetCommandById(int commandId);

        IEnumerable<Command> GetCommands();

        Task<IEnumerable<Command>> GetCommandsByCategoryId(int categoryId);
    }
}