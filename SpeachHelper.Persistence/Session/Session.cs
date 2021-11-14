using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SpeachHelper.Persistance.Session
{
    public class Session : ISession
    {
        private IDbConnection connection;

        public Session(IDbConnection connection)
        {
            this.connection = connection;
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string query)
        {
            return connection.QueryAsync<T>(query);
        }

        public IEnumerable<T> Query<T>(string query)
        {
            return connection.Query<T>(query);
        }

        public async Task<T> QueryFirstAsync<T>(string query)
        {
            return await connection.QueryFirstAsync<T>(query);
        }

        public T QueryFirst<T>(string query)
        {
            return connection.QueryFirst<T>(query);
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string query, object parametrs)
        {
            return connection.QueryAsync<T>(query, parametrs);
        }

        public Task<int> ExecuteAsync(string query, object parametrs)
        {
            return connection.ExecuteAsync(query, parametrs);
        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
        }
    }
}