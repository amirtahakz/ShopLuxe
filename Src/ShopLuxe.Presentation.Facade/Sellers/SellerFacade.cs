using MediatR;
using ShopLuxe.Query.Sellers.GetByFilter;
using ShopLuxe.Query.Sellers.GetById;
using ShopLuxe.Query.Sellers.GetByUserId;
using ShopLuxe.Application.Sellers.Create;
using ShopLuxe.Application.Sellers.Edit;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.Sellers.DTOs;
namespace ShopLuxe.Presentation.Facade.Sellers;

internal class SellerFacade : ISellerFacade
{
    private readonly IMediator _mediator;

    public SellerFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> CreateSeller(CreateSellerCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditSeller(EditSellerCommand command)
    {
        return await _mediator.Send(command);

    }
    public async Task<SellerDto?> GetSellerById(Guid sellerId)
    {
        return await _mediator.Send(new GetSellerByIdQuery(sellerId));

    }

    public async Task<SellerDto?> GetSellerByUserId(Guid userId)
    {
        return await _mediator.Send(new GetSellerByUserIdQuery(userId));
    }

    public async Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams)
    {
        return await _mediator.Send(new GetSellerByFilterQuery(filterParams));
    }
}