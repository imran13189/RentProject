using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rent.Entities.Model;
using Rent.Filters;
using Rent.Services.Interfaces;

namespace Rent.Controllers
{
    [AuthenticateFilter]
    public class PropertyController : Controller
    {
        IRent _rent;
        public PropertyController(IRent rent)
        {
            _rent = rent;
        }

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
        public ActionResult UserProperties()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetProperties(PropertyRentSearchModel searchModel)
        {
            //var dummyItems = Enumerable.Range(1, 150).Select(x => "Item " + x);
            //var pager = new Pager(dummyItems.Count(), page);

            //var viewModel = new IndexViewModel
            //{
            //    Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
            //    Pager = pager
            //};
            PropertiesViewModel model = new PropertiesViewModel();
            model.SearchModel = _rent.GetProperties(searchModel);
            model.pager = new Pager(model.SearchModel.FirstOrDefault().TotalRows, searchModel.PageNumber);

            return View();
        }
    }
}