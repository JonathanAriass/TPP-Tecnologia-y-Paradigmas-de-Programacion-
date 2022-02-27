using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace test.diccionario
{
    [TestClass]
    public class DiccionarioTest
    {

        private IDictionary<int, object> dictionary; // En este caso la key es un ID (int)

        [TestInitialize]
        public void InitializeTests()
        {
            // We create the new List for the Tests
            this.dictionary = new Dictionary<int, object>();
            dictionary.Add(1, "Alberto");
            dictionary.Add(2, false);
            dictionary.Add(3, "Test");
            dictionary.Add(4, 5.6);
        }

        [TestMethod]
        public void AddAndNumberOfElementsDictionaryTest()
        {
            Assert.AreEqual(4, dictionary.Count);
        }

        [TestMethod]
        public void UpdateValueTest()
        {
            Assert.AreEqual("Test", dictionary[3]);
            Assert.AreEqual(4, dictionary.Count);
            dictionary[3] = "test";
            Assert.AreEqual("test", dictionary[3]);
            Assert.AreEqual(4, dictionary.Count);
        }


        [TestMethod]
        public void IsValueSavedTest()
        {
            Assert.IsTrue(dictionary.ContainsKey(3));
            Assert.IsFalse(dictionary.ContainsKey(6));
            Assert.AreEqual(false, dictionary[2]);
            Assert.AreEqual("Alberto", dictionary[1]);
        }

        [TestMethod]
        public void RemoveExistingValueTest()
        {
            Assert.IsTrue(dictionary.Remove(3));
            Assert.AreEqual(3, dictionary.Count);
            Assert.IsFalse(dictionary.Remove(49));
        }

        [TestMethod]
        public void ForEachTest()
        {
            int count = 0;

            foreach (KeyValuePair<int, object> pair in dictionary)
            {
                count++;
            }

            Assert.AreEqual(4, count);
        }
    }
}
