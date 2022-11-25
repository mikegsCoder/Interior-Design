namespace InteriorDesign.Core.ViewModels.TestimonialViewModels
{
    public class TestimonialViewModel
    {
        public string TestimonialId { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
