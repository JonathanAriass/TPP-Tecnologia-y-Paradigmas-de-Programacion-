using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPP.Laboratory.ObjectOrientation.Lab03;

namespace ListaEnlazada
{
    [TestClass]
    public class ListTest
    {

        private List lista;


        [TestInitialize]
        public void InitializeTests()
        {
            // We create the new List for the Tests
            this.lista = new List();
        }

        /// <summary>
        /// Method that test the Constructor of the Object List.
        /// It checks that the number of elements in list is equal to 0.
        /// </summary>
        [TestMethod]
        public void CosntructorListTest()
        {
            Assert.AreEqual(0, this.lista.NumberOfElements);
        }

        /// <summary>
        /// Test that checks method AddNode() works fine by adding 3 different types
        /// of nodes: int, string, bool
        /// </summary>
        [TestMethod]
        public void AddNodeBaseTest()
        {
            this.lista.AddNode(4);
            this.lista.AddNode("Test");
            this.lista.AddNode(true);
            Person p1 = new Person("Pepe", "Ramirez", "8191233");
            this.lista.AddNode(p1);
            Assert.AreEqual(4, this.lista.NumberOfElements);
            Assert.AreEqual(true, this.lista.GetElement(2));
            Assert.AreEqual("Test", this.lista.GetElement(1));
            Assert.AreEqual(new Person("Pepe", "Ramirez", "8191233"), this.lista.GetElement(3));
        }

        /// <summary>
        /// Test that checks method AddNode() (index version) works fine by adding several nodes.
        /// </summary>
        [TestMethod]
        public void AddNodeByIndexTest()
        {
            this.lista.AddNode(4, 0);
            this.lista.AddNode("Test",0);
            this.lista.AddNode(true,0);
            Assert.AreEqual(3, this.lista.NumberOfElements);
            Assert.AreEqual(true, this.lista.GetElement(0));
            Assert.AreEqual("Test", this.lista.GetElement(1));
            Assert.AreEqual(4, this.lista.GetElement(2));
            this.lista.AddNode("Maria", 2);
            this.lista.AddNode(3489, 1);
            Person p1 = new Person("Pepe", "Ramirez", "8191233");
            this.lista.AddNode(p1, 0);
            Assert.AreEqual(new Person("Pepe", "Ramirez", "8191233"), this.lista.GetElement(0));
            Assert.AreEqual(true, this.lista.GetElement(1));
            Assert.AreEqual(3489, this.lista.GetElement(2));
            Assert.AreEqual("Test", this.lista.GetElement(3));
            Assert.AreEqual("Maria", this.lista.GetElement(4));
            Assert.AreEqual(4, this.lista.GetElement(5));
            Assert.AreEqual(6, this.lista.NumberOfElements);
        }


        /// <summary>
        /// Test that checks method RemoveNode() works fine by adding nodes to the list,
        /// removing them and study how the list size changes through time.
        /// </summary>
        [TestMethod]
        public void RemoveNodeTest()
        {
            // Nodes added in the past test that works fine
            this.lista.AddNode(4, 0);
            this.lista.AddNode("Test", 0);
            this.lista.AddNode(true, 0);
            this.lista.AddNode("Maria", 2);
            this.lista.AddNode(3489, 1);
            Assert.AreEqual(5, this.lista.NumberOfElements);
            this.lista.Remove("Maria");
            Assert.AreEqual(4, this.lista.NumberOfElements);
        }

        /// <summary>
        /// Test that checks methos Contains() works fine by searching for several elements on the list.
        /// </summary>
        [TestMethod]
        public void ContainsTest()
        {
            this.lista.AddNode(4, 0);
            this.lista.AddNode("Test", 0);
            this.lista.AddNode(true, 0);
            this.lista.AddNode("Maria", 2);
            this.lista.AddNode(3489, 1);
            Person p1 = new Person("Pepe", "Ramirez", "8191233");
            this.lista.AddNode(p1);
            Assert.IsTrue(this.lista.Contains("Maria"));
            Assert.IsFalse(this.lista.Contains("Mari"));
            Assert.IsTrue(this.lista.Contains(3489));
            Assert.IsTrue(this.lista.Contains(true));
            Assert.IsTrue(this.lista.Contains(new Person("Pepe", "Ramirez", "8191233")));
            Assert.IsFalse(this.lista.Contains(new Person("Pep", "Ramirez", "8191233")));
            Assert.IsFalse(this.lista.Contains(new Person("Pepe", "Ramrez", "8191233")));
            Assert.IsFalse(this.lista.Contains(new Person("Pepe", "Ramirez", "81913")));
        }
    }
}
