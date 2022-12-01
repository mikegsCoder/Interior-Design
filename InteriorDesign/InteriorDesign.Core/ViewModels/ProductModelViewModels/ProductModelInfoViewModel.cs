using System.ComponentModel.DataAnnotations;

namespace InteriorDesign.Core.ViewModels.ProductModelViewModels
{
    public class ProductModelInfoViewModel
    {
        public string Id { get; set; }

        public string ModelName { get; set; }

        public string CategoryName { get; set; }

        public string TypeName { get; set; }

        public int ProductsCount { get; set; }

        public string ImageUrl { get; set; }
    }
}
