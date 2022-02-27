using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPP.Laboratory.ObjectOrientation.Lab03;
using System;

namespace TestStack
{
    [TestClass]
    public class StackTest
    {

        private Stack stack10; // The number after the name means the maximum number of elements


        /// <summary>
        /// Test that initialize the stack for every test on this file
        /// </summary>
        [TestInitialize]
        public void InitializeTests()
        {
            this.stack10 = new Stack(5);
        }

        /// <summary>
        /// Test that checks the size of the stack is 0 (is empty) after creating it.
        /// </summary>
        [TestMethod]
        public void ConstructorStackTest()
        {
            Assert.IsTrue(this.stack10.IsEmpty);
        }

        [TestMethod]
        public void PushStackSimpleTest()
        {
            Assert.IsTrue(this.stack10.IsEmpty);
            Assert.IsFalse(this.stack10.IsFull);
            stack10.Push(5);
            stack10.Push(56);
            stack10.Push(6);
            stack10.Push(1);
            stack10.Push(8);
            string aux = "5 - 56 - 6 - 1 - 8";
            Assert.AreEqual(aux, this.stack10.ToString());

            // Se comprueba que el stack esta lleno y por eso 
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PushStackErrorTest()
        {
            stack10.Push(5);
            stack10.Push(56);
            stack10.Push(6);
            stack10.Push(1);
            stack10.Push(8);
            string aux = "5 - 56 - 6 - 1 - 8";
            Assert.AreEqual(aux, this.stack10.ToString());
            Assert.IsTrue(this.stack10.IsFull);

            // Aqui se intenta añadir otro elemento, pero al estar lleno el stack se lanza
            // una excepcion
            stack10.Push(10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PushStackErrorTest2()
        {
            stack10.Push(5);
            stack10.Push(56);
            stack10.Push(6);
            stack10.Push(1);
            string aux = "5 - 56 - 6 - 1";
            Assert.AreEqual(aux, this.stack10.ToString());
            Assert.IsFalse(this.stack10.IsFull);

            // Aqui se intenta añadir otro elemento, pero al ser null se lanza una excepcion
            stack10.Push(null);
        }

        [TestMethod]
        public void PushStackComplexTest()
        {
            stack10 = new Stack(10);
            stack10.Push(6.04);
            stack10.Push("Test");
            stack10.Push(5);
            stack10.Push(true);
            stack10.Push(false);
            stack10.Push(new Person("Alberto", "Garcia", "28290"));
            stack10.Push(10002);
            stack10.Push(82923.1223);
            stack10.Push("Fin");
            string aux = "6,04 - Test - 5 - True - False - Alberto Garcia, with 28290 ID number - 10002 - 82923,1223 - Fin";
            Assert.AreEqual(aux, this.stack10.ToString());
        }

        [TestMethod]
        public void PopStackTest()
        {
            stack10 = new Stack(10);
            stack10.Push(6.04);
            stack10.Push("Test");
            stack10.Push(5);
            stack10.Push(true);
            stack10.Push(false);
            stack10.Push(new Person("Alberto", "Garcia", "28290"));
            stack10.Push(10002);
            stack10.Push(82923.1223);
            stack10.Push("Fin");

            string aux = "6,04 - Test - 5 - True - False - Alberto Garcia, with 28290 ID number - 10002 - 82923,1223 - Fin";
            Assert.AreEqual(aux, this.stack10.ToString());


            Assert.AreEqual("Fin", this.stack10.Pop());
            string aux10 = "6,04 - Test - 5 - True - False - Alberto Garcia, with 28290 ID number - 10002 - 82923,1223";
            Assert.AreEqual(aux10, this.stack10.ToString());

            Assert.AreEqual(82923.1223, this.stack10.Pop());
            string aux9 = "6,04 - Test - 5 - True - False - Alberto Garcia, with 28290 ID number - 10002";
            Assert.AreEqual(aux9, this.stack10.ToString());

            Assert.AreEqual(10002, this.stack10.Pop());
            string aux8 = "6,04 - Test - 5 - True - False - Alberto Garcia, with 28290 ID number";
            Assert.AreEqual(aux8, this.stack10.ToString());

            Assert.AreEqual(new Person("Alberto", "Garcia", "28290"), this.stack10.Pop());
            string aux7 = "6,04 - Test - 5 - True - False";
            Assert.AreEqual(aux7, this.stack10.ToString());

            Assert.AreEqual(false, this.stack10.Pop());
            string aux6 = "6,04 - Test - 5 - True";
            Assert.AreEqual(aux6, this.stack10.ToString());

            Assert.AreEqual(true, this.stack10.Pop());
            string aux5 = "6,04 - Test - 5";
            Assert.AreEqual(aux5, this.stack10.ToString());

            Assert.AreEqual(5, this.stack10.Pop());
            string aux4 = "6,04 - Test";
            Assert.AreEqual(aux4, this.stack10.ToString());

            Assert.AreEqual("Test", this.stack10.Pop());
            string aux3 = "6,04";
            Assert.AreEqual(aux3, this.stack10.ToString());

            Assert.AreEqual(6.04, this.stack10.Pop());
            string aux2 = "";
            Assert.AreEqual(aux2, this.stack10.ToString());         
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopErrorTest1()
        {
            Assert.AreEqual("", this.stack10.ToString());
            stack10.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopErrorTest2()
        {
            stack10 = new Stack(10);
            stack10.Push(6.04);
            stack10.Push("Test");
            stack10.Push(5);
            stack10.Push(true);
            stack10.Push(false);
            stack10.Push(new Person("Alberto", "Garcia", "28290"));
            stack10.Push(10002);
            stack10.Push(82923.1223);
            stack10.Push("Fin");
            string aux = "6,04 - Test - 5 - True - False - Alberto Garcia, with 28290 ID number - 10002 - 82923,1223 - Fin";
            Assert.AreEqual(aux, this.stack10.ToString());


            Assert.AreEqual("Fin", this.stack10.Pop());
            string aux10 = "6,04 - Test - 5 - True - False - Alberto Garcia, with 28290 ID number - 10002 - 82923,1223";
            Assert.AreEqual(aux10, this.stack10.ToString());

            Assert.AreEqual(82923.1223, this.stack10.Pop());
            string aux9 = "6,04 - Test - 5 - True - False - Alberto Garcia, with 28290 ID number - 10002";
            Assert.AreEqual(aux9, this.stack10.ToString());

            Assert.AreEqual(10002, this.stack10.Pop());
            string aux8 = "6,04 - Test - 5 - True - False - Alberto Garcia, with 28290 ID number";
            Assert.AreEqual(aux8, this.stack10.ToString());

            Assert.AreEqual(new Person("Alberto", "Garcia", "28290"), this.stack10.Pop());
            string aux7 = "6,04 - Test - 5 - True - False";
            Assert.AreEqual(aux7, this.stack10.ToString());

            Assert.AreEqual(false, this.stack10.Pop());
            string aux6 = "6,04 - Test - 5 - True";
            Assert.AreEqual(aux6, this.stack10.ToString());

            Assert.AreEqual(true, this.stack10.Pop());
            string aux5 = "6,04 - Test - 5";
            Assert.AreEqual(aux5, this.stack10.ToString());

            Assert.AreEqual(5, this.stack10.Pop());
            string aux4 = "6,04 - Test";
            Assert.AreEqual(aux4, this.stack10.ToString());

            Assert.AreEqual("Test", this.stack10.Pop());
            string aux3 = "6,04";
            Assert.AreEqual(aux3, this.stack10.ToString());

            Assert.AreEqual(6.04, this.stack10.Pop());
            string aux2 = "";
            Assert.AreEqual(aux2, this.stack10.ToString());

            // aque si produce la excepcion al intentar obtener algo cuando no hay nada en la lista
            stack10.Pop();
        }

    }
}
