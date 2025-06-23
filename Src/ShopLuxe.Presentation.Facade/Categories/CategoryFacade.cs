using ShopLuxe.Application.Categories.Remove;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using ShopLuxe.Query.Categories.GetById;
using ShopLuxe.Query.Categories.GetByParentId;
using ShopLuxe.Query.Categories.GetList;
using ShopLuxe.Application.Categories.AddChild;
using ShopLuxe.Application.Categories.Create;
using ShopLuxe.Application.Categories.Edit;
using ShopLuxe.Common.Application;
using ShopLuxe.Common.CachHelper;
using ShopLuxe.Presentation.Facade;
using ShopLuxe.Query.Categories.DTOs;

namespace ShopLuxe.Presentation.Facade.Categories;

internal class CategoryFacade : ICategoryFacade
{
    private readonly IMediator _mediator;
    private IDistributedCache _cache;
    public CategoryFacade(IMediator mediator, IDistributedCache cache)
    {
        _mediator = mediator;
        _cache = cache;
    }

    public async Task<OperationResult<Guid>> AddChild(AddChildCategoryCommand command)
    {
        await _cache.RemoveAsync(CacheKeys.Categories);
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditCategoryCommand command)
    {
        await _cache.RemoveAsync(CacheKeys.Categories);
        return await _mediator.Send(command);
    }

    public async Task<OperationResult<Guid>> Create(CreateCategoryCommand command)
    {
        await _cache.RemoveAsync(CacheKeys.Categories);
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Remove(Guid categoryId)
    {
        await _cache.RemoveAsync(CacheKeys.Categories);

        return await _mediator.Send(new RemoveCategoryCommand(categoryId));
    }

    public async Task<CategoryDto> GetCategoryById(Guid id)
    {
        return await _mediator.Send(new GetCategoryByIdQuery(id));
    }

    public async Task<List<ChildCategoryDto>> GetCategoriesByParentId(Guid parentId)
    {
        return await _mediator.Send(new GetCategoryByParentIdQuery(parentId));

    }

    public async Task<List<CategoryDto>> GetCategories()
    {
        return await _cache.GetOrSet(CacheKeys.Categories, () =>
        {
            return _mediator.Send(new GetCategoryListQuery());
        });
    }
}