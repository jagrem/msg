using System.Collections.Generic;
using System.IO;
using System;

namespace Msg.Core.Types
{
    public class TypeParser
    {
        public static IEnumerable<(Type, object)> Parse(Stream stream)
        {
            var encodedStream = new EncodedDataStream(stream);

            var result = stream.ReadByte();

            switch (result)
            {
                case 0x40:
                    yield return (typeof(object), null);
                    break;
                case 0x41:
                    yield return (typeof(bool), true);
                    break;
                case 0x42:
                    yield return (typeof(bool), false);
                    break;
                case 0x43:
                    yield return (typeof(uint), 0);
                    break;
                case 0x44:
                    yield return (typeof(ulong), 0);
                    break;
                case 0x50:
                    yield return (typeof(byte), (byte)encodedStream.ReadByte());
                    break;
                case 0x51:
                    yield return (typeof(sbyte), (sbyte)encodedStream.ReadSByte());
                    break;
                case 0x52:
                    yield return (typeof(uint), (uint)encodedStream.ReadByte());
                    break;
                case 0x53:
                    yield return (typeof(ulong), (ulong)encodedStream.ReadByte());
                    break;
                case 0x54:
                    yield return (typeof(int), (int)encodedStream.ReadSByte());
                    break;
                case 0x55:
                    yield return (typeof(long), (long)encodedStream.ReadSByte());
                    break;
                case 0x56:
                    yield return (typeof(bool), encodedStream.ReadByte() > 0 ? true : false);
                    break;
                case 0x60:
                    yield return (typeof(ushort), encodedStream.ReadUInt16());
                    break;
                case 0x61:
                    yield return (typeof(short), encodedStream.ReadInt16());
                    break;
                case 0x70:
                    yield return (typeof(uint), encodedStream.ReadUInt32());
                    break;
                case 0x71:
                    yield return (typeof(int), encodedStream.ReadInt32());
                    break;
                case 0x80:
                    yield return (typeof(ulong), encodedStream.ReadUInt64());
                    break;
                case 0x81:
                    yield return (typeof(long), encodedStream.ReadInt64());
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
