using System.ComponentModel.DataAnnotations;

namespace ITSA_Delon_Jarrod_naidoo.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string IdentityNumber { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        // Foreign key
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
