using Msg.Core.Transport.Frames;
using System.Threading.Tasks;
using Msg.Core.Transport.Frames.Factories;
using System;
using System.Net;
using Msg.Core.Transport.Common.Protocol;
using Msg.Core.Transport.Common.Versioning;
using Msg.Core.Transport.Connections.Common;
using System.Linq;

namespace Msg.Core.Transport.Connections
{
    public static class Connector
    {
        public static async Task<Connection> OpenConnectionAsync ()
        {
            try {
                var transportLayerConnection = await new TransportLayerConnectionFactory().OpenConnectionAsync();
                
                var clientProtocolHeader = new ProtocolHeader (ProtocolIds.AMQP, new AmqpVersion(1, 0, 0));
                await transportLayerConnection.SendAsync (clientProtocolHeader);

                var serverProtocolHeader = (ProtocolHeader) await transportLayerConnection.ReceiveAsync(8);

                if(clientProtocolHeader.ProtocolId != serverProtocolHeader.ProtocolId) {
                    transportLayerConnection.Dispose();
                    throw new UnexpectedProtocolException(clientProtocolHeader.ProtocolId, serverProtocolHeader.ProtocolId);
                }

                if(serverProtocolHeader.Version != clientProtocolHeader.Version) {
                    // TODO: Implement downgrading of protocol based by retrying
                    transportLayerConnection.Dispose();
                    throw new UnsupportedVersionException(clientProtocolHeader.Version, serverProtocolHeader.Version);
                }

                var amqpConnection = new Connection (clientProtocolHeader.ProtocolId, clientProtocolHeader.Version, transportLayerConnection);

                await SendOpenFrame (amqpConnection);

                return amqpConnection;
            } catch (Exception exception) {
                throw new OpenConnectionFailedException ("Connection failed.", exception);
            }
        }

        static async Task SendOpenFrame (Connection connection)
        {
            var openFrame = FrameFactory.CreateOpenFrame ();
            await FrameSender.SendFrame (connection, openFrame);
        }

        static async Task SendCloseFrame (Connection connection)
        {
            var closeFrame = FrameFactory.CreateCloseFrame ();
            await FrameSender.SendFrame (connection, closeFrame);
        }
    }

}