using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Rent.Common;
using Rent.Entities.Model;
using Rent.Services.Interfaces;

namespace Rent.API
{
    public class RentAPIController : ApiController
    {
        IRent _rent;
        public RentAPIController(IRent rent)
        {
            _rent = rent;
        }
        [HttpPost]
        public PropertyRentModel SaveProperty(PropertyRentModel model)
        {
           return _rent.SaveRentProperty(model);
        }

        [HttpPost]
        public dynamic UploadFile()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            long PropertyId = Convert.ToInt64(HttpContext.Current.Request.Form["PropertyId"]);
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    string fileName = "Rent_" + DateTime.Now.ToString("yyyyMMddHHmmssfff")+".jpg";
                    var filePath1 = HttpContext.Current.Server.MapPath("~/RentPropertyFiles/" + fileName);
                    Stream strm = postedFile.InputStream;
                    Utilities.Compressimage(strm, filePath1, postedFile.FileName);
                    _rent.SaveFile(new PropertyFileModel() {PropertyId= PropertyId,FileName=fileName });
                }
                response = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return response;
        }

        [HttpGet]
        public IList<PropertyRentSearchModel> GetProperties(PropertyRentSearchModel SearchModel)
        {
           return _rent.GetProperties(SearchModel);
        }

        [HttpGet]
        public IList<PropertyRentSearchModel> SearchProperties(PropertyRentSearchModel SearchModel)
        {
            return _rent.GetProperties(SearchModel);
        }
    }
}
