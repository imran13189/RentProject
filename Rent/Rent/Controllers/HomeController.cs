using Rent.Entities.Model;
using Rent.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rent.Controllers
{
    public class HomeController : Controller
    {
        IRent _rent;
        public HomeController(IRent rent)
        {
            _rent = rent;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult PropertyDetails(string id)
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PropertyRent(PropertyRentSearchModel searchModel)
        {
            return View(searchModel);
        }

        [HttpPost]
        public ActionResult _PropertyRent(PropertyRentSearchModel searchModel)
        {

            PropertiesViewModel model = new PropertiesViewModel();
            try
            {
                model.SearchModel = _rent.SearchRentProperty(searchModel);
                if (model.SearchModel.Count > 0)
                    model.pager = new Pager(model.SearchModel.FirstOrDefault().TotalRows, searchModel.PageNumber, searchModel.PageSize);
                else
                    model.pager = new Pager(2, searchModel.PageNumber);

            }
            catch (Exception e)
            {

            }
            return View(model);
        }
    }
}
