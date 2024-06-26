﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSA_Delon_Jarrod_naidoo.Models
{
    public class Address
    {

        [Key]
        public int AddressId { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Suburb { get; set; }

        [Required]
        public string PostalCode { get; set; }

        public string UnitNumber { get; set; }

        public string ComplexName { get; set; }

        public int MeterId { get; set; }
        public Meter Meter { get; set; }
    }
}
