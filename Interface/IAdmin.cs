using ITSA_Delon_Jarrod_naidoo.Models;

namespace ITSA_Delon_Jarrod_naidoo.Interface
{
    public interface IAdmin
    {
        public Task<List<User>> SearchResults(string UserId);
        public Task<List<User>> ViewDetails(int UserId);
    }
}
