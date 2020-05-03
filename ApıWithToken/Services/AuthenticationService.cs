using ApıWithToken.Domain;
using ApıWithToken.Domain.Responses;
using ApıWithToken.Domain.Services;
using ApıWithToken.Security.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApıWithToken.Services
{
    public class AuthenticationService:IAuthenticationService
    {
        private readonly IUserService userService;

        private readonly ITokenHandler tokenHandler;

        public AuthenticationService(IUserService userService,ITokenHandler tokenHandler)
        {
            this.userService = userService;
            this.tokenHandler = tokenHandler;
        }

        public BaseResponse<AccessToken> CreateAccessToken(string email, string password)
        {
            BaseResponse<User> userResponse = this.userService.FindEmailAndPassword(email, password);
            if (userResponse.Success)
            {
                AccessToken accessToken = tokenHandler.CreateAccessToken(userResponse.Extra);

                userService.SaveRefreshToken(userResponse.Extra.Id,accessToken.RefreshToken);

                return new BaseResponse<AccessToken>(accessToken);
            }
            else
            {
                return new BaseResponse<AccessToken>(userResponse.ErrorMessage);
            }
        }

        public BaseResponse<AccessToken> CreateAccessTokenByRefReshToken(string refreshToken)
        {
            BaseResponse<User> userResponse = userService.GetUserWithRefreshToken(refreshToken);
            if (userResponse.Success)
            {
                if (userResponse.Extra.RefreshTokenEndDate > DateTime.Now)
                {
                    AccessToken accessToken = tokenHandler.CreateAccessToken(userResponse.Extra);

                    userService.SaveRefreshToken(userResponse.Extra.Id, accessToken.RefreshToken);

                    return new BaseResponse<AccessToken>(accessToken);
                }
                else
                {
                    return new BaseResponse<AccessToken>("refreshtoken suresi dolmus");
                }
            }
            else
            {
                return new BaseResponse<AccessToken>("refreshtoken bulunamadı");
            }
        }

        public BaseResponse<AccessToken> RevokeRefreshToken(string refreshToken)
        {
            BaseResponse<User> userResponse = userService.GetUserWithRefreshToken(refreshToken);
            if (userResponse.Success)
            {
                userService.RemoveRefreshToken(userResponse.Extra);

                return new BaseResponse<AccessToken>(new AccessToken());
            }
            else
            {
                return new BaseResponse<AccessToken>("refreshtoken bulunamadı");
            }
        }
    }
}
