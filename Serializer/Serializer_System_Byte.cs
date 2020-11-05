// /*********************************************************
// *
// * ByteSerializer.cs
// *
// *********************************************************/

using System;
using System.IO;

namespace Serializer
{
    public static class Serializer_System_Byte
    {
        public static void Write(Stream stream, ref byte v)
        {
            stream.WriteByte(v);
        }

        public static void Read(Stream stream, ref byte v)
        {
            v = (byte)stream.ReadByte();
        }
    }
    
}