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
        //public ActionResult SaveUploadedFile()
        //{
        //    bool isSavedSuccessfully = true;
        //    string fName = "";
        //    try
        //    {
        //        foreach (string fileName in Request.Files)
        //        {
        //            HttpPostedFileBase file = Request.Files[fileName];
        //            //Save file content goes here
        //            fName = file.FileName;
        //            if (file != null && file.ContentLength > 0)
        //            {

        //                var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\WallImages", Server.MapPath(@"\")));

        //                string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "imagepath");

        //                var fileName1 = Path.GetFileName(file.FileName);

        //                bool isExists = System.IO.Directory.Exists(pathString);

        //                if (!isExists)
        //                    System.IO.Directory.CreateDirectory(pathString);

        //                var path = string.Format("{0}\\{1}", pathString, file.FileName);
        //                file.SaveAs(path);

        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        isSavedSuccessfully = false;
        //    }


        //    if (isSavedSuccessfully)
        //    {
        //        return Json(new { Message = fName });
        //    }
        //    else
        //    {
        //        return Json(new { Message = "Error in saving file" });
        //    }
        //}
    }
}
