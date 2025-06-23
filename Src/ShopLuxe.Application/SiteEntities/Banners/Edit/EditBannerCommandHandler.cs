﻿using Microsoft.AspNetCore.Http;
using ShopLuxe.Application._Utilities;
using ShopLuxe.Common.Application;
using ShopLuxe.Common.Application.FileUtil.Interfaces;
using ShopLuxe.Common.Application.SecurityUtil;
using ShopLuxe.Domain.SiteEntities.Repositories;

namespace ShopLuxe.Application.SiteEntities.Banners.Edit
{
    public class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
    {
        private readonly IBannerRepository _repository;
        private readonly IFileService _fileService;
        public EditBannerCommandHandler(IBannerRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _repository.GetTracking(request.Id);
            if (banner == null)
                return OperationResult.NotFound();
            var imageName = banner.ImageName;
            var oldImage = banner.ImageName;

            if (request.ImageFile.IsImage())
                imageName = await _fileService
                    .SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);

            banner.Edit(request.Link, imageName, request.Position);

            DeleteOldImage(request.ImageFile, oldImage);
            await _repository.Save();
            return OperationResult.Success();
        }

        private void DeleteOldImage(IFormFile? imageFile, string oldImage)
        {
            if (imageFile.IsImage())
                _fileService.DeleteFile(Directories.BannerImages, oldImage);
        }
    }
}
