using System;
using System.Collections.Generic;
using System.Text;

namespace StudentHolder
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FN { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public List<int> Marks { get; set; }
        public Nullable<int> GroupNumber { get; set; }

        //Task16
        public Group Group { get; set; }
        //End Task16

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Marks = new List<int>();
        }

        public Student(string firstName, string lastName, int groupNumber)
            :this(firstName, lastName)
        {
            this.GroupNumber = groupNumber;
        }

        public Student(string firstName, string lastName, int groupNumber, string tel)
            : this(firstName, lastName, groupNumber)
        {
            this.Tel = tel;
        }

        public Student(string firstName, string lastName, int groupNumber, string tel, string email)
            : this(firstName, lastName, groupNumber, tel)
        {
            this.Email = email;
        }

        public Student(string firstName, string lastName, int groupNumber, string tel, string email, List<int> marks)
            : this(firstName, lastName, groupNumber, tel, email)
        {
            this.Marks = marks;
        }

        public Student(string firstName, string lastName, int groupNumber, string tel, string email, List<int> marks, string fn)
            : this(firstName, lastName, groupNumber, tel, email, marks)
        {
            this.FN = fn;
        }

        public Student(string firstName, string lastName, int groupNumber, string tel, string email, List<int> marks, string fn, Group group)
            : this(firstName, lastName, groupNumber, tel, email, marks, fn)
        {
            this.Group = group;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(string.Format("First Name = {0}, \n", this.FirstName));
            sb.Append(string.Format("Last Name = {0}, \n", this.LastName));
            sb.Append(string.Format("FN = {0}, \n", this.FN));
            sb.Append(string.Format("Tel = {0}, \n", this.Tel));
            sb.Append(string.Format("Email = {0}, \n", this.Email));
            sb.Append(string.Format("Marks = {0}, \n", string.Join(", ", this.Marks)));
            sb.Append(string.Format("Group Number = {0} \n", this.GroupNumber));
            sb.Append(string.Format("Group = \n{0}", this.Group.ToString()));

            return sb.ToString();
        }
    }
}
