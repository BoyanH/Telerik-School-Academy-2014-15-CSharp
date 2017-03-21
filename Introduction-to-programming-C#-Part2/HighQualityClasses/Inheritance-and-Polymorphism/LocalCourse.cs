using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        private string lab;
        private readonly string[] possibleLabs = {"ultimate", "enterprise", "light"};

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                if (!possibleLabs.Contains(value.ToLower()))
                {
                    throw new ArgumentException("Non-existing lab for a local course!");
                }

                this.lab = value;
            }
        }

        public LocalCourse(string courseName)
            : base(courseName)
        {

        }

        public LocalCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {

        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {

        }

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());

            if (this.Lab != null)
            {
                sb.Append("; Lab = ");
                sb.Append(this.Lab);
            }
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
