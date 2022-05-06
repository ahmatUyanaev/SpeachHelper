using SpeachHelper.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpeachHelper.Application.BizRules
{
    public interface ICommandsBizRules
    {
        Task AddCommandAsync(Command command);

        Task DeleteCommandAsync(int commandId);

        Task EditCommandAsync(int commandId, Command editedCommand);

        Task<IEnumerable<Command>> GetCommandsAsync();

        IEnumerable<Command> GetCommands();

        Command GetCommandById(int commandId);

        Task<IEnumerable<Command>> GetCommandsByCategoryId(int categoryId);
    }
}
