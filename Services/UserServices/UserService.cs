using System;
using System.Collections.Generic;
using System.Linq;
using carpool.Models;

namespace carpool.Services.UserServices
{
    public class UserService : IUserService
    {
         public static List<UserModel> users = new List<UserModel>{   
            
        };
        public List<UserModel> UserList()
        {
            return users;
        } 
        public string CreateUser(UserModel userModel)
        {
            var user = CheckUserExist(userModel.Email);
            if (user) return "User Already Exist With Email " + userModel.Email;
            
            else
            {
            userModel.UserId = Guid.NewGuid();
            users.Add(userModel);
            return "User Created Successfully!";
            }
        }

        public string DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }
        public List<UserModel> AllUsers()
        {
            return users;
        }
        public bool CheckUserExist(string email)
        {
            var check = users.FirstOrDefault(u => u.Email == email);
            if (check == null) return false;
            else return true;

        }

        public string UpdateUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}