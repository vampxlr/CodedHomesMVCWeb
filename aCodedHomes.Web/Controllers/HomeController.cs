using CodedHomes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodedHomes.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DataContext context = new DataContext();
            context.Database.Initialize(true);
            return View();
        }
    }
}
