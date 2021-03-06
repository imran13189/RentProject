﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Entities.Model;
namespace Rent.Services.Interfaces
{
    public interface IUser
    {
        UserModel AddUser(UserModel userModel);
        UserModel GetUserDetails(UserModel model);
        bool IsEmailExist(string Email);
        bool IsMobileExist(string Mobile);
    }
}
