using ApıWithToken.Domain.Responses;
using ApıWithToken.Security.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApıWithToken.Domain.Services
{
    public interface IAuthenticationService
    {
        BaseResponse<AccessToken> CreateAccessToken(string email,string password);

        BaseResponse<AccessToken> CreateAccessTokenByRefReshToken(string refreshToken);

        BaseResponse<AccessToken> RevokeRefreshToken(string refreshToken);
    }
}
