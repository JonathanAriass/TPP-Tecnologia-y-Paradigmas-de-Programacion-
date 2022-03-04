using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TPP.Laboratory.Functional.Lab05;

namespace TestTarea5
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
            Person person = Array.Find(people, x=>x.FirstName.Equals("Pepe") && x.IDNumber.EndsWith('R'));
            Assert.AreEqual(person.FirstName, "Pepe");
            Assert.AreEqual(person.Surname, "Hevia");
            Assert.AreEqual(person.IDNumber, "23476293R");

            person = Array.Find(people, x => x.FirstName.Equals("María") && x.IDNumber.EndsWith('A'));
            Assert.AreEqual(person.FirstName, "María");
            Assert.AreEqual(person.Surname, "Díaz");
            Assert.AreEqual(person.IDNumber, "9876384A");
        }


        [TestMethod]
        public void FindStraightAngleTest()
        {
            Angle angle = Array.Find(angles, x=>x.Quadrant.Equals(1) && x.Degrees == 90);
            Assert.AreEqual(90, angle.Degrees);
            Assert.AreEqual(1, angle.Quadrant);

            angle = Array.Find(angles, x => x.Quadrant.Equals(3) && x.Degrees == 220);
            Assert.AreEqual(220, angle.Degrees);
            Assert.AreEqual(3, angle.Quadrant);
        }


        [TestMethod]
        public void FilterPeopleTest()
        {
            
        }
    }
}
