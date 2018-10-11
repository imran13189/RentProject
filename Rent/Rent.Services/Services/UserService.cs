using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Services.Interfaces;
using Rent.Entities.Model;
using Rent.DAL;

namespace Rent.Services
{
    public class UserService:Connection,IUser
    {
        public void AddUser(UserModel userModel)
        {
            _db.Users.Add(new User()
            {
                Name=userModel.Name,
                Email=userModel.Email,
                Mobile=userModel.Mobile,
                Password=userModel.Password,
                CreatedDate=DateTime.UtcNow,
                ModifiedDate=DateTime.UtcNow,
                RoleId=userModel.RoleId,
                IsActive=true
            });
            _db.SaveChanges();
        }

        public UserModel GetUserDetails(UserModel model)
        {
           User user= _db.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if(user!=null)
            {
                model.IsUserExist = true;
                    }
            else
            {
                model.IsUserExist = false;
            }
            return model;
        }
    }
}
