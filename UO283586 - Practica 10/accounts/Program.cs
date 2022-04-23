using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TPP.Laboratory.Concurrency.Lab10
{

    class Program {

        private static void Transfer(BanckAccount cuentaA, BanckAccount cuentaB, decimal importe) {
            Console.WriteLine("Transferring {0:N}€ from account {1} to account {2}...",
                importe, cuentaA.AccountNumber, cuentaB.AccountNumber);
            if (cuentaA.Transferir(cuentaB, importe))
                Console.WriteLine("\tTransfer OK, thread {0}.", Thread.CurrentThread.Name);
            else
                Console.WriteLine("\tERROR in transference, thread {0}.", Thread.CurrentThread.Name);
        }

        public static void Main() {
            decimal importeInicial = 30000;
            BanckAccount accountA = new BanckAccount("A", importeInicial), 
                accountB = new BanckAccount("B", importeInicial);

            Random random = new Random();
            int iterations = 1000;
            Thread[] threads = new Thread[iterations];
            for (int i = 0; i < iterations; i++) {
                decimal amount = (decimal)random.NextDouble() * random.Next(1, 600);
                if (i % 2 == 0)
                    threads[i] = new Thread(() => Transfer(accountA, accountB, amount));
                else
                    threads[i] = new Thread(() => Transfer(accountB, accountA, amount));
                threads[i].Name = "Transfer number " + i;
            }

            foreach (Thread t in threads)
                t.Start();

        }

    }
}
