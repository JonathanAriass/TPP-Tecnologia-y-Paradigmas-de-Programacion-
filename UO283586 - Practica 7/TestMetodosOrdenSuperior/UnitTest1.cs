using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListaEnlazada;
using System;
using TPP.Laboratory.Functional.Lab05;
using System.Linq;

namespace TestMetodosOrdenSuperior
{
    [TestClass]
    public class UnitTest1
    {
        private Lista<Object> lista;


        [TestInitialize]
        public void InitializeTests()
        {
            // We create the new List for the Tests
            this.lista = new Lista<Object>();
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetElementExceptionTest()
        {
            this.lista.Add(true);
            this.lista.GetElement(2);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetElementExceptionTest2()
        {
            this.lista.GetElement(2);
        }


        /// <summary>
        /// Test that checks method AddNode() works fine by adding 3 different types
        /// of nodes: int, string, bool
        /// </summary>
        [TestMethod]
        public void AddNodeBaseTest()
        {
            this.lista.Add(4);
            this.lista.Add("Test");
            this.lista.Add(true);
            Person p1 = new Person("Pepe", "Ramirez", "8191233");
            this.lista.Add(p1);
            Assert.AreEqual(4, this.lista.NumberOfElements);
            Assert.AreEqual(true, this.lista.GetElement(2));
            Assert.AreEqual("Test", this.lista.GetElement(1));
            Assert.AreEqual(new Person("Pepe", "Ramirez", "8191233"), this.lista.GetElement(3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNodeExceptionTest()
        {
            this.lista.Add(null);
        }


        /// <summary>
        /// Test that checks method AddNode() (index version) works fine by adding several nodes.
        /// </summary>
        [TestMethod]
        public void AddNodeByIndexTest()
        {
            this.lista.Add(4, 0);
            this.lista.Add("Test", 0);
            this.lista.Add(true, 0);
            Assert.AreEqual(3, this.lista.NumberOfElements);
            Assert.AreEqual(true, this.lista.GetElement(0));
            Assert.AreEqual("Test", this.lista.GetElement(1));
            Assert.AreEqual(4, this.lista.GetElement(2));
            this.lista.Add("Maria", 2);
            this.lista.Add(3489, 1);
            Person p1 = new Person("Pepe", "Ramirez", "8191233");
            this.lista.Add(p1, 0);
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
            this.lista.Add(4, 0);
            this.lista.Add("Test", 0);
            this.lista.Add(true, 0);
            this.lista.Add("Maria", 2);
            this.lista.Add(3489, 1);
            Assert.AreEqual(5, this.lista.NumberOfElements);
            this.lista.Remove("Maria");
            Assert.AreEqual(4, this.lista.NumberOfElements);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveNodeExceptionTest()
        {
            this.lista.Remove(true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNodeExceptionTest2()
        {
            this.lista.Remove(null);
        }

        /// <summary>
        /// Test that checks methos Contains() works fine by searching for several elements on the list.
        /// </summary>
        [TestMethod]
        public void ContainsTest()
        {
            this.lista.Add(4, 0);
            this.lista.Add("Test", 0);
            this.lista.Add(true, 0);
            this.lista.Add("Maria", 2);
            this.lista.Add(3489, 1);
            Person p1 = new Person("Pepe", "Ramirez", "8191233");
            this.lista.Add(p1);
            Assert.IsTrue(this.lista.Contains("Maria"));
            Assert.IsFalse(this.lista.Contains("Mari"));
            Assert.IsTrue(this.lista.Contains(3489));
            Assert.IsTrue(this.lista.Contains(true));
            Assert.IsTrue(this.lista.Contains(new Person("Pepe", "Ramirez", "8191233")));
            Assert.IsFalse(this.lista.Contains(new Person("Pep", "Ramirez", "8191233")));
            Assert.IsFalse(this.lista.Contains(new Person("Pepe", "Ramrez", "8191233")));
            Assert.IsFalse(this.lista.Contains(new Person("Pepe", "Ramirez", "81913")));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ContainsExceptionTest()
        {
            this.lista.Contains(true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ContainsExceptionTest2()
        {
            this.lista.Contains(null);
        }

        [TestMethod]
        public void FindTest()
        {
            Lista<Person> lista2 = new Lista<Person>();
            lista2.Add(new Person("Pepe", "Ramirez", "8191233"), 0);
            lista2.Add(new Person("Maria", "Gonzalez", "1738132"), 0);
            lista2.Add(new Person("Pepe", "Reverte", "6521233"), 0);
            foreach (Person p in lista2)
            {
                Console.WriteLine(p.ToString());
            }
            Predicate<Person> buscar = x => x.FirstName.Equals("Pepe");
            var res = lista2.Buscar(buscar);
            Assert.AreEqual(res.FirstName, "Pepe");
            Assert.AreEqual(res.Surname, "Reverte");
            Assert.AreEqual(res.IDNumber, "6521233");
        }


        [TestMethod]
        public void FindAngle()
        {
            Lista<Angle> angles = new Lista<Angle>();
            angles.Add(new Angle(89),0);
            angles.Add(new Angle(90), 0);
            angles.Add(new Angle(120), 1);
            angles.Add(new Angle(265), 0);
            Predicate<Angle> buscar = x => x.Quadrant.Equals(1);
            var res = angles.Buscar(buscar);
            Assert.AreEqual(res.Degrees, 90);
            Assert.AreEqual(res.Quadrant, 1);
        }


        [TestMethod]
        public void FilterPeople() 
        {
            Lista<Person> lista2 = new Lista<Person>();
            lista2.Add(new Person("Pepe", "Ramirez", "8191233"), 0);
            lista2.Add(new Person("Maria", "Gonzalez", "1738132"), 0);
            lista2.Add(new Person("Pepe", "Reverte", "6521233"), 0);
            Predicate<Person> filtrar = x => x.FirstName.Equals("Pepe");
            var res = lista2.Filtrar(filtrar);

            var x1 = "";
            var a1 = "";
            var x2 = "";
            var a2 = "";
            var cont = 0;
            foreach (Person i in res)
            {
                Console.WriteLine(i.FirstName);
                if (cont == 0) { x1 = i.FirstName; a1 = i.Surname; cont++; }
                else if (cont == 1) { x2 = i.FirstName; a2 = i.Surname; cont++; }
            }

            Assert.AreEqual(2, res.Count());
            Assert.AreEqual("Pepe", x1);
            Assert.AreEqual("Reverte", a1);
            Assert.AreEqual("Pepe", x2);
            Assert.AreEqual("Ramirez", a2);
        }

        [TestMethod]
        public void FilterAngle()
        {
            Lista<Angle> angles = new Lista<Angle>();
            angles.Add(new Angle(89), 0);
            angles.Add(new Angle(90), 0);
            angles.Add(new Angle(120), 1);
            angles.Add(new Angle(265), 0);
            Predicate<Angle> filtrar = x => x.Quadrant.Equals(1);
            var res = angles.Filtrar(filtrar);

            float a1 = 0;
            float a2 = 0;
            var cont = 0;
            foreach (Angle i in res)
            {
                Console.WriteLine(i.Degrees);
                if (cont == 0) {a1 = i.Degrees; cont++; }
                else if (cont == 1) {a2 = i.Degrees; cont++; }
            }

            Assert.AreEqual(2, res.Count());
            Assert.AreEqual(90, a1);
            Assert.AreEqual(89, a2);
        }

        [TestMethod]
        public void ReducePeople()
        {
            Lista<Person> lista2 = new Lista<Person>();
            lista2.Add(new Person("Pepe", "Ramirez", "8191233"), 0);
            lista2.Add(new Person("Maria", "Gonzalez", "1738132"), 0);
            lista2.Add(new Person("Pepe", "Reverte", "6521233"), 0);

            Func<int ,Person, int> reducir = (int acc, Person x) => acc += x.FirstName.Length;
            var res = lista2.Reducir(reducir);

            Assert.AreEqual(13, res); 
        }

        [TestMethod]
        public void ReduceAngle()
        {
            Lista<Angle> angles = new Lista<Angle>();
            angles.Add(new Angle(89), 0);
            angles.Add(new Angle(90), 0);
            angles.Add(new Angle(120), 1);
            angles.Add(new Angle(265), 0);

            Func<double, Angle, double> reducir = (double acc, Angle x) => acc += x.Degrees;
            var res = angles.Reducir(reducir);

            Assert.AreEqual(564, res);
        }

        [TestMethod]
        public void InvertTest() 
        {
            Lista<Person> lista2 = new Lista<Person>();
            lista2.Add(new Person("Pepe", "Ramirez", "8191233"), 0);
            lista2.Add(new Person("Maria", "Gonzalez", "1738132"), 0);
            lista2.Add(new Person("Pepe", "Reverte", "6521233"), 0);
            var res = lista2.Invert();


            var x1 = "";
            var a1 = "";
            var x2 = "";
            var a2 = "";
            var x3 = "";
            var a3 = "";
            var cont = 0;
            foreach (Person i in res)
            {
                Console.WriteLine(i.FirstName);
                if (cont == 0) { x1 = i.FirstName; a1 = i.Surname; cont++; }
                else if (cont == 1) { x2 = i.FirstName; a2 = i.Surname; cont++; }
                else if (cont == 2) { x3 = i.FirstName; a3 = i.Surname; cont++; }
            }

            Assert.AreEqual(3, res.Count());
            Assert.AreEqual("Pepe", x1);
            Assert.AreEqual("Ramirez", a1);
            Assert.AreEqual("Maria", x2);
            Assert.AreEqual("Gonzalez", a2);
            Assert.AreEqual("Pepe", x3);
            Assert.AreEqual("Reverte", a3);
        }

        [TestMethod]
        public void InvertTest2()
        {
            Lista<Person> lista2 = new Lista<Person>();
            lista2.Add(new Person("Pepe", "Ramirez", "8191233"));
            lista2.Add(new Person("Maria", "Gonzalez", "1738132"));
            lista2.Add(new Person("Pepe", "Reverte", "6521233"));
            var res = lista2.Invert();


            var x1 = "";
            var a1 = "";
            var x2 = "";
            var a2 = "";
            var x3 = "";
            var a3 = "";
            var cont = 0;
            foreach (Person i in res)
            {
                Console.WriteLine(i.FirstName);
                if (cont == 0) { x1 = i.FirstName; a1 = i.Surname; cont++; }
                else if (cont == 1) { x2 = i.FirstName; a2 = i.Surname; cont++; }
                else if (cont == 2) { x3 = i.FirstName; a3 = i.Surname; cont++; }
            }

            Assert.AreEqual(3, res.Count());
            Assert.AreEqual("Pepe", x1);
            Assert.AreEqual("Reverte", a1);
            Assert.AreEqual("Maria", x2);
            Assert.AreEqual("Gonzalez", a2);
            Assert.AreEqual("Pepe", x3);
            Assert.AreEqual("Ramirez", a3);
        }

    }
}
