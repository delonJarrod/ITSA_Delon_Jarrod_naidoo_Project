using ITSA_Delon_Jarrod_naidoo.Data;
using ITSA_Delon_Jarrod_naidoo.Interface;
using ITSA_Delon_Jarrod_naidoo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize]
        public async Task<List<User>> SearchTopThree()
        {
            try
            {
                return await _dbContext.Users.OrderByDescending(u => u.UserId).Take(3).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while searching for users.", ex);
            }
        }
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public async Task<Dashboard> Dashboard()
        {
            var totalUsers = await _dbContext.Users.CountAsync();
            var totalAddresses = await _dbContext.Address.CountAsync();
            var totalMeters = await _dbContext.Meters.CountAsync();
            var topThree = SearchTopThree();
            var viewModel = new Dashboard
            {
                TotalUsers = totalUsers,
                TotalAddresses = totalAddresses,
                TotalMeters = totalMeters,
                Search = await topThree
            };

            return viewModel;
        }
    }
}
