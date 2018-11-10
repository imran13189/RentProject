using Rent.Common;
using Rent.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Rent.Filters
{
    public class AuthenticateFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (SessionManager.LoggedInUser.UserID <= 0)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                    FormsAuthenticationTicket ticket = id.Ticket;
                    //FormsAuthentication.SetAuthCookie(data.Email, false);
                    var serializer = new JavaScriptSerializer();
                    var data = serializer.Deserialize<UserModel>(ticket.UserData);
                    SessionManager.FillSession(data.UserId, data.Email, data.Name, data.RoleId);
                }
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                {
                    HttpContext.Current.Response.Redirect("~/Account/Login");
                }
            }
        }
    }
}