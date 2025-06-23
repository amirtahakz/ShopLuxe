using ShopLuxe.Common.Application;
using ShopLuxe.Domain.CategoryAgg.Repository;
using ShopLuxe.Domain.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Categories.AddChild
{
    public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainService;

        public AddChildCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult<Guid>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.ParentId);
            if (category == null)
                return OperationResult<Guid>.NotFound();

            category.AddChild(request.Title , request.Slug , request.SeoData , _domainService);

            await _repository.Save();

            return OperationResult<Guid>.Success(category.Id);
        }
    }
}
