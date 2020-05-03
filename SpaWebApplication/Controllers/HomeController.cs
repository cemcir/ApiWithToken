using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApıWithToken.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaWebApplication.Models;
using SpaWebApplication.ViewModels;
using System.Web;


namespace SpaWebApplication.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Spa()
        {
            return View();
        }

        public IActionResult Profiler()
        {
            return View();
        }

        public IActionResult Member()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View(new ErrorViewModels());
        }

        public IActionResult ProductRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MoveUserInformation(Models.UserViewModel userViewModel)
        {
            return View(userViewModel);
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Profiles()
        {
            return View();
        }
        /*
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            TempData["Id"] = product.Id;
            return Json(new {result=TempData["Id"],message="Başarılı."});
            
        }

        [HttpPost]
        public IActionResult ProductForm(int id)
        {
            TempData["Id"] = id;
            return View();
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        */
    }
}
