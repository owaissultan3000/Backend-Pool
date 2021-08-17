using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using carpool.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carpool.Services.AdminServices
{
    public class AdminServices : IAdminServices
    {
         ApiDbContext db;
        public AdminServices( ApiDbContext _db)
        {
            db = _db;
        }
        public async Task<List<Captain>> AllCaptains()
        {
            if (db!=null)
            {
                return await db.Captains.ToListAsync();
            }
            
                return null;
        
        }

        public async Task<List<User>> AllUsers()
        {
            if (db != null)
            {
                return await db.Users.ToListAsync();
            }
            return null;
        }

        public async Task<string> CreateAdmin(AdminModel adminModel)
        {
             if (db != null)
            {
                var temp = await db.Admins.FirstOrDefaultAsync(u => u.Email == adminModel.Email);
                if (temp == null)
                {
                    adminModel.AdminId = Guid.NewGuid();
                    adminModel.Password  = BCrypt.Net.BCrypt.HashPassword(adminModel.Password);
                    Admin admin = new Admin{
                    AdminId = adminModel.AdminId.ToString(),
                    AdminName = adminModel.AdminName.ToLower(),
                    PhoneNumber = adminModel.PhoneNumber,
                    Email = adminModel.Email.ToLower(),
                    Passwords = adminModel.Password,
                    Role = adminModel.Role.ToString(),
                    CreationDate = DateTime.Now.ToString(),

                };
                await db.Admins.AddAsync(admin);
                await db.SaveChangesAsync();
                return "Admin Created Successfully";
                }
                else return "Admin already exist with email " + adminModel.Email;
            }
            return "Unable to create admin";

        }

        public async Task<string> CreateCaptain([FromBody] CaptainModel captainModel)
        {
           
             if (db != null)
            {
                var temp = await db.Captains.FirstOrDefaultAsync(u => u.Email == captainModel.Email);
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
                await db.Captains.AddAsync(captain);
                await db.SaveChangesAsync();
                return "Captain Created Successfully";
                }
                else return "Captain already exist with email " + captainModel.Email;
            }
            return "Unable to create captain";
            
        }


        public async Task<string> DeleteAdmin(string email)
        {
             int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                Admin admin = await db.Admins.FirstOrDefaultAsync(u => u.Email == email);

                if (admin != null)
                {
                    //Delete that captain
                    db.Admins.Remove(admin);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return email+" Deleted Successfully";
            }

            return "Unable to delete admin try again";
        }

       public async Task<string> DeleteCaptain(string email)
        {
             int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                Captain captain = await db.Captains.FirstOrDefaultAsync(u => u.Email == email);

                if (captain != null)
                {
                    //Delete that captain
                    db.Captains.Remove(captain);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return email+" Deleted Successfully";
            }

            return "Unable to delete user try again";
        }

        public async Task<Admin> GetAdmin(string email)
        {
            if (db != null)
            {
                Admin admin = await db.Admins.FirstOrDefaultAsync(u => u.Email == email);
                if (admin != null)
                {
                    return admin;
                }
                return null;
            }
            return null;
        }

        public async Task<List<Ride>> ViewAvailableRides()
        {
            if (db != null)
            {
                return await db.Rides.ToListAsync();
            }

            return null;
        }
    }
}