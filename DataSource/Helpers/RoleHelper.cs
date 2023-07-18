using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataSource.Helpers
{
    public class RoleHelper
    {
        public static void SeedRoles(RoleManager<IdentityRole<Guid>> roleManager)
        {
            // Create Customer role if it doesn't exist
            if (!roleManager.RoleExistsAsync(Roles.Customer).Result)
            {
                var customerRole = new IdentityRole<Guid>(Roles.Customer);
                roleManager.CreateAsync(customerRole).Wait();
            }

            // Create Admin role if it doesn't exist
            if (!roleManager.RoleExistsAsync(Roles.Admin).Result)
            {
                var adminRole = new IdentityRole<Guid>(Roles.Admin);
                roleManager.CreateAsync(adminRole).Wait();
            }

            // Create Author role if it doesn't exist
            if (!roleManager.RoleExistsAsync(Roles.Author).Result)
            {
                var authorRole = new IdentityRole<Guid>(Roles.Author);
                roleManager.CreateAsync(authorRole).Wait();
            }
        }
    }
}
