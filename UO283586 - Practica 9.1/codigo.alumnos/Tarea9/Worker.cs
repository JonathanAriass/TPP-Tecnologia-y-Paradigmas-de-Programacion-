using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica9
{
    internal class Worker
    {

        private BitcoinValueData[] vector;

        private int fromIndex, toIndex;

        private long result;

        private int minVal;

        internal long Result
        {
            get { return this.result; }
        }

        internal Worker(BitcoinValueData[] vector, int fromIndex, int toIndex, int minVal)
        {
            this.vector = vector;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
            this.minVal = minVal;
        }

        internal void Compute()
        {
            this.result = 0;
            for (int i = this.fromIndex; i <= this.toIndex; i++)
                if (this.vector[i].Value > minVal)
                {
                    this.result += 1;
                }
        }

    }
}
