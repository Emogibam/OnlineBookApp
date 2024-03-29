﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataSource.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid LocationId { get; set; }
        public Guid RefreshToken { get; set; }
        public DateTime RefreshTokenCreatedAt { get; set; }
        public DateTime RefreshTokenExpiryAt { get; set; }
        public string ProfilePictureUrl { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
    }
}
