using Microsoft.AspNetCore.Mvc;
using MVCExample.ExceptionClasses;
using MVCExample.Models;
using System.Diagnostics;

namespace MVCExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _accessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor accessor)
        {
            _logger = logger;
            _accessor = accessor;
        }

        public IActionResult Index()
        {
            var user = _accessor.HttpContext.User;
            HttpContext.Session.SetString("UserName", "Nitesh");
            HttpContext.Session.SetInt32("UserId", 30);
            return View();
        }

        public IActionResult Privacy()
        {
            try
            {
                // Retrive Session values
                string? userName = HttpContext.Session.GetString("UserName");
                int? userId = HttpContext.Session.GetInt32("UserId");
                ViewBag.UserName = userName;
                ViewBag.UserId = userId;
                return View();
            } catch (MyExceptionClass ex)
            {
               return Ok(ex.Message);
            }
           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


// this is sample code for create sessions for complex objects 

//using System.Text.Json;
//public static class SessionExtensions
//{
//    public static void SetObject<T>(this ISession session, string key, T value)
//    {
//        session.SetString(key, JsonSerializer.Serialize(value));
//    }
//    public static T? GetObject<T>(this ISession session, string key)
//    {
//        var value = session.GetString(key);
//        return value == null ? default : JsonSerializer.Deserialize<T>(value);
//    }
//}

// how to use this 
//var user = new { Id = 1, Name = "Ramesh" };
//HttpContext.Session.SetObject("CurrentUser", user);
//var currentUser = HttpContext.Session.GetObject<dynamic>("CurrentUser");
//=====================================
//Accessing session in page
//@inject IHttpContextAccessor HttpContextAccessor
//<p>Hello, @HttpContextAccessor.HttpContext.Session.GetString("UserName")</p>