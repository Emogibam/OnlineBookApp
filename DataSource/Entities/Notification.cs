using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataSource.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Details { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
