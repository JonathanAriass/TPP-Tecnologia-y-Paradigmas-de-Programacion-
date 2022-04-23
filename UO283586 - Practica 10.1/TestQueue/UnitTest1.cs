using ConcurrentQueue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestQueue
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ConcurrentQueue<int> cq = new ConcurrentQueue<int>();
            cq.Enqueue(5);
            cq.Peek();
            cq.Dequeue();
            cq.Enqueue(4);
        }
    }
}
