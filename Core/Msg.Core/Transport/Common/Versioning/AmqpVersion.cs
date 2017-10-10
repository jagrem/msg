using System;

namespace Msg.Core.Transport.Common.Versioning
{
    public class AmqpVersion : IComparable, IComparable<AmqpVersion>
    {
        public AmqpVersion (byte major, byte minor, byte revision)
        {
            Major = major;
            Minor = minor;
            Revision = revision;
        }

        public byte Major { get; private set; }

        public byte Minor { get; private set; }

        public byte Revision { get; private set; }

        public static implicit operator byte[] (AmqpVersion v)
        {
            return new byte[] { v.Major, v.Minor, v.Revision };
        }

        public static implicit operator AmqpVersion (byte[] version)
        {
            if (version.Length != 3) {
                throw new ArgumentException ("Version must be exactly 3 bytes.");
            }

            return new AmqpVersion (version [0], version [1], version [2]);
        }

        public int CompareTo (object obj)
        {
            return CompareTo (obj as AmqpVersion);
        }

        public int CompareTo (AmqpVersion that)
        {
            if (that == null) {
                throw new ArgumentException ("Can only compare a valid AMQP version instance.");
            }

            return Compare (this, that);
        }

        static int Compare (AmqpVersion left, AmqpVersion right)
        {
            if (left.Major != right.Major) {
                return left.Major.CompareTo (right.Major);
            }

            if (left.Minor != right.Minor) {
                return left.Minor.CompareTo (right.Minor);
            }

            if (left.Revision != right.Revision) {
                return left.Revision.CompareTo (right.Revision);
            }

            return 0;
        }

        public override bool Equals (object obj)
        {
            var other = obj as AmqpVersion;

            if (ReferenceEquals (other, null)) {
                return false;
            }

            return CompareTo (other) == 0;
        }

        public override int GetHashCode ()
        {
            return Major ^ Minor ^ Revision;
        }

        public static bool operator == (AmqpVersion left, AmqpVersion right)
        {
            if (ReferenceEquals (left, null)) {
                return ReferenceEquals (right, null);
            }
            return left.Equals (right);
        }

        public static bool operator != (AmqpVersion left, AmqpVersion right)
        {
            return !(left == right);
        }

        public static bool operator < (AmqpVersion left, AmqpVersion right)
        {
            return (Compare (left, right) < 0);
        }

        public static bool operator > (AmqpVersion left, AmqpVersion right)
        {
            return (Compare (left, right) > 0);
        }

        public override string ToString ()
        {
            return string.Format ("[Version: Major={0}, Minor={1}, Revision={2}]", Major, Minor, Revision);
        }

        public static AmqpVersion Any = new AmqpVersion (0, 0, 0);

        public static AmqpVersionRange From (byte major, byte minor, byte revision)
        {
            return new AmqpVersionRange (new AmqpVersion (major, minor, revision), AmqpVersion.Any);
        }

        public static AmqpVersionRange UpTo (byte major, byte minor, byte revision)
        {
            return new AmqpVersionRange (AmqpVersion.Any, new AmqpVersion (major, minor, revision));
        }

        public static AmqpVersionRange Exactly (byte major, byte minor, byte revision)
        {
            return new AmqpVersionRange (new AmqpVersion (major, minor, revision), new AmqpVersion (major, minor, revision));
        }
    }
}

