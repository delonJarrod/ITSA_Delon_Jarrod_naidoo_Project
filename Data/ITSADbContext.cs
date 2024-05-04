using ITSA_Delon_Jarrod_naidoo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ITSA_Delon_Jarrod_naidoo.Data
{
    public class ITSADbContext : DbContext
    {
        public ITSADbContext(DbContextOptions<ITSADbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define your database schema and relationships here
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Meter> Meters { get; set; }

        public void SeedData()
        {
            try
            {
                // Check if the Meter table is empty
                if (!Meters.Any())
                {
                    // Add seeding logic here for Meters
                    Meters.AddRange(
                        new Meter { SerialNumber = "Serial1", MeterType = "Type1", AssetName = "Asset1", VoltageAmperage = 10.5M },
                        new Meter { SerialNumber = "Serial2", MeterType = "Type2", AssetName = "Asset2", VoltageAmperage = 20.5M }
                    );

                    // Save changes to the database
                    SaveChanges();
                }

                // Check if the Address table is empty
                if (!Address.Any())
                {
                    // Add seeding logic here for Addresses
                    var meter1 = Meters.FirstOrDefault();
                    var meter2 = Meters.Skip(1).FirstOrDefault();
                    Address.AddRange(
                        new Address { Country = "Country1", Province = "Province1", City = "City1", Suburb = "Suburb1", PostalCode = "12345", UnitNumber = "1A", ComplexName = "Complex1", MeterId = (int)(meter1?.MeterId) },
                        new Address { Country = "Country2", Province = "Province2", City = "City2", Suburb = "Suburb2", PostalCode = "67890", UnitNumber = "2B", ComplexName = "Complex2", MeterId = (int)(meter2?.MeterId) }
                    );

                    // Save changes to the database
                    SaveChanges();
                }

                // Check if the User table is empty
                if (!Users.Any())
                {
                    // Add seeding logic here for Users
                    var address1 = Address.FirstOrDefault();
                    var address2 = Address.Skip(1).FirstOrDefault(a => a.Country == "Country2");
                    Users.AddRange(
                        new User { Name = "John", Surname = "Doe", DateOfBirth = new DateTime(1990, 1, 1), IdentityNumber = "1234567890123", EmailAddress = "john@example.com", ContactNumber = "1234567890", AddressId = (int)address1?.AddressId },
                        new User { Name = "Jane", Surname = "Smith", DateOfBirth = new DateTime(1985, 5, 15), IdentityNumber = "9876543210987", EmailAddress = "jane@example.com", ContactNumber = "9876543210", AddressId = (int)address2?.AddressId }
                    );

                    // Save changes to the database
                    SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
