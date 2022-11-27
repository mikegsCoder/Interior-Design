﻿using InteriorDesign.Core.ViewModels.DesignImageViewModels;
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
    }
}
