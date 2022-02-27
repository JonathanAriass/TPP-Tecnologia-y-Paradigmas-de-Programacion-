using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace test.vector
{
    [TestClass]
    public class VectorTest
    {
        private IList<object> lista;

        [TestInitialize]
        public void InitializeTests()
        {
            // We create the new List for the Tests
            this.lista = new List<object>();
            lista.Add(5);
            lista.Add(true);
            lista.Add(false);
            lista.Add("Test");
            lista.Add(6.7);
        }

        [TestMethod]
        public void AddIListTest()
        {
            Assert.AreEqual(5, lista[0]);
            Assert.AreEqual(true, lista[1]);
            Assert.AreEqual(false, lista[2]);
        }

        [TestMethod]
        public void NumberOfElementsTest()
        {
            int contador = 0;

            foreach (object element in lista)
            {
                contador++;
            }

            Assert.AreEqual(5, lista.Count);
            Assert.AreEqual(5, contador);
        }


        [TestMethod]
        public void GetAndWriteOnNElementTest()
        {
            Assert.AreEqual(false, lista[2]);
            var aux = lista[2];

            lista[2] = "cambiado";
            Assert.AreEqual("cambiado", lista[2]);
        }


        [TestMethod]
        public void IsElementOnListTest()
        {
            Assert.AreEqual("Test", lista[3]);

            Assert.IsTrue(lista.Contains("Test"));
            Assert.IsFalse(lista.Contains("test"));
        }


        [TestMethod]
        public void IndexOfElementTest()
        {
            lista.Add("Test");
            var index = lista.IndexOf("Test");
            Assert.AreEqual(3, index);
        }

        [TestMethod]
        public void IndexOfUnfoundElementTest()
        {
            var index = lista.IndexOf(9);
            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void RemoveGivenElementTest()
        {
            Assert.IsTrue(lista.Remove(true));
            Assert.AreEqual(4, lista.Count);

            Assert.IsFalse(lista.Remove(true)); // ya no esta en la lista
            Assert.AreEqual(4, lista.Count);
        }
    }
}
