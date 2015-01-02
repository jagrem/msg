namespace Msg.Core.Transport.Sessions
{
    public static  class SessionFactoryExtensions
    {
        public static Session CreateSession(this SessionFactory factory)
        {
            return new Session ();
        }
    }
}

