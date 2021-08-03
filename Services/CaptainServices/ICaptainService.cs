using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using carpool.Models;
using Microsoft.AspNetCore.Mvc;

namespace carpool.Services.CaptainServices
{
    public interface ICaptainService
    {
        
         Task<List<Captain>> AllCaptains();
         Task<Captain> GetCaptain(string email);
         Task<string> CreateCaptain(CaptainModel captainModel);
        // public string UpdateCaptain(CaptainModel captainModel);
         Task<string> DeleteCaptain(string email);
         Task<string> CreateRide(CreateRideModel rideModel);     
        
    }
}