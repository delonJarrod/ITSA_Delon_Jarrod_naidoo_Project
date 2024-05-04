namespace ITSA_Delon_Jarrod_naidoo.Models
{
    public class Dashboard
    {
        public int TotalUsers { get; set; }
        public int TotalAddresses { get; set; }
        public int TotalMeters { get; set; }
        public List<User> Search { get; set; }
    }
}
