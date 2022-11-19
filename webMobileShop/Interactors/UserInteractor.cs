using webMobileShop.Contracts;
using webMobileShop.Dtos;
using webMobileShop.Models;
using System;
using static webMobileShop.CommonUtilities.CommonUtils;
using System.Linq;
using webMobileShop.CommonUtilities;
using System.IO;
using System.Collections.Generic;

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

        public List<UserListDto> GetAllUsers()
        {
            var AllUsers = repositoryWrapper.UserManager.GetUsers();
             
            var UserList  = AllUsers.Select(x=> new UserListDto()
            {
                Id = x.Id,
                FullName = x.FullName,
                Email = x.Email,
                Mobile= x.Mobile,
                IsActive = x.IsActive,
                Address = x.Address,
                RoleName = Enum.GetName(typeof(EnumRole), x.UserRolesMappings.FirstOrDefault(xx=>xx.UserID == x.Id).RoleID),
                AddedOn = x.AddedOn,
                ModifiedOn = x.ModifiedOn                
            }).ToList();


            return UserList;
        }

        public bool CheckIfEmailExists(string Email)
        {
            return repositoryWrapper.UserManager.CheckIfEmailExists(Email);
        }
        public bool CheckIfValidActivationCode(string Code)
        {
            return repositoryWrapper.UserManager.CheckIfValidActivationCode(Code);
        }
        public long RegisterUser(UserDto userDto, Uri url)
        {
            var hashed = _hashManager.HashWithSalt(userDto.Password);
            string activationCode = CommonUtils.GenratePassword();
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
                Code = activationCode,
                Password = _hashManager.EncryptPlainText(userDto.Password)
            };
            var result = repositoryWrapper.UserManager.InsertUser(entity);

            repositoryWrapper.UserRoleManager.InsertUserRole(new UserRolesMapping()
            {
                UserID = result.Id,
                RoleID = (int)EnumRole.Customer,
            });

            string body = "Dear ,";
            body += "<br /><br />Please click the following link to activate your account";
            body += "<br /><a href = '" + string.Format("{0}://{1}/Account/Activation/{2}", url.Scheme, url.Authority, activationCode) + "'>Click here to activate your account.</a>";
            body += "<br /><br />Thanks";
            SendEmail.EmailSend(userDto.Email, "Confirm your account", body, true);
            return result.Id;

        }
        public long UpdateUser(UserProfileDto userDto)
        {
            var model = repositoryWrapper.UserManager.GetUserById(userDto.Id);
            if (model != null)
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

        public long VerifyAccount(string activateCode)
        {
            var model = repositoryWrapper.UserManager.GetUserByCode(activateCode);
            if (model != null)
            {
                model.IsActive = (int)EnumStatus.Active;
                model.Code = string.Empty;
                model.ModifiedOn = DateTime.Now;
                var result = repositoryWrapper.UserManager.UpdateUser(model);
                string body = "Dear ,";
                body += "<br /><br />Your account has been successfully activated";  
                body += "<br /><a href = 'Login'>Click here to Login.</a>";
                body += "<br /><br />Thanks";
                SendEmail.EmailSend(model.Email, "Activation Successul", body,true);
                return result.Id;
            }
            return -1;
        }

        public LoginResponseDto IsValidUser(LoginDto dto)
        {
            var result = repositoryWrapper.UserManager.GetUsers().FirstOrDefault(x => x.Email == dto.Email && x.Password == _hashManager.EncryptPlainText(dto.Password));
            if (result != null)
            { 
                return new LoginResponseDto()
                {
                    Id = result.Id,
                    Email = result.Email,
                    FullName = String.IsNullOrEmpty(result.FullName) ? "Customer" : result.FullName,
                    IsActive = result.IsActive,
                    RoleName = Enum.GetName(typeof(EnumRole), result.UserRolesMappings.FirstOrDefault(xx => xx.UserID == result.Id).RoleID)
                };
            }
            else
            {
                return null;
            }
        }
    }
}