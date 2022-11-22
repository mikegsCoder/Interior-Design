using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InteriorDesign.Infrastructure.Data.Configuration
{
    internal class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(SeedUserRoles());
        }

        private IEnumerable<IdentityUserRole<string>> SeedUserRoles()
        {
            var adminAdministrator = new IdentityUserRole<string>
            {
                RoleId = "0e8e18fb-65b5-4bf9-9926-628afdb1c465", // Administrator
                UserId = "90b21bc9-9062-4142-b3f9-774e6797e080"  // admin@mail.com
            };

            var adminEmployee = new IdentityUserRole<string>
            {
                RoleId = "5e97ba9f-a56b-4f55-b127-39569447a363", // Employee
                UserId = "90b21bc9-9062-4142-b3f9-774e6797e080"  // admin@mail.com
            };

            var adminUser = new IdentityUserRole<string>
            {
                RoleId = "8695a758-35e0-44fa-99d7-909a344009e2", // User
                UserId = "90b21bc9-9062-4142-b3f9-774e6797e080"  // admin@mail.com
            };

            var employeeEmployee = new IdentityUserRole<string>
            {
                RoleId = "5e97ba9f-a56b-4f55-b127-39569447a363", // Employee
                UserId = "4feb248f-9f4a-4dd9-a8d5-1ed4ee14a188"  // employee@mail.com
            };

            var employeeUser = new IdentityUserRole<string>
            {
                RoleId = "8695a758-35e0-44fa-99d7-909a344009e2", // User
                UserId = "4feb248f-9f4a-4dd9-a8d5-1ed4ee14a188"  // employee@mail.com
            };

            var userUser = new IdentityUserRole<string>
            {
                RoleId = "8695a758-35e0-44fa-99d7-909a344009e2", // User
                UserId = "c623d98f-7ced-432f-8955-879f45c38420"  // user@mail.com
            };

            return new List<IdentityUserRole<string>>() 
            { 
                adminAdministrator, 
                adminEmployee, 
                adminUser,
                employeeEmployee,
                employeeUser,
                userUser
            };
        }
    }
}
