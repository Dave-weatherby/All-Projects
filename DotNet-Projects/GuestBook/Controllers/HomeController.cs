using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_I.Models;

namespace Project_I.Controllers {

    public class HomeController : Controller {

        public IActionResult Index() {
            GuestBook guestBook = new GuestBook();
            guestBook.setUpMe();

            return View(guestBook);
        }

        [HttpPost]
        public IActionResult Submit (GuestBook guestBook, string firstName, string lastName, string entry) {
            // using the addEntry method adds a entry to the database
            guestBook.addEntry(firstName,lastName,entry);
            // sets the value of the checkbox to true so the form will stay open
            guestBook.check = true;
            // refresh the table to get the new entry
            guestBook.setUpMe();
            
            return View("Index", guestBook);
        }
    }
}
