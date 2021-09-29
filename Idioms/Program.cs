using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Idioms
{
    /// <summary>
    /// https://programming-idioms.org/about#about-block-all-idioms
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Idiom25();
            //Idiom56().GetAwaiter().GetResult();
        }

        public static void Idiom2()
        {
            Console.WriteLine(string.Join(Environment.NewLine, Enumerable.Repeat("Hello", 10)));
        }

        public static void Idiom25()
        {
            string value = null;

            using(var readyEvent = new ManualResetEvent(false))
            {
                var thread = new Thread(() =>
                {
                    readyEvent.WaitOne();
                    Console.WriteLine(value);
                });

                thread.Start();

                value = "Alan";
                readyEvent.Set();

                thread.Join();
            }
        }

        public static async Task Idiom56()
        {
            var tasksToCreate = 1000;
            var tasks = new Task[tasksToCreate];

            for(int i = 0; i < tasksToCreate; i++)
            {
                var capture = i;
                tasks[i] = Task.Run(() => f(capture));
            }

            await Task.WhenAll(tasks);
            Console.WriteLine("Finished");

            static async Task f(int value)
            {
                // Do something with value. Delay to simulate work
                await Task.Delay(500);
            }
        }

        public static void Idiom238()
        {
            byte[] a = {1, 2, 3, 4};
            byte[] b = {10, 11, 12, 13};

            var c = a.Zip(b, (l, r) => (byte)(l ^ r)).ToArray();
        }

        public static void Idiom254()
        {
            var x = new List<string>();
        }

        public static void Idiom257()
        {
            var items = new List<string>(){"A", "B", "C", "D"};

            for(int i = items.Count -1; i >= 0; i--)
            {
                Console.WriteLine($"Index = {i}, Item = {items[i]}");
            }
        }

        public static void Idiom259()
        {
            var s = "Hello,there_bob-smith";
            var parts = s.Split(',', '-', '_');
        }

        public static void Idiom261()
        {
            var date = new DateTime(2021, 12, 25, 14, 23, 52);
            var x = date.ToString("HH:mm:ss");

            Console.WriteLine(x);
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
