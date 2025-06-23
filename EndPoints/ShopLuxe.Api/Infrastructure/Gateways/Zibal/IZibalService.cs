using ShopLuxe.Api.Infrastructure.Gateways.Zibal.DTOs;

namespace ShopLuxe.Api.Infrastructure.Gateways.Zibal;

public interface IZibalService
{
    Task<string> StartPay(ZibalPaymentRequest request);
    Task<ZibalVeriyfyResponse> Verify(ZibalVeriyfyRequest request);
}