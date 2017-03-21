namespace TwitterLikeApp.Models
{
    using System;

    public class AspNetUserLike
    {

        public AspNetUserLike()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public ApplicationUser AspNetUser { get; set; }

        public Post Post { get; set; }

        public bool Likes { get; set; }

        public bool Dislikes { get; set; }
    }
}