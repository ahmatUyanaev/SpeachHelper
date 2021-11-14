using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpeachHelper.Persistance.Session
{
    public interface ISession : IDisposable
    {
        Task<IEnumerable<T>> QueryAsync<T>(string query);

        T QueryFirst<T>(string query);

        Task<T> QueryFirstAsync<T>(string query);

        Task<IEnumerable<T>> QueryAsync<T>(string query, object parametrs);

        Task<int> ExecuteAsync(string query, object parametrs);

        IEnumerable<T> Query<T>(string query);
    }
}