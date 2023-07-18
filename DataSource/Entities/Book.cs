using System;
using System.Collections.Generic;
using System.Text;

namespace DataSource.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid AuthorId { get; set; } 
        public virtual Author Author { get; set; } 
        public Guid GenreId { get; set; } 
        public virtual Genre Genre { get; set; } 
        public string ISBN { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
