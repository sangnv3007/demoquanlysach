using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloTanDan.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult DeatailBook()
        {
            return View();
        }
        public ActionResult ListBook()
        {
            return View();
        }
    }
}