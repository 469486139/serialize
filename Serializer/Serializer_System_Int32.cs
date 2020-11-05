// /*********************************************************
// *
// * IntSerializer.cs
// *
// *********************************************************/

using System.IO;

namespace Serializer
{
    public static class Serializer_System_Int32
    {
        public static void Write(Stream stream, ref int v)
        {
            stream.WriteByte((byte)(v&0xff));
            stream.WriteByte((byte)(v >> 8&0xff));
            stream.WriteByte((byte)(v >> 16&0xff));
            stream.WriteByte((byte)(v >> 24&0xff));
        }

        public static void Read(Stream stream, ref int v)
        {
            v = stream.ReadByte();
            v = v << 7 | stream.ReadByte();
            v = v << 7 | stream.ReadByte();
            v = v << 7 | stream.ReadByte();
        }
    }
}