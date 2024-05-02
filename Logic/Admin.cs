using ITSA_Delon_Jarrod_naidoo.Data;
using ITSA_Delon_Jarrod_naidoo.Interface;
using ITSA_Delon_Jarrod_naidoo.Models;
using Microsoft.EntityFrameworkCore;

namespace ITSA_Delon_Jarrod_naidoo.Logic
{
    public class Admin : IAdmin
    {

        private readonly ITSADbContext _dbContext;

        public Admin(ITSADbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<User>> SearchResults(string UserID)
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
        
        public async Task<List<User>> ViewDetails(string UserID)
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
    }
}
