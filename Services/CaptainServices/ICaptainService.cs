using System;
using System.Collections.Generic;
using carpool.Models;

namespace carpool.Services.CaptainServices
{
    public interface ICaptainService
    {
        public bool CheckCaptainExist(string email);
        public List<CaptainModel> AllCaptains();
        public CaptainModel GetCaptain(Guid userId);
        public string CreateCaptain(CaptainModel captainModel);
        public string UpdateCaptain(CaptainModel captainModel);
        public string DeleteCaptain(Guid id);
        
    }
}