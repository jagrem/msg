using System;
using System.Text;

namespace Msg.Core.Specs.Transport.Connections.Replay
{
    /* Replays test data */

    public class ReplayException : Exception
    {
        public ReplayException (byte[] expected, byte[] actual)
            : base (FormatMessage (expected, actual))
        {
            this.Actual = actual;
            this.Expected = expected;
        }

        static string FormatMessage (byte[] expected, byte[] actual)
        {
            return string.Format (
                "Expected [{0}] with length {1} but received [{2}] with length {3}",
                Encoding.UTF8.GetString (expected),
                expected.Length,
                Encoding.UTF8.GetString (actual),
                actual.Length);
        }

        public byte[] Expected { get; private set; }

        public byte[] Actual { get; private set; }
    }
	
}
