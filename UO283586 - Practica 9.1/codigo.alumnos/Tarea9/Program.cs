using System;
using masterWorker;

namespace Lab09
{

    class Program
    {
        /*
         * This program processes Bitcoin value information obtained from the
         * url https://api.kraken.com/0/public/OHLC?pair=xbteur&interval=5.
         */
        static void Main(string[] args)
        {
            var data = Utils.GetBitcoinData();
            foreach (var d in data)
                Console.WriteLine(d);


            var numberOfThreads = Convert.ToInt32(args[0]);
            Master master = new Master(data, numberOfThreads);
            var result = master.ComputeModulus();
            Console.WriteLine($"Result: {result}");
        }
    }
}
