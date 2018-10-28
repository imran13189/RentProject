using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Rent.Services.Interfaces;
using Rent.Entities.Model;
namespace Rent.API
{
    public class UserAPIController : ApiController
    {
        IUser _user;
        public UserAPIController(IUser user)
        {
            _user = user;
        }

        [HttpPost]
        public dynamic Register(UserModel userModel)
        {
            try
            {
               return _user.AddUser(userModel);
                
            }
            catch(Exception e)
                {
                throw;
            }
        }

        [HttpGet]
        public bool IsEmailExist(string Email)
        {
          return  _user.IsEmailExist(Email);
        }

        [HttpGet]
        public bool IsMobileExist(string Mobile)
        {
            return _user.IsMobileExist(Mobile);
        }
    }
}
