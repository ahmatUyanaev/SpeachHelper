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