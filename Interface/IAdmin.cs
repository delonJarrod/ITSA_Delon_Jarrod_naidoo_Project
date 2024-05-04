using ITSA_Delon_Jarrod_naidoo.Models;

namespace ITSA_Delon_Jarrod_naidoo.Interface
{
    public interface IAdmin
    {
        public Task<List<User>> SearchResults(string UserId);
        public Task<User> ViewDetails(int UserId);
        public Task<User> Update(User User);
    }
}
