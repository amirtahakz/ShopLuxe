﻿using Dapper;
using ShopLuxe.Common.Query;
using ShopLuxe.Infrastructure.Persistent.Dapper;
using ShopLuxe.Query.Users.DTOs;

namespace ShopLuxe.Query.Users.UserTokens.GetByJwtToken;

internal class GetUserTokenByJwtTokenQueryHandler : IQueryHandler<GetUserTokenByJwtTokenQuery, UserTokenDto>
{
    private readonly DapperContext _dapperContext;

    public GetUserTokenByJwtTokenQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<UserTokenDto> Handle(GetUserTokenByJwtTokenQuery request, CancellationToken cancellationToken)
    {
        using var connection = _dapperContext.CreateConnection();
        var sql = $"SELECT TOP(1) * FROM {_dapperContext.UserTokens} Where HashJwtToken=@hashJwtToken";
        return await connection.QueryFirstOrDefaultAsync<UserTokenDto>(sql, new { hashJwtToken = request.HashJwtToken });
    }
}