namespace MoviesApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public int? Year { get; set; }

        public string Studio { get; set; }

        public string StudioAddress { get; set; }

        public int LeadingMaleRoleId { get; set; }
        public virtual Actor LeadingMaleRole { get; set; }

        public int LeadingFemaleRoleId { get; set; }
        public virtual Actor LeadingFemaleRole { get; set; }
    }
}