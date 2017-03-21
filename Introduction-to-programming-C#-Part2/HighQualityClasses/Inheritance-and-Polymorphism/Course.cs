using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public abstract class Course
    {

        private string name;
        private string teacherName;
        private IList<string> students;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name must be at least 3 characters long!");
                }

                this.name = value;
            }
        }
        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }
            set
            {
     

                this.teacherName = value;
            }
        }
        public IList<string> Students
        {
            get
            {   //clone data to ensure that it is verified and only set using the setter
                if (this.students != null)
                {
                    return this.students.Select(student => (string)student.Clone()).ToList();
                }

                return null;
            }
            set
            {
                //implement a verification logic if needed, I see no need for the current example

                this.students = value;
            }
        }

        public Course(string courseName)
        {
            this.Name = courseName;
        }

        public Course(string courseName, string teacherName)
            :this(courseName)
        {
            this.TeacherName = teacherName;
        }

        public Course(string courseName, string teacherName, IList<string> students)
            :this(courseName, teacherName)
        {
            this.students = students;
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("OffsiteCourse { Name = ");
            sb.Append(this.Name);
            if (this.TeacherName != null)
            {
                sb.Append("; Teacher = ");
                sb.Append(this.TeacherName);
            }
            sb.Append("; Students = ");
            sb.Append(this.GetStudentsAsString());

            return sb.ToString();
        }
    }
}
