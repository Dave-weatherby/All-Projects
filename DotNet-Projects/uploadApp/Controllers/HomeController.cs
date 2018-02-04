using System;
using Microsoft.AspNetCore.Mvc;
using uploadApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace uploadApp.Controllers {

    public class HomeController : Controller {

        private IHostingEnvironment environment;
        public HomeController (IHostingEnvironment env) {
            environment = env;
        }  

        public IActionResult Index() {
            ImageManager imageManager = new ImageManager();
            imageManager.setupMe(environment, "uploads", "");
            ViewData["feedback"] = "";
            return View(imageManager);
        }

        [HttpPost]
        public IActionResult Upload(ImageManager imageManager, IFormFile selectedFile) {
            ImageUploader imageUploader = new ImageUploader();
            imageUploader.setupMe(environment, "uploads");

            int result = imageUploader.uploadImage(selectedFile);
            string errorMessage = imageUploader.errorMessage();

            imageManager.setupMe(environment, "uploads", errorMessage);            
            return View("Index", imageManager);
        }

    }
}
