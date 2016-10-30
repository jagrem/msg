namespace Msg.Core.Transport.Connections.WebSockets
{
    public class UninitializedWebSocketConnection : UninitializedConnection, IWebSocketConnection
    {
        protected override string ExceptionMessageTemplate {
            get {
                return "Cannot call {0} yet on a WebSocket connection.";
            }
        }
    }
}
