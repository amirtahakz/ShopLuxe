using ShopLuxe.Domain.ProductAgg.Repository;
using ShopLuxe.Domain.ProductAgg.Services;
using ShopLuxe.Domain.ProductAgg;
using ShopLuxe.Common.Application.FileUtil.Interfaces;
using ShopLuxe.Common.Application;
using ShopLuxe.Application._Utilities;

namespace ShopLuxe.Application.Products.Create
{
    public class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
    {
        private readonly IProductDomainService _domainService;
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;

        public CreateProductCommandHandler(IProductDomainService domainService, IProductRepository repository, IFileService fileService)
        {
            _domainService = domainService;
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
            var product = new Product(request.Title, imageName, request.Description, request.CategoryId,
                request.SubCategoryId, request.SecondarySubCategoryId, _domainService, request.Slug,
                request.SeoData);

            _repository.Add(product);

            var specifications = new List<ProductSpecification>();
            request.Specifications.ToList().ForEach(specification =>
            {
                specifications.Add(new ProductSpecification(specification.Key, specification.Value));
            });

            product.SetSpecification(specifications);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
