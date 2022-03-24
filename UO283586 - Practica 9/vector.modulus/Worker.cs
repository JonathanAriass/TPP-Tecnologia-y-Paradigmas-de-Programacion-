
namespace TPP.Laboratory.Concurrency.Lab09 {

    internal class Worker {

        private short[] vector;

        private int fromIndex, toIndex;

        private long result;

        internal long Result {
            get { return this.result; }
        }

        internal Worker(short[] vector, int fromIndex, int toIndex) {
            this.vector = vector;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
        }

        internal void Compute() {
            this.result = 0;
            for(int i= this.fromIndex; i<=this.toIndex; i++)
                this.result += this.vector[i] * this.vector[i];
        }

    }

}
