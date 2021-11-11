﻿using SpeachHelper.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpeachHelper.Persistence.Repository.Contracts
{
    public interface ICommandsRepository
    {
        Task<List<Command>> GetCommandsAsync();

        Task<int> AddCommandAsync(Command command);
    }
}