using System.Net;
using System.Web.Http;
using AngleSharp.Dom;
using AngleSharp.Io;
using ShopLuxe.Api.Infrastructure.Security;
using ShopLuxe.Common.Application;
using ShopLuxe.Domain.RoleAgg.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopLuxe.Application.Categories.AddChild;
using ShopLuxe.Application.Categories.Create;
using ShopLuxe.Application.Categories.Edit;
using ShopLuxe.Common.AspNetCore;
using ShopLuxe.Presentation.Facade.Categories;
using ShopLuxe.Query.Categories.DTOs;

namespace ShopLuxe.Api.Controllers;


//[PermissionChecker(Permission.Category_Management)]
public class CategoryController : Common.AspNetCore.ApiController
{
    private readonly ICategoryFacade _categoryFacade;

    public CategoryController(ICategoryFacade categoryFacade)
    {
        _categoryFacade = categoryFacade;
    }


    [System.Web.Http.AllowAnonymous]
    [Microsoft.AspNetCore.Mvc.HttpGet]
    public async Task<ApiResult<List<CategoryDto>>> GetCategories()
    {
        var result = await _categoryFacade.GetCategories();

        return QueryResult(result);
    }



    [System.Web.Http.AllowAnonymous]
    [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
    public async Task<ApiResult<CategoryDto>> GetCategoryById(Guid id)
    {
        var result = await _categoryFacade.GetCategoryById(id);

        return QueryResult(result);
    }


    [Microsoft.AspNetCore.Mvc.HttpGet("getChild/{parentId}")]
    [System.Web.Http.AllowAnonymous]
    public async Task<ApiResult<List<ChildCategoryDto>>> GetCategoriesByParentId(Guid parentId)
    {
        var result = await _categoryFacade.GetCategoriesByParentId(parentId);

        return QueryResult(result);
    }


    [Microsoft.AspNetCore.Mvc.HttpPost]
    public async Task<ApiResult<Guid>> CreateCategory(CreateCategoryCommand command)
    {
        var result = await _categoryFacade.Create(command);

        var url = Url.Action("GetCategoryById", "Category", new {id = result.Data}, Request.Scheme);

        return CommandResult(result, HttpStatusCode.Created, url);
    }


    [Microsoft.AspNetCore.Mvc.HttpPost("AddChild")]
    public async Task<ApiResult<Guid>> CreateCategory(AddChildCategoryCommand command)
    {
        var result = await _categoryFacade.AddChild(command);

        var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);

        return CommandResult(result, HttpStatusCode.Created, url);
    }


    [Microsoft.AspNetCore.Mvc.HttpPut]
    public async Task<ApiResult> EditCategory(EditCategoryCommand command)
    {
        var result = await _categoryFacade.Edit(command);

        return CommandResult(result);
    }


    [Microsoft.AspNetCore.Mvc.HttpDelete("{categoryId}")]
    public async Task<ApiResult> RemoveCategory(Guid categoryId)
    {
        var result = await _categoryFacade.Remove(categoryId);
        return CommandResult(result);
    }
}