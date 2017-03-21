using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentHolder
{
    public class StudentTester
    {
        public static void Main()
        {
            Console.BufferHeight = 600; //to show the whole one-tasked homework
                                       // hate students already

            List<Student> studentList = new List<Student> 
                {
                    new Student("Boyan", "Hristov", 2, "08827102XX", "secret@gmail.com", new List<int> {6, 6, 6}, 
                        "33230623", new Group(12, "Mathematics")), //xD

                    new Student("Don", "Cho", 3, "0882710223", "secret@gmail.com", new List<int> {2, 4, 6}, 
                        "44230823", new Group(18, "Geography")),

                    new Student("Pesho", "Goshov", 2, "+4500882732133", "aslpls@abv.com", new List<int> {5, 5, 5}, 
                        "98830423", new Group(12, "Mathematics")),

                    new Student("Stamat", "Ivanov", 1, "+123882832233", "stamat@yahoo.com", new List<int> {4, 5, 4}, 
                        "39830623", new Group(13, "Informatik")),

                    new Student("Yanka", "Bozukova", 4, "+150881900233", "yanka@mail.bg", new List<int> {2, 2, 3}, 
                        "45630323", new Group(12, "Mathematics")),

                    new Student("Dimcho", "Debelqnov", 1, "+2120882710193", "dimcho@abv.bg", new List<int> {6, 4, 3}, 
                        "12330223", new Group(13, "Informatik")),

                    new Student("Ivan", "Yordanov", 8, "0882710233", "ivan@abv.bg", new List<int> {3, 4, 3}, 
                        "23230123", new Group(18, "Geography")),

                    new Student("Hristo", "Stoichkov", 2, "0882710233", "hristo@abv.bg", new List<int> {5, 4, 3}, 
                        "01230623", new Group(13, "Informatik"))
                };

            List<Group> departments = new List<Group>()
            {
                new Group(1, "Physics"),
                new Group(2, "Mathematics"),
                new Group(3, "Biology")
            };

            // -----------------------Task 9-------------------------------
            IEnumerable<Student> studentsFromGroup2Linq =
                from student in studentList
                where student.GroupNumber == 2
                select student;

            IEnumerable<Student> studentsFromGroup2Methods = studentList.Where(st => st.GroupNumber == 2);

            Console.WriteLine("All Students: \n");
            Student[] allStudents = studentList.ToArray();
            foreach (var student in allStudents)
            {
                Console.WriteLine("{0}\n", student.ToString());
            }

            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Students from group 2: \n");
            Student[] queriedStudents = studentsFromGroup2Linq.ToArray();
            foreach (var student in queriedStudents)
            {
                Console.WriteLine("{0}\n", student.ToString());
            }

            // -----------------------Task 10-------------------------------
            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Is Linq query same as Methods query: {0}",
                studentsFromGroup2Linq.Except(studentsFromGroup2Methods).Count() == 0
                && studentsFromGroup2Methods.Except(studentsFromGroup2Linq).Count() == 0);

            // -----------------------Task 11-------------------------------
            var studentsWithEmailAtABVLinq =
                from student in studentList
                where student.Email.Substring(student.Email.IndexOf("@") + 1) == "abv.bg"
                select student;

            var studentsWithEmailAtABVMethods = studentList.
                Where(st => st.Email.Substring(st.Email.IndexOf("@") + 1) == "abv.bg");

            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Students with email at abv.bg: \n");
            Student[] emailStudents = studentsWithEmailAtABVLinq.ToArray();
            foreach (var student in emailStudents)
            {
                Console.WriteLine("{0}\n", student.ToString());
            }

            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Is Linq query same as Methods query: {0}",
                studentsWithEmailAtABVLinq.Except(studentsWithEmailAtABVMethods).Count() == 0
                && studentsWithEmailAtABVMethods.Except(studentsWithEmailAtABVLinq).Count() == 0);

            // -----------------------Task 12-------------------------------
            // ---I assume phones with country code 0 should be queried-----
            var studentsWithPhonesInSofiaLinq =
                from student in studentList
                where student.Tel.StartsWith("0")
                select student;

            var studentsWithPhonesInSofiaMethods = studentList
                .Where(st => st.Tel.StartsWith("0"));

            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Students with phones in Sofia: \n");
            Student[] phoneStudents = studentsWithPhonesInSofiaLinq.ToArray();
            foreach (var student in phoneStudents)
            {
                Console.WriteLine("{0}\n", student.ToString());
            }

            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Is Linq query same as Methods query: {0}",
                studentsWithPhonesInSofiaLinq.Except(studentsWithPhonesInSofiaMethods).Count() == 0
                && studentsWithPhonesInSofiaMethods.Except(studentsWithPhonesInSofiaLinq).Count() == 0);

            // -----------------------Task 13-------------------------------

            var studentWithExcellentGradeLinq =
                from student in studentList
                where student.Marks.Contains(6)
                select new { FullName = student.FirstName + " " + student.LastName, Marks = student.Marks };

            var studentWithExcellentGradeMethods = studentList
                .Where(st => st.Marks.Contains(6))
                .Select(st => new { FullName = st.FirstName + " " + st.LastName, Marks = st.Marks });

            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Students with at least 1 excellent mark: \n{0}", string.Join(", \n", studentWithExcellentGradeLinq));

            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Is Linq query same as Methods query: {0}",
                string.Format("Students with at least 1 excellent mark: \n{0}", string.Join(", \n", studentWithExcellentGradeLinq)) ==
                string.Format("Students with at least 1 excellent mark: \n{0}", string.Join(", \n", studentWithExcellentGradeMethods)));
            //only way to compare without building loops, because the List<int> with grades is always going to have a different refference
            //and .Equals doesn't seem to go as deep into the anonymous classes

            // -----------------------Task 14-------------------------------

            var studentsWith2F = studentList.getStudentsWithTwoMarks(2);

            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Students with exactly two \"2\" marks: \n{0}", string.Join(", \n", studentsWith2F));

            // -----------------------Task 15-------------------------------
            var studentsEnrolled06Marks =
                from student in studentList
                where student.FN[4] == '0' && student.FN[5] == '6'
                select student.Marks;

            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Marks from students, who enrolled in 2006: \n");

            foreach (var studentMarks in studentsEnrolled06Marks)
            {
                Console.WriteLine(string.Join(", ", studentMarks));
            }

            // -----------------------Task 16-------------------------------
            var mathematicsDepartmentStudents =
                from student in studentList
                join department in departments on student.Group.DepartmentName equals department.DepartmentName
                select student;

            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Students in Mathematics Department: \n{0}", string.Join(" \n\n", mathematicsDepartmentStudents));

            // ----------------Task 17 (check Extension Methods)------------------

            string[] strArr = new string[] { "pesho", "gosho", "mira", "loooooooooooooooongest", "stamat", "ezrael"};

            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Given string array: {0}", string.Join(", ", strArr));
            Console.WriteLine("Longest string from strArr is: {0}", strArr.getLongestString());

            // -----------------------Task 18-------------------------------

            var groupedByGroupName =
                from student in studentList
                group student by student.Group.DepartmentName into groups
                select groups;

            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Students, grouped by DepartmentName: \n");

            foreach (var  group in groupedByGroupName)
            {
                Console.WriteLine("\n\nGROUP {0}: \n\n{1}", group.FirstOrDefault().Group.DepartmentName.ToUpper(), string.Join(", \n", group));   
            }

            // -------------Task 19 (check Extension Methods)-------------------------

            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Is result of extension method same as previous query: {0}",
                string.Join(", \n", groupedByGroupName) == string.Join(", \n", studentList.GroupByDepartmentName()));
        }
    }
}
