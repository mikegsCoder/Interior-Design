﻿using InteriorDesign.Core.ViewModels.DesignImageViewModels;

namespace InteriorDesign.Core.Services.Application.GalleryService
{
    public interface IGalleryService
    {
        Task<IEnumerable<DesignImageViewModel>> GetActiveImagesAsync();
    }
}
