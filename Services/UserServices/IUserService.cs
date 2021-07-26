using System;
using System.Collections.Generic;
using carpool.Models;

namespace carpool.Services.UserServices
{
    public interface IUserService
    {
        public bool CheckUserExist(string email);
        public List<UserModel> AllUsers();
        public UserModel GetUser(Guid userId);
        public string CreateUser(UserModel userModel);
        public string UpdateUser(UserModel userModel);
        public string DeleteUser(Guid id);
    }
}