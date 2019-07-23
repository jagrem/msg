using System;

using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames.Serialization
{
    public class FrameSerializer
    {
        public static byte[] Serialize(Frame frame)
        {
            if (frame.Header.Size < FrameHeaders.FixedLengthInBytes)
            {
                throw new MalformedFrameException("Frame size must be at least the size of the mandatory frame header.");
            }

            if ((frame.Header.DataOffset * FrameHeaders.DataOffsetMultiplicationFactor) < FrameHeaders.FixedLengthInBytes)
            {
                throw new MalformedFrameException("Data offset must be at least the size of the mandatory frame header.");
            }

            if (FrameHeaders.FixedLengthInBytes + frame.ExtendedHeader.Data.Length + frame.Body.Payload.Length != frame.Header.Size)
            {
                throw new MalformedFrameException("Frame size must match the number of bytes in the frame.");
            }

            var frameBytes = new byte[frame.Header.Size];

            var extendedHeaderLength = (uint)frame.ExtendedHeader.Data.Length;
            var dataOffset = (FrameHeaders.FixedLengthInBytes + extendedHeaderLength) / FrameHeaders.DataOffsetMultiplicationFactor;

            uint size = frame.Header.Size;
            var sizeBytes = BitConverter.GetBytes(size);
            frameBytes[0] = sizeBytes[0];
            frameBytes[1] = sizeBytes[1];
            frameBytes[2] = sizeBytes[2];
            frameBytes[3] = sizeBytes[3];

            frameBytes[4] = (byte)dataOffset;
            frameBytes[5] = (byte)frame.Header.Type;

            ushort channelId = frame.Header.ChannelId;
            var channelIdBytes = BitConverter.GetBytes(channelId);
            frameBytes[6] = channelIdBytes[0];
            frameBytes[7] = channelIdBytes[1];

            Array.Copy(frame.ExtendedHeader.Data, 0, frameBytes, 8, extendedHeaderLength);

            var bodyLength = frame.Body.Payload.Length;
            Array.Copy(frame.Body.Payload, 0, frameBytes, dataOffset, bodyLength);

            return frameBytes;
        }

        public static Frame Deserialize(byte[] frameBytes)
        {
            int length = frameBytes.Length;

            if (length < 8)
            {
                throw new MalformedFrameException("Frame must contain at least the mandatory frame header.");
            }
            var sizeBytes = BitConverter.IsLittleEndian ?
                new byte[] {
                    frameBytes[3], frameBytes[2], frameBytes[1], frameBytes[0]
                } :
                new byte[] {
                    frameBytes[0], frameBytes[1], frameBytes[2], frameBytes[3]
                };

            var size = BitConverter.ToUInt32(sizeBytes, 0);

            if (size < FrameHeaders.FixedLengthInBytes)
            {
                throw new MalformedFrameException("Frame size must be at least the size of the mandatory frame header.");
            }

            if (size != length)
            {
                throw new MalformedFrameException("Frame size must match the number of bytes in the frame.");
            }

            var dataOffset = frameBytes[4];

            if (dataOffset * FrameHeaders.DataOffsetMultiplicationFactor < FrameHeaders.FixedLengthInBytes)
            {
                throw new MalformedFrameException("Data offset must be at least the size of the mandatory frame header.");
            }

            var type = frameBytes[5];

            if (type > FrameHeaders.MaximumSupportedFrameHeaderType)
            {
                throw new NotSupportedException("The frame header type is not supported.");
            }

            var channelIdBytes = BitConverter.IsLittleEndian ?
                new byte[] { frameBytes[7], frameBytes[6] } :
                new byte[] { frameBytes[6], frameBytes[7] };

            var channelId = BitConverter.ToUInt16(channelIdBytes, 0);

            var header = new FrameHeader(size, dataOffset, (FrameHeaderType)type, channelId);

            var offsetToBody = dataOffset * FrameHeaders.DataOffsetMultiplicationFactor;

            byte[] extendedHeaderBytes;

            if (offsetToBody > FrameHeaders.FixedLengthInBytes)
            {
                extendedHeaderBytes = new byte[offsetToBody - FrameHeaders.FixedLengthInBytes];
                Array.Copy(frameBytes, FrameHeaders.FixedLengthInBytes, extendedHeaderBytes, 0, extendedHeaderBytes.Length);
            }
            else
            {
                extendedHeaderBytes = new byte[0];
            }

            byte[] frameBodyBytes;

            if (size > offsetToBody)
            {
                frameBodyBytes = new byte[header.Size - offsetToBody];
                Array.Copy(frameBytes, offsetToBody, frameBodyBytes, 0, frameBodyBytes.Length);
            }
            else
            {
                frameBodyBytes = new byte[0];
            }

            return new Frame(header, new FrameExtendedHeader(extendedHeaderBytes), new FrameBody(frameBodyBytes));
        }
    }
}
