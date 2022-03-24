using System;
using System.Threading;
using System.Text;

namespace TPP.Laboratory.Concurrency.Lab09 {

    internal class MessageThread {

        private static uint numberOfThreads = 0;

        internal uint ThreadNumber { get; private set; }

        internal MessageThread() {
            this.ThreadNumber = ++numberOfThreads;
        }

        private Random random = new Random(DateTime.Now.Millisecond);

        private static string MultiplyString(string str, uint number) {
            StringBuilder sb = new StringBuilder();
            for (uint i = 0; i < number; i++)
                sb.Append(str);
            return sb.ToString();
        }

        internal void Run() {
            while (true) {
                Thread.Sleep(this.random.Next(500, 2000)); // Para que el scheduler no se vuelva loco y le de tiempo a crear otros procesos
                Console.WriteLine("{0}Thread {1}, ThreadID {2}.", 
                    MultiplyString("-", this.ThreadNumber),
                    this.ThreadNumber,
                    Thread.CurrentThread.ManagedThreadId);
            }
        }


    }
}
