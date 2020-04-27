using System;
using System.Data;
using Confiturre.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Confiturre.Controllers
{
    public class HomeController : Controller
    {
        IDbConnection _connection;

        public HomeController(IDbConnection connection) => _connection = connection;

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

                var sql = $"insert into dbo.Messages(Name, Email, Message) values ('{messageVM.Name}','{messageVM.Email}','{messageVM.Message}')";
                var count = _connection.Execute(sql);

                success = count > 0;
                message = "Your message was successfully sent!";
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            return Json(new { success, message });
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            _connection.Dispose();
        }
    }
}