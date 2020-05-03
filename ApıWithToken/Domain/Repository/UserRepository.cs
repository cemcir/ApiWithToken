using ApıWithToken.Domain.UnitOfWork;
using ApıWithToken.Security.Token;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApıWithToken.Domain.Repository
{
    public class UserRepository :BaseRepository, IUserRepository
    {
        private readonly TokenOptions tokenOptions;

        public UserRepository(ApiWithTokenDBContext context,IOptions<TokenOptions> tokenOptions):base(context)
        {
            this.tokenOptions = tokenOptions.Value;
        }

        public void AddUser(User user)
        {
            this.context.User.Add(user);      
        }

        public User FindByEmail(string email)
        {
             return this.context.User.Where(u => u.Email == email).FirstOrDefault();
        }

        public User FindByEmailandPassword(string email, string password)
        {
            return this.context.User.Where(u=>u.Email==email && u.Password==password).FirstOrDefault();
        }

        public User FindById(int userId)
        {
            return this.context.User.Find(userId);
        }

        public User GetUserWithRefreshToken(string refreshToken)
        {
            return this.context.User.FirstOrDefault(u=>u.RefreshToken==refreshToken);
        }

        public void RemoveRefreshToken(User user)
        {
            User newUser = this.FindById(user.Id);
            newUser.RefreshToken = null;
            newUser.RefreshTokenEndDate = null;
        }

        public void RemoveUser(int userId)
        {
            User newUser = this.FindById(userId);
            this.context.User.Remove(newUser);
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            User newUser = this.FindById(userId);
            newUser.RefreshToken = refreshToken;
            newUser.RefreshTokenEndDate = DateTime.Now.AddMinutes(tokenOptions.RefreshTokenExpiration);
        }

        public void UpdateUser(User user)
        {
            this.context.User.Update(user);
        }
    }
}
