using System;
using System.Text;

namespace StudentHolder
{
    public class Group
    {
        public int GroupNumber { get; set; }
        public string DepartmentName { get; set; }

        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("{\n");
            sb.Append(string.Format("{0}GroupNumber = {1}\n", new string(' ', 4), this.GroupNumber));
            sb.Append(string.Format("{0}DepartmentName = {1}\n", new string(' ', 4), this.DepartmentName));
            sb.Append("}");

            return sb.ToString();
        }
    }
}
