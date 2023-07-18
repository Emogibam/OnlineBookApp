using System;
using System.Collections.Generic;
using System.Text;

namespace DataSource.Entities
{
    public class Author
    { 
        public Guid Id { get; set; }
        public string Biography { get; set; }
        public double Ratings { get; set; }

        // Navigation property to link books to the author
        public virtual ICollection<Book> Books { get; set; }

    }
}
