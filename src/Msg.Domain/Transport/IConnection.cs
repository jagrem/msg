using System.Collections.Generic;
using System.Linq;

namespace Msg.Domain.Transport
{

	public interface IConnection
	{
		bool IsConnected { get; }

		bool IsClosed { get; }

		long MaximumFrameSize { get; }
	}
}