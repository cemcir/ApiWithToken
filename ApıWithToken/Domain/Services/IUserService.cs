using ApıWithToken.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApıWithToken.Domain.Services
{
    public interface IUserService
    {
        BaseResponse<User> AddUser(User user);

        BaseResponse<User> FindById(int userId);

        BaseResponse<User> FindByEmail(string email);

        BaseResponse<User> FindEmailAndPassword(string email,string password);

        void SaveRefreshToken(int userId, string refreshToken);

        BaseResponse<User> GetUserWithRefreshToken(string refreshToken);

        BaseResponse<User> RemoveUser(int userId);

        void RemoveRefreshToken(User user);

        BaseResponse<User> UpdateUser(User user);
    }
}
