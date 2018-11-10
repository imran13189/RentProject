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
        public UserModel AddUser(UserModel userModel)
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
            userModel.UserId= _db.SaveChanges();
            return userModel;
        }
        public UserModel GetUserDetails(UserModel model)
        {
           User user= _db.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if(user!=null)
            {
                model.UserId = user.UserId;
                model.Email = user.Email;
                model.IsUserExist = true;
                model.RoleId = user.RoleId;
                    }
            else
            {
                model.IsUserExist = false;
            }
            return model;
        }
        public bool IsEmailExist(string Email)
        {
          return  !_db.Users.Any(x => x.Email == Email);
        }
        public bool IsMobileExist(string Mobile)
        {
            return !_db.Users.Any(x => x.Mobile == Mobile);
        }
    }
}
