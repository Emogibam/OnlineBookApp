using System;
using System.Collections.Generic;
using System.Text;

namespace DataSource.Entities
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation property to link books to the genre
        public virtual ICollection<Book> Books { get; set; }
    }

}
