﻿using ShopLuxe.Domain.SiteEntities;
using ShopLuxe.Application._Utilities;
using ShopLuxe.Common.Application;
using ShopLuxe.Common.Application.FileUtil.Interfaces;
using ShopLuxe.Domain.SiteEntities.Repositories;

namespace ShopLuxe.Application.SiteEntities.Sliders.Create
{
    internal class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
    {
        private readonly IFileService _fileService;
        private readonly ISliderRepository _repository;

        public CreateSliderCommandHandler(IFileService fileService, ISliderRepository repository)
        {
            _fileService = fileService;
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _fileService
                .SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
            var slider = new Slider(request.Title, request.Link, imageName);

            _repository.Add(slider);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
