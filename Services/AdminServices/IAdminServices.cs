using System.Collections.Generic;
using System.Threading.Tasks;
using carpool.Models;

namespace carpool.Services.AdminServices
{
    public interface IAdminServices
    {
        Task<List<Captain>> AllCaptains();
        Task<string> CreateCaptain(CaptainModel captainModel);
        Task<string> DeleteCaptain(string email);
        public Task<List<User>> AllUsers();
        Task<string> CreateAdmin(AdminModel adminModel);
        public Task<Admin> GetAdmin(string email);
        public Task<string> DeleteAdmin(string email);
        public Task<List<Ride>> ViewAvailableRides();


        
    }
}