using ITSA_Delon_Jarrod_naidoo.Data;
using ITSA_Delon_Jarrod_naidoo.Interface;
using ITSA_Delon_Jarrod_naidoo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITSA_Delon_Jarrod_naidoo.Controllers
{
    public class AdminController : Controller
    {
      
        private readonly IAdmin _admin;
        public AdminController(IAdmin Admin)
        {
            _admin = Admin;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SearchResults(string UserId)
        {
            return View(await _admin.SearchResults(UserId));
        }        
        
        public async Task<IActionResult> ViewDetails(string UserId)
        {
            return View(await _admin.ViewDetails(UserId));
        }
    }
}
