
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApıWithToken.Domain.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);

        User FindById(int userId);

        User FindByEmailandPassword(string email,string password);

        User FindByEmail(string email);

        void SaveRefreshToken(int userId,string refreshToken);

        User GetUserWithRefreshToken(string refreshToken);

        void RemoveRefreshToken(User user);

        void UpdateUser(User user);

        void RemoveUser(int Id);
    }
}
