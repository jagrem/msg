using Msg.Core.Versioning;
using Msg.Core.Transport;
using System;
using Version = Msg.Core.Versioning.Version;
using System.Threading.Tasks;

namespace Msg.Core.Versioning
{
    public static class VersionNegotiator
    {
        public static Task<Version> NegotiateVersionAsync(ClientVersion clientVersion, IConnection connection)
        {
            throw new NotImplementedException ();
        }
    }
}

