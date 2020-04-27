using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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