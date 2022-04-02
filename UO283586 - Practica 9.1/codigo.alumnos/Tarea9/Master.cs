using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practica9
{
    public class Master
    {
        private BitcoinValueData[] vector;

        private int numberOfThreads;

        private int minVal;

        public Master(BitcoinValueData[] vector, int numberOfThreads, int minVal)
        {
            if (numberOfThreads < 1 || numberOfThreads > vector.Length)
                throw new ArgumentException("The number of threads must be lower or equal to the number of elements in the vector.");
            this.vector = vector;
            this.numberOfThreads = numberOfThreads;
            this.minVal = minVal;
        }

        public double ComputeModulus()
        {
            Worker[] workers = new Worker[this.numberOfThreads];
            int itemsPerThread = this.vector.Length / numberOfThreads;
            for (int i = 0; i < this.numberOfThreads; i++)
                workers[i] = new Worker(this.vector,
                    i * itemsPerThread,
                    (i < this.numberOfThreads - 1) ? (i + 1) * itemsPerThread - 1 : this.vector.Length - 1,// last one
                    minVal
                    );

            Thread[] threads = new Thread[workers.Length];
            for (int i = 0; i < workers.Length; i++)
            {
                threads[i] = new Thread(workers[i].Compute);
                threads[i].Name = "Worker Vector Modulus " + (i + 1);
                threads[i].Priority = ThreadPriority.BelowNormal;
                threads[i].Start();

            }

            foreach (var t in threads)
            {
                t.Join();
            }

            long result = 0;
            foreach (Worker worker in workers)
            {
                result += worker.Result;
            }
            return result;
        }
    }
}
