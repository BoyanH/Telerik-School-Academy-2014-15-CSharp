namespace StudentSystem.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {

        private ICollection<Student> students;
        private ICollection<Homework> homeworks;

        public Course()
        {
            this.Id = Guid.NewGuid();
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Location { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }
            set
            {
                this.homeworks = value;
            }
        }
    }
}
