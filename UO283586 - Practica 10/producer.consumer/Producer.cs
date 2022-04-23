using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPP.Laboratory.Concurrency.Lab10
{

    class Producer {

        private Queue<Product> queue;
        private int numberOfProductsProduced;


        public void Run() {
            Random random = new Random();
            while (true) {
                Product product = new Product(++numberOfProductsProduced);
                Console.WriteLine("+ Enqueuing {0}...", product);
                lock(queue)
                    queue.Enqueue(product);
                Console.WriteLine("+ {0} enqueued.", product);
                Thread.Sleep(random.Next(500, 1000));
            }
        }


        public Producer(Queue<Product> queue) {
            this.queue = queue;
        }
    }
}
