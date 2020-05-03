using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApıWithToken.Domain;
using ApıWithToken.Domain.Responses;
using ApıWithToken.Domain.Services;
using ApıWithToken.Extensions;
using ApıWithToken.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApıWithToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService,IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUser()
        {
            IEnumerable<Claim> claims = User.Claims;

            string userId = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;

            BaseResponse<User> userResponse = userService.FindById(int.Parse(userId));

            if (userResponse.Success) {
                return Ok(userResponse.Extra);
            }
            return BadRequest(userResponse.ErrorMessage);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public IActionResult GetUserFindById(int id)
        {
            BaseResponse<User> response = this.userService.FindById(id);
            if (response.Success)
            {
                return Ok(response.Extra);
            }
            return BadRequest(response.ErrorMessage);
        }
        
        [Authorize]
        [HttpDelete]
        public IActionResult RemoveUser(IdentityResource identityResource)
        {
            BaseResponse<User> userResponse = this.userService.RemoveUser(identityResource.Id);
            if (userResponse.Success)
            {
                return Ok(userResponse.Extra);
            }
            return BadRequest(userResponse.ErrorMessage);
        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateUser(UpdateUserResource updateUserResource)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                User user = mapper.Map<UpdateUserResource, User>(updateUserResource);
                BaseResponse<User> userResponse = this.userService.UpdateUser(user);
                if (userResponse.Success)
                {
                    return Ok(userResponse.Extra);
                }
                return BadRequest(userResponse.ErrorMessage);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddUser(UserResource userResource)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState.GetErrorMessages());
            }
            else{
                BaseResponse<User> response = this.userService.FindByEmail(userResource.Email);
                if (response.Success){
                    User user = mapper.Map<UserResource, User>(userResource);
                    
                    BaseResponse<User> userResponse = this.userService.AddUser(user);

                    if (userResponse.Success){
                        return Ok(userResponse.Extra);
                    }
                    else{
                        return BadRequest(userResponse.ErrorMessage);
                    }
                }
                else{
                    return BadRequest(response.ErrorMessage);
                }
            }
        }
    }
}