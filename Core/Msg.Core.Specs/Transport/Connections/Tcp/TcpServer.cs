using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Msg.Core.Transport.Common;

namespace Msg.Core.Specs.Transport.Connections.Tcp
{
    public class TcpServer
    {
        readonly TaskCompletionSource<int> completionSource = new TaskCompletionSource<int> ();
        readonly TaskCompletionSource<byte[]> resultCompletionSource = new TaskCompletionSource<byte[]> ();
        readonly CancellationTokenSource cancellationSource = new CancellationTokenSource ();

        public async Task StartAsync ()
        {
            Start (completionSource, resultCompletionSource, cancellationSource.Token);
            await completionSource.Task;
        }

        public async Task<byte[]> GetReceivedBytes ()
        {
            completionSource.TrySetResult (0);
            cancellationSource.Cancel ();
            return await resultCompletionSource.Task;
        }

        static void Start (TaskCompletionSource<int> completionSource, TaskCompletionSource<byte[]> result, CancellationToken cancellationToken)
        {
            Task.Factory.StartNew (async () => {
                var endpoint = new TcpEndpoint (IPAddress.Loopback, (PortNumber)9876);
                var listener = CreateListener (endpoint);
                NotifyListenerCreated (completionSource);
                await ListenForClients (cancellationToken, listener, result);
            });
        }

        static TcpListener CreateListener (TcpEndpoint endpoint)
        {
            var listener = new TcpListener (endpoint.IpAddress, endpoint.Port);
            listener.Start ();
            return listener;
        }

        static void NotifyListenerCreated (TaskCompletionSource<int> completionSource)
        {
            completionSource.SetResult (0);
        }

        static async Task ListenForClients (CancellationToken cancellationToken, TcpListener server, TaskCompletionSource<byte[]> result)
        {
            while (IsNotCancelled (cancellationToken)) {
                if (IsClientRequestPending (server)) {
                    await AcceptClient (server, result);
                }
            }
        }

        static bool IsClientRequestPending (TcpListener server)
        {
            return server.Pending ();
        }

        static bool IsNotCancelled (CancellationToken cancellationToken)
        {
            return !cancellationToken.IsCancellationRequested;
        }

        static async Task AcceptClient (TcpListener server, TaskCompletionSource<byte[]> result)
        {
            using (var client = await server.AcceptTcpClientAsync ())
            using (var stream = client.GetStream ()) {
                result.SetResult (await DataStreamReader.ReadDataAsync (stream));
            }
        }
    }
}

