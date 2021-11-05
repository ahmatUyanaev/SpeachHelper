using System.Data.SqlClient;

namespace SpeachHelper.Persistance.Session
{
    public class SessionFactory : ISessionFactory
    {
        public ISession CreateSession()
        {
            string connString = @"Data Source=DESKTOP-29CFBJD\SQLEXPRESS;Initial Catalog=SpeachHelperDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();

            return new Session(connection);
        }
    }
}
