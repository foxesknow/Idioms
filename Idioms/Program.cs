using System;
using System.Collections.Generic;
using System.Linq;

namespace Idioms
{
    /// <summary>
    /// https://programming-idioms.org/about#about-block-all-idioms
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Idiom274();
        }

        public static void Idiom2()
        {
            Console.WriteLine(string.Join(Environment.NewLine, Enumerable.Repeat("Hello", 10)));
        }

        public static void Idiom254()
        {
            var x = new List<string>();
        }

        public static void Idiom274()
        {
            string s = "Hello world";
            var t = new string(s.Where(c => !Char.IsWhiteSpace(c)).ToArray());
        }

        public static void Idiom275()
        {
            var buffer = ToByteArray("111111110000001100001000");

            static byte[] ToByteArray(string s)
            {
                return Enumerable.Range(0, s.Length / 8)
                       .Select(i => s.Substring(i * 8, 8).ToCharArray())
                       .Select(block => (byte)block.Aggregate(0, (acc, c) => (acc << 1) + (c - '0')))
                       .ToArray();
            }
        }
    }
}
