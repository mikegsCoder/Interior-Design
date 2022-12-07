using InteriorDesign.Core.ViewModels.TestimonialViewModels;

namespace InteriorDesign.Core.Services.Application.AboutUsService
{
    public interface IAboutUsService
    {
        Task<IEnumerable<TestimonialViewModel>> GetActiveTestimonialsAsync();

        Task<IEnumerable<TestimonialViewModel>> GetAllTestimonialsAsync();

        Task DeactivateTestimonialAsync(string testimonilaId);
    }
}
