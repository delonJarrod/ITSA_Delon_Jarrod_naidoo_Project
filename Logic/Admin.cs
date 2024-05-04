using ITSA_Delon_Jarrod_naidoo.Data;
using ITSA_Delon_Jarrod_naidoo.Interface;
using ITSA_Delon_Jarrod_naidoo.Models;
using Microsoft.Azure.Documents;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using User = ITSA_Delon_Jarrod_naidoo.Models.User;

namespace ITSA_Delon_Jarrod_naidoo.Logic
{
    public class Admin : IAdmin
    {

        private readonly ITSADbContext _dbContext;

        public Admin(ITSADbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<Models.User>> SearchResults(string UserID)
        {
            List<User> users = new List<User>();    
            try
            {
              users = await _dbContext.Users
                .Where(u => u.Name.Contains(UserID) || u.Surname.Contains(UserID))
                .OrderByDescending(u => u.UserId)
                .ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }


            return users;  
        }        
        
        public async Task<User> ViewDetails(int UserID)
        {
           User users = new User();    
            try
            {
                users = await _dbContext.Users
                .Include(u => u.Address)
                .ThenInclude(a => a.Meter)
                .Where(u => u.UserId == UserID)
                .OrderByDescending(u => u.UserId)
                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw;
            }


            return users;  
        }

        public async Task<User> Update(User user)
        {
            try
            {
                // Retrieve the user along with its associated address and meter
                User existingUser = await _dbContext.Users
                    .Include(u => u.Address)
                    .ThenInclude(a => a.Meter)
                    .Where(u => u.UserId == user.UserId)
                    .FirstOrDefaultAsync();

                if (existingUser != null)
                {
                    existingUser.Name = user.Name;
                    existingUser.Surname = user.Surname;
                    existingUser.DateOfBirth = user.DateOfBirth;
                    existingUser.IdentityNumber = user.IdentityNumber;
                    existingUser.EmailAddress = user.EmailAddress;
                    existingUser.ContactNumber = user.ContactNumber;

                    if (existingUser.Address != null)
                    {
                        existingUser.Address.Country = user.Address.Country;
                        existingUser.Address.Province = user.Address.Province;
                        existingUser.Address.City = user.Address.City;
                        existingUser.Address.Suburb = user.Address.Suburb;
                        existingUser.Address.PostalCode = user.Address.PostalCode;
                        existingUser.Address.UnitNumber = user.Address.UnitNumber;
                        existingUser.Address.ComplexName = user.Address.ComplexName;
                    }

                    if (existingUser.Address != null && existingUser.Address.Meter != null)
                    {
                        existingUser.Address.Meter.SerialNumber = user.Address.Meter.SerialNumber;
                        existingUser.Address.Meter.MeterType = user.Address.Meter.MeterType;
                        existingUser.Address.Meter.AssetName = user.Address.Meter.AssetName;
                        existingUser.Address.Meter.VoltageAmperage = user.Address.Meter.VoltageAmperage;
                    }

                    await _dbContext.SaveChangesAsync();
                }

                return existingUser;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw;
            }
        }
    }
}
