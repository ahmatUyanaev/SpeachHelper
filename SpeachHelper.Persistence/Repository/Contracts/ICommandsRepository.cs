using SpeachHelper.Infrastructure.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpeachHelper.Persistence.Repository.Contracts
{
    public interface ICommandsRepository
    {
        Task<IEnumerable<Command>> GetCommandsAsync();

        Task<int> AddCommandAsync(Command command);
    }
}