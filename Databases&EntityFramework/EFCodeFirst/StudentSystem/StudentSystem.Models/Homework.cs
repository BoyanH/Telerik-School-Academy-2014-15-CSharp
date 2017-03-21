namespace StudentSystem.Models
{

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Homework
    {
        public int Id { get; set; }

        [Required]
        public string FilePath { get; set; }

        public string Content { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TimeSent { get; set; }

        public Guid CourseId { get; set; }

        public virtual Course Course { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
