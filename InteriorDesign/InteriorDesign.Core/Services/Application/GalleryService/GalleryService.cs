using InteriorDesign.Core.ViewModels.DesignImageViewModels;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InteriorDesign.Core.Services.Application.GalleryService
{
    public class GalleryService : IGalleryService
    {
        private readonly IDeletableEntityRepository<DesignImage> _images;

        public GalleryService(IDeletableEntityRepository<DesignImage> images)
        {
            _images = images;
        }

        public async Task<IEnumerable<DesignImageViewModel>> GetActiveImagesAsync()
        {
            return await _images.AllAsNoTracking()
                .Where(i => i.IsActive)
                .Select(i => new DesignImageViewModel()
                {
                    ImageId = i.Id,
                    ImageUrl = i.ImageUrl,
                    Name = i.Name,
                    IsActive = i.IsActive
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<DesignImageViewModel>> GetAllImagesAsync()
        {
            return await _images.AllAsNoTracking()
               .Select(i => new DesignImageViewModel()
               {
                   ImageId = i.Id,
                   ImageUrl = i.ImageUrl,
                   Name = i.Name,
                   IsActive = i.IsActive
               })
               .OrderByDescending(i => i.IsActive)
               .ToListAsync();
        }

        public async Task DeactivateImageAsync(string imageId)
        {
            var image = await _images.All()
                .Where(i => i.Id == imageId)
                .FirstOrDefaultAsync();

            image.IsActive = false;

            _images.Update(image);

            await _images.SaveChangesAsync();
        }

        public async Task ActivateImageAsync(string imageId)
        {
            var image = await _images.All()
                .Where(i => i.Id == imageId)
                .FirstOrDefaultAsync();

            image.IsActive = true;

            _images.Update(image);

            await _images.SaveChangesAsync();
        }
    }
}
