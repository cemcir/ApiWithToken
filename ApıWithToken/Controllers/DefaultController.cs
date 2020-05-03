using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApıWithToken.Domain;
using ApıWithToken.Domain.Responses;
using ApıWithToken.Domain.Services;
using ApıWithToken.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApıWithToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public DefaultController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public IActionResult GetUserFindById(IdentityResource identityResource)
        {
            BaseResponse<User> response = this.userService.FindById(identityResource.Id);
            if (response.Success)
            {
                return Ok(response.Extra);
            }
            return BadRequest(response.ErrorMessage);
        }
    }
}