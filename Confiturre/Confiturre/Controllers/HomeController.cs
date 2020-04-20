using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Confiturre.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ActiveName = "About";
            return View();
        }
        public IActionResult News()
        {
            ViewBag.ActiveName = "News";
            return View();
        }
        public IActionResult Portfolio()
        {
            ViewBag.ActiveName = "Portfolio";
            return View();
        }
        public IActionResult Contacts()
        {
            ViewBag.ActiveName = "Contacts";
            return View();
        }
    }
}