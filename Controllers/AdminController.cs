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

        public IActionResult CreateForm()
        {
            return View();
        }

        public async Task<IActionResult> SearchResults(string searchItem)
        {
            return View(await _admin.SearchResults(searchItem));
        }        
        
        public async Task<IActionResult> ViewDetails(int UserId)
        {
           return View(await _admin.ViewDetails(UserId));
        }
        public async Task<IActionResult> Update(User User)
        {
           return View(await _admin.Update(User));
        }

        public async Task<IActionResult> Create(User User)
        {
            return View(await _admin.Create(User));
        }
        public async Task<IActionResult> Delete(int UserId)
        {
            return View(await _admin.Delete(UserId));
        }


    }
}
