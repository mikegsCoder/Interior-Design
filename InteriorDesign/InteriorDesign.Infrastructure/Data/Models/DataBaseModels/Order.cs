using InteriorDesign.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InteriorDesign.Infrastructure.Data.Models.DataBaseModels
{
    public class Order : BaseDeletableModel<string>
    {
        public Order()
        {
            this.Id = Guid.NewGuid();
            this.ConfiguredProducts = new List<ConfiguredProduct>();
        }

        [Required]
        [MaxLength(DataConstants.OrderFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(DataConstants.OrderLastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [MaxLength(DataConstants.OrderDeliveryAddressMaxLength)]
        public string DeliveryAddress { get; set; }

        [MaxLength(DataConstants.OrderAdditionalDetailsMaxLength)]
        public string? AdditionalDetails { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Precision(DataConstants.OrderPricePrecision, DataConstants.OrderPriceScale)]
        public decimal Price { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public bool IsShipped { get; set; }

        public DateTime? ShippedOn { get; set; }

        public virtual ICollection<ConfiguredProduct> ConfiguredProducts { get; set; }
    }
}
