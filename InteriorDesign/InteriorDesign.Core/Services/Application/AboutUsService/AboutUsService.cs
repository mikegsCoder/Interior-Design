using InteriorDesign.Core.ViewModels.TestimonialViewModels;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InteriorDesign.Core.Services.Application.AboutUsService
{
    public class AboutUsService : IAboutUsService
    {
        private readonly IDeletableEntityRepository<Testimonial> _testimonials;

        public AboutUsService(IDeletableEntityRepository<Testimonial> testimonials)
        {
            _testimonials = testimonials;
        }

        public async Task<IEnumerable<TestimonialViewModel>> GetActiveTestimonialsAsync()
        {
            return await _testimonials.AllAsNoTracking()
                .Where(t => t.IsActive)
                .Select(t => new TestimonialViewModel()
                {
                    TestimonialId = t.Id,
                    Author = t.Author,
                    Title = t.Title,
                    Content = t.Content.Trim(),
                    IsActive = t.IsActive
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<TestimonialViewModel>> GetAllTestimonialsAsync()
        {
            return await _testimonials.AllAsNoTracking()
                .Select(t => new TestimonialViewModel()
                {
                    TestimonialId = t.Id,
                    Author = t.Author,
                    Title = t.Title,
                    Content = t.Content.Trim(),
                    IsActive = t.IsActive
                })
                .OrderByDescending(t => t.IsActive)
                .ToListAsync();
        }
    }
}
