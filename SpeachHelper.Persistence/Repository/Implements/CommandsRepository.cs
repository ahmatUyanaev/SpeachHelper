﻿using SpeachHelper.Domain.Entitys;
using SpeachHelper.Infrastructure.DI;
using SpeachHelper.Persistance.Session;
using SpeachHelper.Persistence.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeachHelper.Persistence.Repository.Implements
{
    public class CommandsRepository : ICommandsRepository
    {
        private ISessionFactory sessionFactory;

        public CommandsRepository()
        {
            sessionFactory = ServiceLocator.GetService<ISessionFactory>();
        }

        public async Task<int> AddCommandAsync(Command command)
        {
            using (var session = sessionFactory.CreateSession())
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
                return await session.ExecuteAsync(insert, parametrs);
            }
        }

        public async Task<List<Command>> GetCommandsAsync()
        {
            using (var session = sessionFactory.CreateSession())
            {
                var query = "SELECT * FROM Commands";
                var result = await session.QueryAsync<Command>(query);
                return result.ToList();
            }
        }
    }
}