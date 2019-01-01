using Rent.Common;
using Rent.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Rent.Services.Interfaces;
using System.Web.Script.Serialization;

namespace Rent.Controllers
{
    public class AccountController : Controller
    {
        IUser _user;
        public AccountController(IUser user)
        {
            _user = user;
        }
        // GET: Account
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            return RedirectToAction("Index", "Property");
            else
                return View();

        }

        [HttpPost]
        public ActionResult Login(string Email,string Password,int RoleId)
        {
            UserModel model = new UserModel();
            model.Email = Email;
            model.Password = Password;
            UserModel data = _user.GetUserDetails(model);

            if (model.IsUserExist)
            {
                SessionManager.FillSession(data.UserId, data.Email, data.Name, data.RoleId);
                //FormsAuthentication.SetAuthCookie(data.Email, false);
                var serializer = new JavaScriptSerializer();
                string userData = serializer.Serialize(data);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
             data.Email,
             DateTime.Now,
             DateTime.Now.AddDays(30),
             true,
             userData,
             FormsAuthentication.FormsCookiePath);
                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);
                // Create the cookie.
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));


                if (RoleId==2)
                {
                    return RedirectToAction("Rent", "Property");
                }

                //return RedirectToAction("Index", "Account");
            }

            //return RedirectToAction("Index","Account");
            return Json(false);
        }
        public ActionResult LogOut()
        {
            //Session.Abandon();
            FormsAuthentication.SignOut();
            //System.Web.HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

            return RedirectToAction("Login", "Account");
        }

        private static HttpCookie GenerateAuthTicketforSRentUser(UserModel loginM, String sRentRole)
        {
            FormsAuthentication.SetAuthCookie(loginM.UserName, false);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, loginM.UserName, DateTime.Now, DateTime.Now.AddDays(1), false, sRentRole);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            return cookie;
        }
    }
}