using System;

namespace TPP.Laboratory.ObjectOrientation.Lab03 {

    class Person {

        private String firstName, surname;

        public String FirstName {
            get { return firstName; }
        }
        public String SurName {
            get { return surname; }
        }

        private string idNumber;
        public string IDNumber {
            get { return idNumber; }
        }

        public override String ToString() {
            return String.Format("{0} {1} with {2} ID number", firstName, surname, idNumber);
        }

        public Person(String name, String surname, string idNumber) {
            this.firstName = name;
            this.surname = surname;
            this.idNumber = idNumber;
        }

        public Person() { }

        /************************** Equals must be implemented (GetHashCode is advisable) *********************/

        public override bool Equals(object obj) {
            Person person = obj as Person;
            if (person == null)
                return false;
            return this.IDNumber.Equals(person.IDNumber);
        }

        public override int GetHashCode() {
            return this.IDNumber.GetHashCode();
        }

    }
}
