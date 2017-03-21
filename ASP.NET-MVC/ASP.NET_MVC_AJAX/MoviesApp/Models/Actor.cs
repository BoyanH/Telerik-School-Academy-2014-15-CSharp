namespace MoviesApp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Actor
    {
        private ICollection<Movie> movies;

        public Actor()
        {
            this.movies = new HashSet<Movie>();
        }

        public int ActorId { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Age { get; set; }

        public bool IsMale { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }
    }
}