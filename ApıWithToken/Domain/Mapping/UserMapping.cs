using ApıWithToken.Resources;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApıWithToken.Domain.Mapping
{
    public class UserMapping:Profile
    {
        public UserMapping()
        {
            CreateMap<UserResource, User>();
            CreateMap<User, UserResource>();
            CreateMap<User, UpdateUserResource>();
            CreateMap<UpdateUserResource, User>();
        }
    }
}
