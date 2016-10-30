namespace Msg.Core.Transport.Connections.Http
{
    public class UninitializedHttpConnection : UninitializedConnection, IHttpConnection
    {
        protected override string ExceptionMessageTemplate {
            get {
                return "Cannot call {0} because this method is not supported on an HTTP connection yet.";
            }
        }
    }
}
