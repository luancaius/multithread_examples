using System;
using System.Threading;
using System.Diagnostics;

namespace Thread1
{
    class Program
    {
        private static int _total;
        private static object obj = new object();
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            _total = 0;
            Console.WriteLine("Starting Main");
            sw.Start();
            Job1();
            Job2();
            Job3();
            sw.Stop();
            Console.WriteLine(_total);
            Console.WriteLine("Without Thread - Elapsed={0}", sw.Elapsed);

            Console.WriteLine("Starting threads");
            var thr1 = new Thread(Job1);
            var thr2 = new Thread(Job2);
            var thr3 = new Thread(Job3);
            _total = 0;
            sw2.Start();
            thr1.Start();
            thr2.Start();
            thr3.Start();
            thr1.Join();
            thr2.Join();
            thr3.Join();

            sw2.Stop();
            Console.WriteLine(_total);
            Console.WriteLine("Using Thread - Elapsed={0}", sw2.Elapsed);

            Console.ReadLine();
        }

        public static void Job1()
        {
            for (int i = 0; i < 200; i++)
            {
                // do something
                Thread.Sleep(100);
                lock (obj)
                {
                    _total++;
                }
            }       
        }

        public static void Job2()
        {
            for (int i = 0; i < 40; i++)
            {
                // do something
                Thread.Sleep(500);
                lock (obj)
                {
                    _total+=10;
                }
            }
        }
        public static void Job3()
        {
            for (int i = 0; i < 200; i++)
            {
                // do something
                Thread.Sleep(100);
                lock (obj)
                {
                    _total+=100;
                }
            }
        }
    }    
}
