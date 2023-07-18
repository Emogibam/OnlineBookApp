using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataSource.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; } // Enum representing the order status (e.g., Pending, Shipped, Delivered, etc.)

        // Foreign key to link orders to customers
        public Guid CustomerId { get; set; }
        public virtual ApplicationUser Customer { get; set; }

        // Navigation property to link order details (order items) to the order
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

    public enum OrderStatus
    {
        Pending,   // The order is awaiting processing
        Shipped,   // The order has been shipped to the customer
        Delivered, // The order has been delivered to the customer
        Cancelled, // The order has been cancelled
        Returned   // The order has been returned by the customer
    }

}
