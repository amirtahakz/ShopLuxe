using ShopLuxe.Application._Utilities;
using ShopLuxe.Common.Application;
using ShopLuxe.Common.Application.FileUtil.Interfaces;
using ShopLuxe.Domain.SiteEntities.Repositories;

namespace ShopLuxe.Application.SiteEntities.Sliders.Delete
{
    public class DeleteSliderCommandHandler : IBaseCommandHandler<DeleteSliderCommand>
    {
        private readonly ISliderRepository _repository;
        private readonly IFileService _localFileService;
        public DeleteSliderCommandHandler(ISliderRepository repository, IFileService localFileService)
        {
            _repository = repository;
            _localFileService = localFileService;
        }

        public async Task<OperationResult> Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
        {
            var slider = await _repository.GetTracking(request.Id);
            if (slider == null) return OperationResult.NotFound();

            _repository.Delete(slider);
            await _repository.Save();
            _localFileService.DeleteFile(Directories.SliderImages, slider.ImageName);
            return OperationResult.Success();
        }
    }
}
