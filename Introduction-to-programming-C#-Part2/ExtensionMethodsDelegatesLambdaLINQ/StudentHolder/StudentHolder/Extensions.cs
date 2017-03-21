using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentHolder
{
    public static class Extensions
    {
        public static dynamic getStudentsWithTwoMarks(this List<Student> stList, int mark)
        {
            var resultStudents = stList
                .Where(st => st.Marks.Count(x => x == mark) == 2)
                .Select(st => new { FirstName = st.FirstName, Marks = st.Marks });

            return resultStudents;
        }

        public static string getLongestString(this string[] strArr)
        {
            var sortedStrArr =
                from str in strArr
                orderby str.Length descending, str
                select str;

            return sortedStrArr.FirstOrDefault();
        }

        public static dynamic GroupByDepartmentName(this List<Student> stList)
        {
            var groupedByDepartmentName =
                from student in stList
                group student by student.Group.DepartmentName into groups
                select groups;

            return groupedByDepartmentName;
        }
    }
}
