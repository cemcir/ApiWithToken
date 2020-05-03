using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApıWithToken.Domain.Services;
using ApıWithToken.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApıWithToken.Extensions;
using ApıWithToken.Domain.Responses;
using ApıWithToken.Security.Token;

namespace ApıWithToken.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult AccessToken(LoginResource loginResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                BaseResponse<AccessToken> accessTokenResponse=   this.authenticationService.CreateAccessToken(loginResource.Email, loginResource.Password);

                if (accessTokenResponse.Success)
                {
                    return Ok(accessTokenResponse.Extra);
                }
                else
                {
                    return BadRequest(accessTokenResponse.ErrorMessage);
                }
            }
            
        }

        [HttpPost]
        public IActionResult RefreshToken(TokenResource tokenResource)
        {
          BaseResponse<AccessToken> accessTokenResponse=  authenticationService.CreateAccessTokenByRefReshToken(tokenResource.RefreshToken);

            if (accessTokenResponse.Success)
            {
                return Ok(accessTokenResponse.Extra);
            }
            else
            {
                return BadRequest(accessTokenResponse.ErrorMessage);
            }
        }

        [HttpPost]
        public IActionResult RevokeRefreshToken(TokenResource tokenResource)
        {
            BaseResponse<AccessToken> accessTokenResponse=  this.authenticationService.RevokeRefreshToken(tokenResource.RefreshToken);

            if (accessTokenResponse.Success) {
                return Ok(accessTokenResponse.Extra);
            }
            else
            {
                return BadRequest(accessTokenResponse.ErrorMessage);
            }
        }
    }
}