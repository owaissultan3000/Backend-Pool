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

        public CaptainModel GetCaptain(string email)
        {
             return captains.FirstOrDefault(u => u.Email == email);
        }

        public string UpdateCaptain(CaptainModel captainModel)
        {
            var captain = GetCaptain(captainModel.Email);
            if (captain != null)
            {
                if(captain.Email == captainModel.Email)
                {
                    captain.CaptainName = captainModel.CaptainName;
                    captain.CaptainPhone = captainModel.CaptainPhone;
                    captain.Password = captainModel.Password;
                    captain.ConfirmPassword = captainModel.ConfirmPassword;
                    captain.Gender = captainModel.Gender;
                    captain.VehicleNumber = captainModel.VehicleNumber;
                    captain.VehicleModel = captainModel.VehicleModel;
                    captain.VehicleColor = captainModel.VehicleColor;
                    captain.FarePerSeats = captainModel.FarePerSeats;
                    return "Captain Updated Successfully!";
                }
                else return "You can't change your id OR email ";
            }
            else return "Something went wrong";
 
        }
    }
}