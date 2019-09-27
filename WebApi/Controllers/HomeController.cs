using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        private ApiDbContext db = new ApiDbContext();

        public ActionResult Index()
        {
            var households = db.Households.FirstOrDefault();

            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult LandingPage()
        {

            return View();
        }
    }
}
