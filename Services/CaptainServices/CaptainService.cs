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
        ApiDbContext db;
        
        public CaptainService(ApiDbContext _db)
        {
            db = _db;
        }



        public async Task<string> CreateRide([FromBody] CreateRideModel rideModel)
        {
            if (db != null)
            {
                var temp = await db.Rides.FirstOrDefaultAsync(u => u.CaptainId == rideModel.CaptainId.ToString());
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
                        FarePerSeats = rideModel.FarePerSeats,
                        AvailableSeats = rideModel.AvailableSeats,

                };
                await db.Rides.AddAsync(ride);
                await db.SaveChangesAsync();
                return "Ride Created Successfully";
                }
                else return "Can't Create More Than One Ride At A Time";
                
                
            }
            return "Unable to create ride try again";
        }
        

       

        public async Task<Captain> GetCaptain(string email)
        {
             if (db != null)
            {
               Captain captain = await db.Captains.FirstOrDefaultAsync(u => u.Email == email);
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