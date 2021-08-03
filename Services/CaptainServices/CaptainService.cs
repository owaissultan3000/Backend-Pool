using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using carpool.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carpool.Services.CaptainServices
{
    public class CaptainService : ICaptainService
    {
        ApiDbContext _db;
        
        public CaptainService(ApiDbContext db)
        {
            _db = db;
        }
        public async Task<List<Captain>> AllCaptains()
        {
            if (_db != null)
            {
                return await _db.Captains.ToListAsync();
            }

            return null;
        }

        public async Task<string> CreateCaptain([FromBody] CaptainModel captainModel)
        {
           
             if (_db != null)
            {
                var temp = await _db.Captains.FirstOrDefaultAsync(u => u.Email == captainModel.Email);
                if (temp == null)
                {
                    captainModel.CaptainId = Guid.NewGuid();
                    captainModel.Password  = BCrypt.Net.BCrypt.HashPassword(captainModel.Password);
                    Captain captain = new Captain{
                    CaptainId = captainModel.CaptainId.ToString(),
                    CaptainName = captainModel.CaptainName.ToLower(),
                    CaptainPhone = captainModel.CaptainPhone,
                    Gender = captainModel.Gender.ToLower(),
                    Email = captainModel.Email.ToLower(),
                    Passwords = captainModel.Password,
                    VehicleNumber = captainModel.VehicleNumber,
                    VehicleColor = captainModel.VehicleColor.ToLower(),
                    VehicleModel = captainModel.VehicleModel.ToLower(),
                    Role = captainModel.Role.ToString(),
                    CreateionDate = DateTime.Now

                };
                await _db.Captains.AddAsync(captain);
                await _db.SaveChangesAsync();
                return "Captain Created Successfully";
                }
                else return "User already exist with email " + captainModel.Email;
            }
            return "Unable to create user";
            
        }

        public async Task<string> CreateRide([FromBody] CreateRideModel rideModel)
        {
            if (_db != null)
            {
                var temp = await _db.Rides.FirstOrDefaultAsync(u => u.CaptainId == rideModel.CaptainId.ToString());
                if (temp == null)
                {
                    rideModel.RideId = Guid.NewGuid();
                    Ride ride = new Ride{
                        RideId = rideModel.RideId.ToString(),
                        CaptainId = rideModel.CaptainId.ToString(),
                        Name = rideModel.Name.ToLower(),
                        PhoneNumber = rideModel.PhoneNumber,
                        VehicleId = rideModel.VehicleID,
                        JourneyRoute = rideModel.JourneyRoute.ToLower(),
                        DepartureTime = rideModel.DepartureTime,
                        FarePerSeats = rideModel.FarePerSeats

                };
                await _db.Rides.AddAsync(ride);
                await _db.SaveChangesAsync();
                return "Ride Created Successfully";
                }
                else return "Can't Create More Than One Ride At A Time";
                
                
            }
            return "Unable to create ride try again";
        }
        

        public async Task<string> DeleteCaptain(string email)
        {
             int result = 0;

            if (_db != null)
            {
                //Find the post for specific post id
                Captain captain = await _db.Captains.FirstOrDefaultAsync(u => u.Email == email);

                if (captain != null)
                {
                    //Delete that user
                    _db.Captains.Remove(captain);

                    //Commit the transaction
                    result = await _db.SaveChangesAsync();
                }
                return email+" Deleted Successfully";
            }

            return "Unable to delete user try again";
        }

        public async Task<Captain> GetCaptain(string email)
        {
             if (_db != null)
            {
               Captain captain = await _db.Captains.FirstOrDefaultAsync(u => u.Email == email);
               return captain;
            }

            return null;
        }

        // public string UpdateCaptain(CaptainModel captainModel)
        // {
        //     var captain = GetCaptain(captainModel.Email);
        //     if (captain != null)
        //     {
        //         if(captain.Email == captainModel.Email)
        //         {
        //             captain.CaptainName = captainModel.CaptainName;
        //             captain.CaptainPhone = captainModel.CaptainPhone;
        //             captain.Password = captainModel.Password;
        //             captain.ConfirmPassword = captainModel.ConfirmPassword;
        //             captain.Gender = captainModel.Gender;
        //             captain.VehicleNumber = captainModel.VehicleNumber;
        //             captain.VehicleModel = captainModel.VehicleModel;
        //             captain.VehicleColor = captainModel.VehicleColor;
        //             captain.FarePerSeats = captainModel.FarePerSeats;
        //             return "Captain Updated Successfully!";
        //         }
        //         else return "You can't change your id OR email ";
        //     }
        //     else return "Something went wrong";
 
        // }
    }
}