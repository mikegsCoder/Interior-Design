using InteriorDesign.Infrastructure.Data.Configuration;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InteriorDesign.Infrastricture.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ConfiguredProduct> ConfiguredProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DesignImage> DesignImages { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new IdentityRoleConfiguration());
            builder.ApplyConfiguration(new ApplicationUserRoleConfiguration());

            base.OnModelCreating(builder);
        }
    }
}