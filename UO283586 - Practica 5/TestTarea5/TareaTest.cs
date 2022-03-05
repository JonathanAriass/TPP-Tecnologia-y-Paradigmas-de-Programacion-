using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TPP.Laboratory.Functional.Lab05
{
    [TestClass]
    public class TareaTest
    {

        Person[] people;
        Angle[] angles;

        [TestInitialize]
        public void Initialize() 
        {
            people = Factory.CreatePeople();
            angles = Factory.CreateAngles();
        }

        [TestMethod]
        public void FindPeopleTest()
        {
            // Test con Find() de C#
            Person person = Array.Find(people, x=>x.FirstName.Equals("Pepe") && x.IDNumber.EndsWith('R'));
            Assert.AreEqual(person.FirstName, "Pepe");
            Assert.AreEqual(person.Surname, "Hevia");
            Assert.AreEqual(person.IDNumber, "23476293R");

            person = Array.Find(people, x => x.FirstName.Equals("María") && x.IDNumber.EndsWith('A'));
            Assert.AreEqual(person.FirstName, "María");
            Assert.AreEqual(person.Surname, "Díaz");
            Assert.AreEqual(person.IDNumber, "9876384A");

            // Test con funcion lambda
            person = Algorithm.Buscar(people, x => x.FirstName.Equals("Pepe") && x.IDNumber.EndsWith('R'));
            Assert.AreEqual(person.FirstName, "Pepe");
            Assert.AreEqual(person.Surname, "Hevia");
            Assert.AreEqual(person.IDNumber, "23476293R");

            // Test con Func<>
            Func<Person,bool> find = Algorithm.BuscarLetra;

            person = Algorithm.Buscar(people, find);
            Assert.AreEqual(person.FirstName, "Pepe");
            Assert.AreEqual(person.Surname, "Hevia");
            Assert.AreEqual(person.IDNumber, "23476293R");


            // Test con el Predicate<>
            Predicate<Person> buscar = Algorithm.BuscarLetra;
            person = Algorithm.BuscarPred(people, buscar);
            Assert.AreEqual(person.FirstName, "Pepe");
            Assert.AreEqual(person.Surname, "Hevia");
            Assert.AreEqual(person.IDNumber, "23476293R");
        }


        [TestMethod]
        public void FindStraightAngleTest()
        {
            // Test con Find() de C#
            Angle angle = Array.Find(angles, x => x.Quadrant.Equals(1) && x.Degrees == 90);
            Assert.AreEqual(90, angle.Degrees);
            Assert.AreEqual(1, angle.Quadrant);

            angle = Array.Find(angles, x => x.Quadrant.Equals(3) && x.Degrees == 220);
            Assert.AreEqual(220, angle.Degrees);
            Assert.AreEqual(3, angle.Quadrant);

            // Test con Func<>
            Func<Angle, bool> find = Algorithm.BuscarAngulo;
            angle = Algorithm.Buscar(angles, find);
            Assert.AreEqual(90, angle.Degrees);
            Assert.AreEqual(1, angle.Quadrant);

            // Test con Predicate
            Predicate<Angle> buscar = Algorithm.BuscarAngulo;
            angle = Algorithm.BuscarPred(angles, buscar);
            Assert.AreEqual(90, angle.Degrees);
            Assert.AreEqual(1, angle.Quadrant);
        }


        [TestMethod]
        public void FilterPeopleTest()
        { 
            
        }
    }
}
