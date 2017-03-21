namespace TwitterLikeApp.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {

        public Post()
        {
            this.Id = Guid.NewGuid();
            this.HashTags = new HashSet<HashTag>();
            this.CreatedAt = DateTime.Now;
            this.Likes = 0;
            this.Dislikes = 0;
        }

        [Key]
        public Guid Id { get; set; }

        public ApplicationUser AspNetUserId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        [InverseProperty("Posts")]
        public virtual ICollection<HashTag> HashTags { get; set; }
    }
}