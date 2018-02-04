using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using userAuthenticationApp.Models;

namespace userAuthenticationApp.Controllers {

    public class HomeController : Controller {

        public IActionResult Index() {
            if(HttpContext.Session.GetString("auth") != "true") {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

    }
}
