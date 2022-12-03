namespace InteriorDesign.Core.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public string OrderId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string DeliveryAddress { get; set; }

        public string? AdditionalDetails { get; set; }

        public decimal Price { get; set; }

        public bool IsShipped { get; set; }

        public DateTime? ShippedOn { get; set; }
    }
}
