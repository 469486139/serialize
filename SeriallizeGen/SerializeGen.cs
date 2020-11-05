using System;
using System.Collections.Generic;
using System.Reflection;

namespace SeriallizeGen
{
    public static class Utils
    {
        public static string GetTypeFullName(Type type)
        {
            return type.FullName.Replace('.', '_').Replace('+', '_');
        }

        public static string GetSerializerClassName(Type type)
        {
            return "Serializer_" + GetTypeFullName(type);
        }

        public static string GetClassName(Type type)
        {
            return type.FullName.Substring(type.Namespace.Length + 1).Replace('+', '.');
        }
    }

    public class ScriptWriter
    {
        
        private int mDepth = 0;
        public void W(string s, params object[]? p)
        {
            if (p != null&&p.Length>0)
            {
                s = string.Format(s, p);
            }
            
            for (int i = 0; i < mDepth; i++)
            {
                Console.Write('\t');
            }

            Console.WriteLine(s);
        }

        public void Begin()
        {
            W("{");
            mDepth++;
        }

        public void End()
        {
            mDepth--;
            W("}");
        }
    }

    public class SerializeGen
    {
        private ScriptWriter mScriptWriter = new ScriptWriter();

        private void Begin(){mScriptWriter.Begin();}
        private void End(){mScriptWriter.End();}
        private void W(string format, params object[]? param){mScriptWriter.W(format, param);}

        private void W()
        {
            mScriptWriter.W("");
        }

        public void GenDoc(IEnumerable<Type> types)
        {
            W("using System.IO;");
            W();
            W("namespace Serializer");
            Begin();
            foreach (var type in types)
            {
                Gen(type);
            }
            End();
        }

        void Gen(Type type)
        {
            if (type == null) return;

            if (type.IsPrimitive) return;

            if (type == typeof(string)) return;

            if (type.IsClass || type.IsValueType)
            {
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
                if(fields.Length == 0) return;
                GenerateClass(type, fields);
            }
            else
            {
                throw new Exception("不支持的类型" + type.FullName);
            }
        }

        private void GenerateClass(Type type, FieldInfo[] fields)
        {
            W("using {0};", type.Namespace);

            W("public static class {0}", Utils.GetSerializerClassName(type));
            Begin();
            {
                GenerateWriterMethod(type, fields);
                W();
                GenerateReaderMethod(type, fields);
            }
            End();
        }

        private void GenerateReaderMethod(Type type, FieldInfo[] fields)
        {
            W("public static void Read(Stream stream, ref {0} v)", Utils.GetClassName(type));
            Begin();
            {
                foreach (var fieldInfo in fields)
                {
                    W("{0}.Read(stream, ref v.{1});", Utils.GetSerializerClassName(fieldInfo.FieldType), fieldInfo.Name);
                }
            }
            End();
        }

        private void GenerateWriterMethod(Type type, FieldInfo[] fields)
        {
            W("public static void Write(Stream stream, ref {0} v)", Utils.GetClassName(type));
            Begin();
            {
                foreach (var fieldInfo in fields)
                {
                    W("{0}.Write(stream, ref v.{1});", Utils.GetSerializerClassName(fieldInfo.FieldType), fieldInfo.Name);
                }
            }
            End();
        }
    }
}