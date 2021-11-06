namespace SpeachHelper.Persistance.Session
{
    public interface ISessionFactory
    {
        ISession CreateSession();
    }
}