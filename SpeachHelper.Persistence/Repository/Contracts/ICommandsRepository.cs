using SpeachHelper.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeachHelper.Persistence.Repository.Contracts
{
    public interface ICommandsRepository
    {
        Task<IEnumerable<Command>> GetCommandsAsync();

        Task<int> AddCommandAsync(Command command);
    }
}
