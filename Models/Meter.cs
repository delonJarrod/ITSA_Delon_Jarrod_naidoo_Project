using System.ComponentModel.DataAnnotations;

namespace ITSA_Delon_Jarrod_naidoo.Models
{
    public class Meter
    {
        [Key]
        public int MeterId { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        [Required]
        public string MeterType { get; set; }

        [Required]
        public string AssetName { get; set; }

        [Required]
        public decimal VoltageAmperage { get; set; }
    }
}
