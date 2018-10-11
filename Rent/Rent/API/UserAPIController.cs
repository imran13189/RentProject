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
                _user.AddUser(userModel);
                return true;
            }
            catch(Exception e)
                {
                throw;
            }
        }
    }
}
