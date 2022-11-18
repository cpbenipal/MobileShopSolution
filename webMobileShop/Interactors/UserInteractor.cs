using webMobileShop.Contracts;
using webMobileShop.Dtos;
using webMobileShop.Models;
using System;
using static webMobileShop.CommonUtilities.CommonUtils;

namespace webMobileShop.Interactors
{
    public class UserInteractor
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IHashManager _hashManager;
        public UserInteractor(IRepositoryWrapper repositoryWrapper, IHashManager hashManager)
        {
            this.repositoryWrapper = repositoryWrapper;
            _hashManager = hashManager;
        }

        public long RegisterUser(UserDto userDto)
        {
            var emailcheck = repositoryWrapper.UserManager.GetUserByEmail(userDto.Email);
            if (emailcheck != null)
            {
                return -1;
            }
            else
            {

                var hashed = _hashManager.HashWithSalt(userDto.Password);

                var entity = new User
                {
                    Id = userDto.Id,
                    Email = userDto.Email,
                    Mobile = String.Empty,
                    Address = String.Empty,
                    FullName = String.Empty,
                    IsActive = (int)EnumStatus.Pending,
                    AddedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    PasswordHash = hashed[0],
                    PasswordSalt = hashed[1],
                    Password = _hashManager.EncryptPlainText(userDto.Password)
                };
                var result = repositoryWrapper.UserManager.InsertUser(entity);

                repositoryWrapper.UserRoleManager.InsertUserRole(new UserRolesMapping()
                {
                    UserID = result.Id,
                    RoleID = (int)EnumRole.Customer,
                });

                return result.Id;
            }
        }
        public long UpdateUser(UserProfileDto userDto)
        {
            var model = repositoryWrapper.UserManager.GetUserById(userDto.Id);
            if(model != null)
            {
                model.Address = userDto.Address;
                model.Mobile = userDto.Mobile;
                model.FullName = userDto.FullName;
                model.ModifiedBy = userDto.Id;
                model.ModifiedOn = DateTime.Now;
                var result = repositoryWrapper.UserManager.UpdateUser(model);

                return result.Id;
            }
            return -1;
        }
    }
}