using ITSA_Delon_Jarrod_naidoo.Data;
using ITSA_Delon_Jarrod_naidoo.Interface;
using ITSA_Delon_Jarrod_naidoo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSA_Delon_Jarrod_naidoo.Logic
{
    public class Admin : IAdmin
    {
        private readonly ITSADbContext _dbContext;

        public Admin(ITSADbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<User>> SearchResults(string searchItem)
        {
            try
            {
                IQueryable<User> query = _dbContext.Users.OrderByDescending(u => u.UserId);

                if (!string.IsNullOrEmpty(searchItem))
                {
                    query = query.Where(u => u.Name.Contains(searchItem) || u.Surname.Contains(searchItem));
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while searching for users.", ex);
            }
        }

        public async Task<User> ViewDetails(int userID)
        {
            try
            {
                return await _dbContext.Users
                    .Include(u => u.Address)
                    .ThenInclude(a => a.Meter)
                    .Where(u => u.UserId == userID)
                    .OrderByDescending(u => u.UserId)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving user details.", ex);
            }
        }

        public async Task<User> Update(User user)
        {
            try
            {
                var existingUser = await _dbContext.Users
                    .Include(u => u.Address)
                    .ThenInclude(a => a.Meter)
                    .FirstOrDefaultAsync(u => u.UserId == user.UserId);

                if (existingUser != null)
                {
                    _dbContext.Entry(existingUser).CurrentValues.SetValues(user);
                    await _dbContext.SaveChangesAsync();
                }

                return existingUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating user.", ex);
            }
        }

        public async Task<User> Create(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while creating user.", ex);
            }
        }

        public async Task<User> Delete(int userId)
        {
            try
            {
                var existingUser = await _dbContext.Users.FindAsync(userId);
                if (existingUser != null)
                {
                    _dbContext.Users.Remove(existingUser);
                    await _dbContext.SaveChangesAsync();
                }
                return existingUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while deleting user.", ex);
            }
        }
    }
}
