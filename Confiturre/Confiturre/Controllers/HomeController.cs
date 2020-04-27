using System;
using Confiturre.Models;
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
        public IActionResult Portfolio(string name = "MokkoCake")
        {
            ViewBag.ActiveName = "Portfolio";
            return View(name);
        }
        public IActionResult Contacts()
        {
            ViewBag.ActiveName = "Contacts";
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(MessageVM messageVM)
        {
            bool success;
            string message;
            try
            {
                if (string.IsNullOrWhiteSpace(messageVM.Name))
                {
                    throw new Exception("Name is required!");
                }
                if (string.IsNullOrWhiteSpace(messageVM.Email))
                {
                    throw new Exception("Email is required!");
                }
                if (string.IsNullOrWhiteSpace(messageVM.Message))
                {
                    throw new Exception("Message is required!");
                }
                success = true;
                message = "Your message was successfully sent!";
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            return Json(new { success, message });
        }

    }
}