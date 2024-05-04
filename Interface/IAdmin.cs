using ITSA_Delon_Jarrod_naidoo.Models;

namespace ITSA_Delon_Jarrod_naidoo.Interface
{
    public interface IAdmin
    {
        public Task<List<User>> SearchTopThree();
        public Task<List<User>> SearchResults(string searchItem);
        public Task<User> ViewDetails(int UserId);
        public Task<User> Update(User User);
        public Task<User> Create(User User);
        public Task<User> Delete(int UserId);
        public Task<Dashboard> Dashboard();
    }
}
