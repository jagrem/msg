﻿using System;
using Msg.Core.Versioning;

namespace Msg.Core.Versioning
{
    public class Version : IComparable, IComparable<Version>
    {
        static readonly byte[] AMQP = { 0x41, 0x4D, 0x51, 0x50 };

        public Version (byte major, byte minor, byte revision)
        {
            this.Major = major;
            this.Minor = minor;
            this.Revision = revision;
        }

        public byte Major { get; private set; }

        public byte Minor { get; private set; }

        public byte Revision { get; private set; }

        public static implicit operator byte[] (Version v)
        {
            return new byte[] { AMQP [0], AMQP [1], AMQP [2], AMQP [3], 0, v.Major, v.Minor, v.Revision };
        }

        public static implicit operator Version (byte[] version)
        {
            if (version.Length != 8) {
                throw new ArgumentException ("Version must be exactly 8 bytes.");
            }

            if (!(version [0] == AMQP [0] && version [1] == AMQP [1] && version [2] == AMQP [2] && version [3] == AMQP [3] && version [4] == 0)) {
                throw new ArgumentException ("Version must start with \"AMQP\" followed by zero.");
            }

            return new Version (version [5], version [6], version [7]);
        }

        public int CompareTo (object obj)
        {
            return CompareTo (obj as Version);
        }

        public int CompareTo (Version that)
        {
            if (that == null) {
                throw new ArgumentException ("Can only compare a valid Version instance.");
            }

            return Compare (this, that);
        }

        static int Compare (Version left, Version right)
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
            Version other = obj as Version;

            if (object.ReferenceEquals (other, null)) {
                return false;
            }

            return this.CompareTo (other) == 0;
        }

        public override int GetHashCode ()
        {
            return Major ^ Minor ^ Revision;
        }

        public static bool operator == (Version left, Version right)
        {
            if (object.ReferenceEquals (left, null)) {
                return object.ReferenceEquals (right, null);
            }
            return left.Equals (right);
        }

        public static bool operator != (Version left, Version right)
        {
            return !(left == right);
        }

        public static bool operator < (Version left, Version right)
        {
            return (Compare (left, right) < 0);
        }

        public static bool operator > (Version left, Version right)
        {
            return (Compare (left, right) > 0);
        }

        public override string ToString ()
        {
            return string.Format ("[Version: Major={0}, Minor={1}, Revision={2}]", Major, Minor, Revision);
        }

        public static Version Any = new Version (0, 0, 0);

        public static VersionRange From (byte major, byte minor, byte revision)
        {
            return new VersionRange (new Version (major, minor, revision), Version.Any);
        }

        public static VersionRange UpTo (byte major, byte minor, byte revision)
        {
            return new VersionRange (Version.Any, new Version (major, minor, revision));
        }

        public static VersionRange Exactly (byte major, byte minor, byte revision)
        {
            return new VersionRange (new Version (major, minor, revision), new Version (major, minor, revision));
        }
    }
}
