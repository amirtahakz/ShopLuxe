using ShopLuxe.Common.Domain.ValueObjects;
using ShopLuxe.Domain.CategoryAgg;
using ShopLuxe.Domain.UserAgg.Services;
using ShopLuxe.Common.Application;
using ShopLuxe.Domain.CategoryAgg.Repository;
using ShopLuxe.Domain.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Categories.Edit
{
    public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainService;

        public EditCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.Id);
            if (category == null)
                return OperationResult.NotFound();

            category.Edit(request.Title , request.Slug, request.SeoData , _domainService);

            await _repository.Save();

            return OperationResult.Success();
        }
    }
}
