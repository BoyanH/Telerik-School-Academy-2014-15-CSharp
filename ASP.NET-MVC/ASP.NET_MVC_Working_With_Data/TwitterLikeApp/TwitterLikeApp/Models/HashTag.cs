namespace TwitterLikeApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class HashTag
    {

        public HashTag ()
        {
            this.Posts = new HashSet<Post>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [InverseProperty("HashTags")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}