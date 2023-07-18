using System;
using System.Collections.Generic;
using System.Text;

namespace DataSource.Entities
{
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Foreign keys to link order details to the order and book
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }

        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }
    }


}
