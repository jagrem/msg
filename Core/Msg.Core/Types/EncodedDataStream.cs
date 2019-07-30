using System.IO;

namespace Msg.Core.Types
{
    public class EncodedDataStream : Stream
    {
        readonly Stream _stream;
        public EncodedDataStream(Stream stream)
        {
            _stream = stream;
        }

        public override bool CanRead => _stream.CanRead;
        public override bool CanSeek => _stream.CanSeek;

        public override bool CanWrite => _stream.CanWrite;

        public override long Length => _stream.Length;

        public override long Position { get => _stream.Position; set => _stream.Position = value; }

        public sbyte ReadSByte() => (sbyte)ReadByte();

        public ushort ReadUInt16()
        {
            var v = new[] { _stream.ReadByte(), _stream.ReadByte() };

            var value = (v[0] << 8 | v[1]);
            return (ushort)value;
        }

        public short ReadInt16() => (short)ReadUInt16();

        public uint ReadUInt32()
        {
            var v = new[] { _stream.ReadByte(), _stream.ReadByte(), _stream.ReadByte(), _stream.ReadByte() };

            var value = v[0] << 24 | v[1] << 16 | v[2] << 8 | v[3];
            return (uint)value;
        }

        public int ReadInt32() => (int)ReadUInt32();

        public ulong ReadUInt64()
        {
            var v = new ulong[] {
                (ulong)_stream.ReadByte(), (ulong)_stream.ReadByte(), (ulong)_stream.ReadByte(), (ulong)_stream.ReadByte(),
                (ulong)_stream.ReadByte(), (ulong)_stream.ReadByte(), (ulong)_stream.ReadByte(), (ulong)_stream.ReadByte()
            };

            ulong value = v[0] << 56 | v[1] << 48 | v[2] << 40 | v[3] << 32 | v[4] << 24 | v[5] << 16 | v[6] << 8 | v[7];
            return (ulong)value;
        }

        public long ReadInt64() => (long)ReadUInt64();

        public override void Flush() => _stream.Flush();

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _stream.Write(buffer, offset, count);
        }
    }
}
