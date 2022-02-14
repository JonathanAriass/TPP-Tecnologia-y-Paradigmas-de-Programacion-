using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConjuntoLista;
using TPP.Laboratory.ObjectOrientation.Lab02;


namespace TestConjunto
{
    [TestClass]
    public class ConjutosTest
    {

        private Conjunto c;


        [TestInitialize]
        public void InitializeTests()
        {
            // We create the new Set for the Tests
            this.c = new Conjunto();
        }

        /// <summary>
        /// Test for checking that the Set constructor works fine by looking into the Set size
        /// </summary>
        [TestMethod]
        public void ConstructorConjuntoTest()
        {
            Assert.AreEqual(0, this.c.NumberOfElements);
        }
        
        /// <summary>
        /// Test for checking that the property of Set is preserved in the time.
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            c.AddNode(2.3);
            c.AddNode("test");
            c.AddNode(2.3);
            Person p1 = new Person("Pepe", "Ramirez", "23");
            Assert.AreEqual(2, this.c.NumberOfElements);
            string aux1 = "2,3 - test";
            Assert.AreEqual(aux1, this.c.ToString());
            c.AddNode(p1);
            Person p2 = new Person("Pepe", "Ramirez", "23");
            c.AddNode(p2); // We check that another object Person with the same information is not saved into the Set
            Assert.AreEqual(3, this.c.NumberOfElements);
            string aux2 = "2,3 - test - Pepe Ramirez, with 23 ID number";
            Assert.AreEqual(aux2, this.c.ToString());

            // Operador suma +
            Assert.IsTrue(c + 1);
            Assert.AreEqual(4, this.c.NumberOfElements);
            
            string aux3 = "2,3 - test - Pepe Ramirez, with 23 ID number - 1";
            Assert.AreEqual(aux3, this.c.ToString());

            // Operador por indice
            Assert.AreEqual(2.3 , this.c[0]);
        }

        [TestMethod]
        public void UnionOperatorSimpleTest()
        {
            Conjunto c1 = new Conjunto();
            Conjunto c2 = new Conjunto();

            // Añadimos elementos al primer conjunto
            c1.AddNode(1);
            c1.AddNode(2);
            c1.AddNode(3);

            // Añadimos elementos al segundo conjunto
            c2.AddNode(2);
            c2.AddNode(3);
            c2.AddNode(4);

            Conjunto aux = c1 | c2;

            Assert.AreEqual(4, aux.NumberOfElements);

            string auxString = "1 - 2 - 3 - 4";
            Assert.AreEqual(auxString, aux.ToString());
        }

        [TestMethod]
        public void UnionOperatorComplexTest()
        {
            Conjunto c1 = new Conjunto();
            Conjunto c2 = new Conjunto();

            // Añadimos elementos al primer conjunto
            c1.AddNode(1.3);
            c1.AddNode(2);
            c1.AddNode(true);

            Person p1 = new Person("Maria", "Gonzalez", "4556");
            c1.AddNode(p1);

            // Añadimos elementos al segundo conjunto
            c2.AddNode(2);
            c2.AddNode(3);
            c2.AddNode(1.3);
            c2.AddNode(4);
            c2.AddNode(true);
            c2.AddNode(new Person("Maria", "Gonzalez", "4556"));
            c2.AddNode(new Person("Maria", "Gonzalz", "455"));

            Conjunto aux = c1 | c2;

            Assert.AreEqual(7, aux.NumberOfElements);

            string auxString = "1,3 - 2 - True - Maria Gonzalez, with 4556 ID number - 3 - 4 - Maria Gonzalz, with 455 ID number";
            Assert.AreEqual(auxString, aux.ToString());
        }

        [TestMethod]
        public void InterseccionOperatorSimpleTest()
        {
            Conjunto c1 = new Conjunto();
            Conjunto c2 = new Conjunto();

            // Añadimos elementos al primer conjunto
            c1.AddNode(1);
            c1.AddNode(2);
            c1.AddNode(3);

            // Añadimos elementos al segundo conjunto
            c2.AddNode(2);
            c2.AddNode(3);
            c2.AddNode(4);

            Conjunto aux = c1 & c2;

            Assert.AreEqual(2, aux.NumberOfElements);

            string auxString = "2 - 3";
            Assert.AreEqual(auxString, aux.ToString());
        }


        [TestMethod]
        public void InterseccionOperatorComplexTest()
        {
            Conjunto c1 = new Conjunto();
            Conjunto c2 = new Conjunto();

            // Añadimos elementos al primer conjunto
            c1.AddNode(1.3);
            c1.AddNode(2);
            c1.AddNode(true);

            Person p1 = new Person("Maria", "Gonzalez", "4556");
            c1.AddNode(p1);

            // Añadimos elementos al segundo conjunto
            c2.AddNode(2);
            c2.AddNode(3);
            c2.AddNode(1.3);
            c2.AddNode(4);
            c2.AddNode(true);
            c2.AddNode(new Person("Maria", "Gonzalez", "4556"));
            c2.AddNode(new Person("Maria", "Gonzalz", "455"));

            Conjunto aux = c1 & c2;

            Assert.AreEqual(4, aux.NumberOfElements);

            string auxString = "2 - 1,3 - True - Maria Gonzalez, with 4556 ID number";
            Assert.AreEqual(auxString, aux.ToString());
        }

        [TestMethod]
        public void DiferenciaOperatorSimpleTest()
        {
            Conjunto c1 = new Conjunto();
            Conjunto c2 = new Conjunto();

            // Añadimos elementos al primer conjunto
            c1.AddNode(1);
            c1.AddNode(2);
            c1.AddNode(3);

            // Añadimos elementos al segundo conjunto
            c2.AddNode(2);
            c2.AddNode(3);
            c2.AddNode(4);

            Conjunto aux = c1 - c2;

            Assert.AreEqual(1, aux.NumberOfElements);

            string auxString = "4";
            Assert.AreEqual(auxString, aux.ToString());
        }

        [TestMethod]
        public void DiferenciaOperatorComplexTest()
        {
            Conjunto c1 = new Conjunto();
            Conjunto c2 = new Conjunto();

            // Añadimos elementos al primer conjunto
            c1.AddNode(1.3);
            c1.AddNode(2);
            c1.AddNode(true);

            Person p1 = new Person("Maria", "Gonzalez", "4556");
            c1.AddNode(p1);

            // Añadimos elementos al segundo conjunto
            c2.AddNode(2);
            c2.AddNode(3);
            c2.AddNode(1.3);
            c2.AddNode(4);
            c2.AddNode(true);
            c2.AddNode(new Person("Maria", "Gonzalez", "4556"));
            c2.AddNode(new Person("Maria", "Gonzalz", "455"));

            Conjunto aux = c1 - c2;

            Assert.AreEqual(3, aux.NumberOfElements);

            string auxString = "3 - 4 - Maria Gonzalz, with 455 ID number";
            Assert.AreEqual(auxString, aux.ToString());
        }
    }
}
