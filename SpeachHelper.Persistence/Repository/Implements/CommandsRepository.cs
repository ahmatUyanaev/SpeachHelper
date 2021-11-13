using SpeachHelper.Domain.Entitys;
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

        public async Task DeleteCommandAsync(int commandId)
        {
            using (var session = sessionFactory.CreateSession())
            {
                var query = $@"
DELETE FROM Commands
WHERE ID = {commandId}";

                await session.ExecuteAsync(query, null);
            }
        }

        public async Task EditCommandAsync(int commandId, Command newCommand)
        {
            using (var session = sessionFactory.CreateSession())
            {
                var query = $@"
UPDATE Commands
SET CommandName = '{newCommand.CommandName}', Argument = '{newCommand.Argument}'
WHERE ID = {commandId} ";

                await session.ExecuteAsync(query, null);
            }
        }

        public async Task<Command> GetCommandByIdAsync(int commandId)
        {
            using (var session = sessionFactory.CreateSession())
            {
                var query = $@"
SELECT * FROM Commands
WHERE ID = {commandId}";
                var res = await session.QueryFirstAsync<Command>(query);
                return res;
            }
        }

        public Command GetCommandById(int commandId)
        {
            using (var session = sessionFactory.CreateSession())
            {
                var query = $@"
SELECT * FROM Commands
WHERE ID = {commandId}";
                return session.QueryFirst<Command>(query);
            }
        }
    }
}