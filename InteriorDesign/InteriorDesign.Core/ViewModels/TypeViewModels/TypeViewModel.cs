namespace InteriorDesign.Core.ViewModels.TypeViewModels
{
    public class TypeViewModel
    {
        public string Name { get; set; } = null!;

        public int ProductCategoriesCount { get; set; }

        public int ProductModelsCount { get; set; }

        public int ProductsCount { get; set; }

        public string ImageUrl { get; set; } = null!;
    }
}
