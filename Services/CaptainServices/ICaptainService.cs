using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using carpool.Models;
using Microsoft.AspNetCore.Mvc;

namespace carpool.Services.CaptainServices
{
    public interface ICaptainService
    {
        
         
         Task<Captain> GetCaptain(string email);
         
        // public string UpdateCaptain(CaptainModel captainModel);
         
         Task<string> CreateRide(CreateRideModel rideModel);     
        
    }
}