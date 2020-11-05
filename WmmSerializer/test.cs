using System.IO;

namespace Serializer
{
	using WmmSerializer;
	public static class Serializer_WmmSerializer_Test
	{
		public static void Write(Stream stream, ref Test v)
		{
			Serializer_System_Int32.Write(stream, ref v.a);
			Serializer_System_String.Write(stream, ref v.c);
			Serializer_System_Byte.Write(stream, ref v.d);
		}
		
		public static void Read(Stream stream, ref Test v)
		{
			Serializer_System_Int32.Read(stream, ref v.a);
			Serializer_System_String.Read(stream, ref v.c);
			Serializer_System_Byte.Read(stream, ref v.d);
		}
	}
}
