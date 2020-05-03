using ApıWithToken.Domain;
using ApıWithToken.Domain.Repository;
using ApıWithToken.Domain.Responses;
using ApıWithToken.Domain.Services;
using ApıWithToken.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApıWithToken.DataControl;

namespace ApıWithToken.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository,IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public BaseResponse<User> AddUser(User user)
        {
            try
            {
                if (UserDataControl.validatePassword(user.Password) && UserDataControl.validateName(user.Name) && UserDataControl.validateSurName(user.SurName) && UserDataControl.validateEmail(user.Email)) {
                    user.Name = UserDataControl.updateName(user.Name);
                    user.SurName = UserDataControl.updateSurName(user.SurName);
                    userRepository.AddUser(user);
                    unitOfWork.Complete();
                    return new BaseResponse<User>(user);
                }
                return new BaseResponse<User>("kullanıcı eklenemedi");
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>($"Kullanıcı eklenirken bir hata meydana geldi:{ex.Message}");
            }
        }

        public BaseResponse<User> FindByEmail(string email)
        {
            try
            {
                User user = this.userRepository.FindByEmail(email);
                if (user != null)
                {
                    return new BaseResponse<User>("kullanıcı mevcut");
                }
                return new BaseResponse<User>(user);
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>($"Kullanıcı aranırken bir hata meydana geldi:{ex.Message}");
            }
        }

        public BaseResponse<User> FindById(int userId)
        {
            try
            {
                User user = this.userRepository.FindById(userId);
                if (user == null)
                {
                    return new BaseResponse<User>("Kullanıcı bulunamadı");
                }
                return new BaseResponse<User>(user);
            }
            catch(Exception ex)
            {
                return new BaseResponse<User>($"Kullanıcı bulunurken bir hata meydana geldi:{ex.Message}");
            }
        }

        public BaseResponse<User> FindEmailAndPassword(string email, string password)
        {
            try
            {
                User user = this.userRepository.FindByEmailandPassword(email, password);
                if (user == null)
                {
                    return new BaseResponse<User>("Kullanıcı bulunamadı");
                }
                else
                {
                    return new BaseResponse<User>(user);
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>($"Kullanıcı bulunurken bir hata meydana geldi:{ex.Message}");
            }
        }

        public BaseResponse<User> GetUserWithRefreshToken(string refreshToken)
        {
            try
            {
                User user = this.userRepository.GetUserWithRefreshToken(refreshToken);
                if (user == null)
                {
                    return new BaseResponse<User>("Kullanıcı bulunamadı");
                }
                else
                {
                    return new BaseResponse<User>(user);
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>($"Kullanıcı bulunurken bir hata meydana geldi:{ex.Message}");
            }
        }

        public void RemoveRefreshToken(User user)
        {
            try
            {
                this.userRepository.RemoveRefreshToken(user);
                unitOfWork.Complete();
            }
            catch (Exception)
            {
                //loglama yapılacaktır
            }
        }

        public BaseResponse<User> RemoveUser(int userId)
        {
            try
            {
                User user = this.userRepository.FindById(userId);
                if (user == null)
                {
                    return new BaseResponse<User>("silmek istediğiniz kullanıcı bulunamadı");
                }
                else
                {
                    this.userRepository.RemoveUser(user.Id);
                    this.unitOfWork.Complete();
                    return new BaseResponse<User>(user);
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>($"Kullanıcı silinirken bir hata meydana geldi:{ex.Message}");
            }
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            try
            {
                this.userRepository.SaveRefreshToken(userId, refreshToken);
                unitOfWork.Complete();
            }
            catch (Exception)
            {
                //loglama yapılacaktır
            }
        }

        public BaseResponse<User> UpdateUser(User user)
        {
            try
            {
                if (UserDataControl.validatePassword(user.Password) && UserDataControl.validateName(user.Name) && UserDataControl.validateSurName(user.SurName) && UserDataControl.validateEmail(user.Email)){
                    User response = this.userRepository.FindById(user.Id);
                    if (response == null)
                    {
                        return new BaseResponse<User>("güncellemek istediğiniz kullanıcı bulunamadı");
                    }
                    user.Name = UserDataControl.updateName(user.Name);
                    user.SurName = UserDataControl.updateSurName(user.SurName);
                    response.Id = user.Id;
                    response.Name = user.Name;
                    response.SurName = user.SurName;
                    response.Email = user.Email;
                    response.Password = user.Password;

                    this.userRepository.UpdateUser(response);
                    this.unitOfWork.Complete();
                    return new BaseResponse<User>(response);
                }
                return new BaseResponse<User>("kullanıcı güncellenemedi");
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>($"ürün güncellenirken bir hata meydana geldi::{ex.Message}");
            }
        }
    }
}
