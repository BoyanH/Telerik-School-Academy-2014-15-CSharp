using System;

namespace Methods
{
    class Student
    {
        private string firstName;
        private string lastName;
        private readonly DateTime dateOfBirth;
        private readonly string placeOfBirth;
        
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value.Length > 3)
                {
                    this.firstName = value;
                }
                else
                {
                    throw new ArgumentException("First Name must be at least 3 digits long!");
                }
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value.Length > 3)
                {
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentException("Last Name must be at least 3 digits long!");
                }
            }
        }

        public string PlaceOfBirt
        {
            get
            {
                return placeOfBirth;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
        }

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Student(string firstName, string lastName, DateTime dateOfBirth)
            :this(firstName, lastName)
        {
            this.dateOfBirth = dateOfBirth;
        }

        public Student(string firstName, string lastName, DateTime dateOfBirth, string placeOfBirth)
            : this(firstName, lastName, dateOfBirth)
        {
            this.placeOfBirth = placeOfBirth;
        }

        public bool IsOlderThan(Student other)
        {
            return this.DateOfBirth > other.DateOfBirth;
        }
    }
}
