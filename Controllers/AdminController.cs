using ITSA_Delon_Jarrod_naidoo.Interface;
using ITSA_Delon_Jarrod_naidoo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ITSA_Delon_Jarrod_naidoo.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdmin _admin;

        public AdminController(IAdmin admin)
        {
            _admin = admin;
        }

        [Route("Admin/Search")]
        public async Task<IActionResult> Index()
        {
            return View(await _admin.SearchTopThree());
        }

        [Route("Admin/Create")]
        public IActionResult CreateForm()
        {
            return View();
        }        
        
        [Route("Admin/DashBoard")]
        public async Task<IActionResult> DashBoard()
        {
            return View(await _admin.Dashboard());
        }

        public async Task<IActionResult> SearchResults(string searchItem)
        {
            return PartialView(await _admin.SearchResults(searchItem));
        }

        public async Task<IActionResult> ViewDetails(int userId)
        {
            return PartialView(await _admin.ViewDetails(userId));
        }

        [Route("Admin/Update")]
        public async Task<IActionResult> Update(User user)
        {
            return View(await _admin.Update(user));
        }

        public async Task<IActionResult> Create(User user)
        {
            return View(await _admin.Create(user));
        }

        public async Task<IActionResult> Delete(int userId)
        {
            return View(await _admin.Delete(userId));
        }
    }
}
