using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rent.Filters;
namespace Rent.Controllers
{
    //[AuthenticateFilter]
    public class PropertyController : Controller
    {
        // GET: Property
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PropertyFiles(long PropertyId)
        {
            ViewBag.PropertyId = PropertyId;
            return View();
        }
    }
}