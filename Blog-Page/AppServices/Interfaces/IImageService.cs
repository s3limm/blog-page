﻿using Blog_Page.Models;

namespace Blog_Page.Services.Interfaces
{
    public interface IImageService
    {
        Task<string> UploadFileAsync(IFormFile file);
    }
}
