using ShopLuxe.Application.Categories.AddChild;
using ShopLuxe.Application.Categories.Create;
using ShopLuxe.Application.Categories.Edit;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.Categories.DTOs;

namespace ShopLuxe.Presentation.Facade.Categories;

public interface ICategoryFacade
{
    Task<OperationResult<Guid>> AddChild(AddChildCategoryCommand command);
    Task<OperationResult> Edit(EditCategoryCommand command);
    Task<OperationResult<Guid>> Create(CreateCategoryCommand command);
    Task<OperationResult> Remove(Guid categoryId);


    Task<CategoryDto> GetCategoryById(Guid id);
    Task<List<ChildCategoryDto>> GetCategoriesByParentId(Guid parentId);
    Task<List<CategoryDto>> GetCategories();

}