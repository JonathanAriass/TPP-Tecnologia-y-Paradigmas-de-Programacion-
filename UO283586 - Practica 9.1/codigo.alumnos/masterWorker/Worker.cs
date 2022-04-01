using System;
using System.Collections.Generic;
using System.Text;

namespace masterWorker
{
    internal class Worker
    {

        private short[] vector;

        private int fromIndex, toIndex;

        private long result;

        internal long Result
        {
            get { return this.result; }
        }

        internal Worker(short[] vector, int fromIndex, int toIndex)
        {
            this.vector = vector;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
        }

        internal async void Compute(int minVal)
        {
            this.result = 0;
            for (int i = this.fromIndex; i <= this.toIndex; i++)
                if (this.vector[i] > minVal) {
                    this.result++;
                }
        }

    }
}
