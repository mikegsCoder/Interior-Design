using Microsoft.AspNetCore.Identity;

namespace InteriorDesign.Infrastructure.Data.Models.DataBaseModels
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
