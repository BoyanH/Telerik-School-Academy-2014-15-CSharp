using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Data.Models
{
    public class Book
    {
        private ICollection<Author> authors;

        public Book()
        {
            this.authors = new HashSet<Author>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Author> Authors
        {
            get
            {
                return this.authors;
            }
            set
            {
                this.authors = value;
            }
        }

        public string ISBN { get; set; }

        public string Website { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
