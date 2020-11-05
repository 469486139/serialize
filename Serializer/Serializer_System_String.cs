// /*********************************************************
// *
// * Serializer_System_String.cs
// *
// *********************************************************/

using System.IO;

namespace Serializer
{
    public static class Serializer_System_String
    {
        public static void Write(Stream stream, ref string v)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(v);

            int len = bytes.Length;
            Serializer_System_Int32.Write(stream, ref len);
            
        }

        public static void Read(Stream stream, ref string v)
        {
            int len = 0;
            Serializer_System_Int32.Read(stream, ref len);
            if (len == 0) return;
            
            
        }
    }
}