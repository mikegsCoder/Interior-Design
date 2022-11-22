using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InteriorDesign.Infrastructure.Data.Configuration
{
    internal class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(SeedRoles());
        }

        private IEnumerable<IdentityRole> SeedRoles()
        {
            var administrator = new IdentityRole()
            { 
                Id = "0e8e18fb-65b5-4bf9-9926-628afdb1c465", 
                Name = "Administrator", 
                NormalizedName = "Administrator".ToUpper() 
            };

            var employee = new IdentityRole() 
            { 
                Id = "5e97ba9f-a56b-4f55-b127-39569447a363", 
                Name = "Employee", 
                NormalizedName = "Employee".ToUpper() 
            };

            var user = new IdentityRole() 
            { 
                Id = "8695a758-35e0-44fa-99d7-909a344009e2", 
                Name = "User", 
                NormalizedName = "User".ToUpper() 
            };

            return new List<IdentityRole>() { administrator, employee, user };
        }
    }
}
