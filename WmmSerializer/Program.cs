using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using SeriallizeGen;

namespace WmmSerializer
{
    
    public class Test
    {
        public int a;
        private int b;
        public string c;
        public byte d;
    }
    
    public class Program
    {
        // public class Test
        // {
        //     public int a;
        //     private int b;
        //     public string c;
        //     public byte d;
        // }
        static void Main(string[] args)
        {
            SerializeGen gen = new SerializeGen();
            gen.GenDoc(new List<Type>
            {
                typeof(int),
                typeof(float),
                typeof(string),
                typeof(Test),
            });
        }
    }
}