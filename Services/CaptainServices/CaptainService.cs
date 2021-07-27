using System;
using System.Collections.Generic;
using System.Linq;
using carpool.Models;

namespace carpool.Services.CaptainServices
{
    public class CaptainService : ICaptainService
    {
        public static List<CaptainModel> captains = new List<CaptainModel>{   
            
        };
        public List<CaptainModel> AllCaptains()
        {
            return captains;
        }

        public bool CheckCaptainExist(string email)
        {
             var check = captains.FirstOrDefault(u => u.Email == email);
            if (check == null) return false;
            else return true;
        }

        public string CreateCaptain(CaptainModel captainModel)
        {
            var captain = CheckCaptainExist(captainModel.Email);
            if (captain) return "Captain Already Exist With Email " + captainModel.Email;

            else
            {
            captainModel.CaptainId = Guid.NewGuid();
            captainModel.Password = captainModel.ConfirmPassword = BCrypt.Net.BCrypt.HashPassword(captainModel.Password);
            //BCrypt.Net.BCrypt.Verify(entered Password, Db Password); for login
            captains.Add(captainModel);
            return "Captain Created Successfully!";
            }
        }

        public string DeleteCaptain(Guid id)
        {
            throw new NotImplementedException();
        }

        public CaptainModel GetCaptain(Guid userId)
        {
            throw new NotImplementedException();
        }

        public string UpdateCaptain(CaptainModel captainModel)
        {
            throw new NotImplementedException();
        }
    }
}