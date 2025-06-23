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

namespace ShopLuxe.Application.Categories.Create
{
    public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainService;

        public CreateCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Slug , request.Title , request.SeoData , _domainService);

            await _repository.AddAsync(category);
            await _repository.Save();

            return OperationResult<Guid>.Success(category.Id);
        }
    }
}
