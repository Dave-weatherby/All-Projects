using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using userAuthenticationApp.Models;

namespace userAuthenticationApp.Controllers {

    public class LoginController : Controller {

        public IActionResult Index() {
            return View();
        }

        public IActionResult Submit(string myUsername, string myPassword) {
            WebLogin webLogin = new WebLogin("Database=weatherb_dotNetCoreSamples;Data Source=db.nscctruro.ca;User Id=weatherb_Admin;Password=mySQLpassword123;SslMode=None"
            , "tbllogin", HttpContext);

            webLogin.username = myUsername;
            webLogin.password = myPassword;

            // login attempt
            if (webLogin.unlock()) {
                return RedirectToAction("Index", "Home");
            } else {
                ViewData["feedback"] = "Incorrect Login. Try again loser...";
            }
            
            return View("Index");
        }

    }
}
