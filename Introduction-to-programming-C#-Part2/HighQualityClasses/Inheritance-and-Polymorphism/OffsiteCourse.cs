using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        private string town;

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (value.Length < 3) //maybe check if town is in a list of towns...
                {
                    throw new ArgumentException("Town`s name must be at least 3 characters long!");
                }

                this.town = value;
            }
        }

        public OffsiteCourse(string courseName)
            : base(courseName)
        {

        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {

        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {

        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public override string ToString()
        {

            var sb = new StringBuilder();
            sb.Append(base.ToString());

            if (this.Town != null)
            {
                sb.Append("; Town = ");
                sb.Append(this.Town);
            }
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
