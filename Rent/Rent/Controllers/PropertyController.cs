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
        public ActionResult Rent(int? id)
        {
            if (id.HasValue)
              return View(_rent.GetRentProperty(id.Value));

            return View(new PropertyRentModel());
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
        public ActionResult _UserProperties(PropertyRentSearchModel searchModel)
        {
            
            PropertiesViewModel model = new PropertiesViewModel();
            try
            {
                model.SearchModel = _rent.GetProperties(searchModel);
                if(model.SearchModel.Count>0)
                    model.pager = new Pager(model.SearchModel.FirstOrDefault().TotalRows, searchModel.PageNumber,searchModel.PageSize);
                else
                    model.pager = new Pager(2, searchModel.PageNumber);

            }
            catch { }
            return View(model);
        }

    }
}