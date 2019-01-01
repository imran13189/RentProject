using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Services.Interfaces;
using Rent.Entities.Model;
using Rent.DAL;
using System.Data.SqlClient;

namespace Rent.Services
{
    public class RentService : Connection,IRent
    {
       public PropertyRentModel SaveRentProperty(PropertyRentModel model)
        {
            try
            {
                PropertyRent rent = new PropertyRent();
                rent.Locality = model.Locality;
                rent.PropertyType = model.PropertyType;
                rent.SecurityAmount = model.SecurityAmount;
                rent.MaintenanceCharges = model.MaintenanceCharges;
                rent.Address = model.Address;
                rent.ADType = model.ADType;
                rent.Area = model.Area;
                rent.AU = model.AU;
                rent.AvailableDate = model.AvailableDate;
                rent.AvailableStatus = model.AvailableStatus;
                rent.BathroomNum = model.BathroomNum;
                rent.BikeParking = model.BikeParking;
                rent.CarParking = model.CarParking;
                rent.CityId = model.CityId;
                rent.Description = model.Description;
                rent.ExpectedPrice = model.ExpectedPrice;
                rent.FacingId = model.FacingId;
                rent.FloorNum = model.FloorNum;
                rent.FurnishedType = model.FurnishedType;
                rent.Lift = model.Lift;
                rent.Mobile = model.Mobile;
                rent.ProjectSociety = model.ProjectSociety;
                rent.PropertyName = model.PropertyName;
                rent.SecurityAmount = model.SecurityAmount;
                rent.TotalFloor = model.TotalFloor;
                rent.Water = model.Water;
                rent.ModifiedDate = DateTime.UtcNow;
                rent.UserId = model.UserId;
                _db.PropertyRents.Add(rent);
                _db.SaveChanges();
                model.PropertyId = rent.PropertyId;
                return model;
            }
            catch { throw; }
        }

        public bool SaveFile(PropertyFileModel file)
        {
            try
            {
                _db.PropertyFiles.Add(new PropertyFile()
                {
                    FileName = file.FileName,
                    PropertyId = file.PropertyId
                });
                _db.SaveChanges();
                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public IList<PropertyRentSearchModel> GetProperties(PropertyRentSearchModel SearchModel)
        {
            _cmd.Parameters.AddRange(new SqlParameter[] {
                 new SqlParameter("@UserId",SearchModel.UserId ),
                 new SqlParameter("@PageNumber",SearchModel.PageNumber ),
                 new SqlParameter("@PageSize",SearchModel.PageSize ),
                 new SqlParameter("@PropertyName",SearchModel.PropertyName ),
            });
            _cmd.CommandText = "GetProperties";
            return GetList<PropertyRentSearchModel>();
        }

        public PropertyRentModel GetRentProperty(int PropertyId)
        {
            _cmd.Parameters.AddRange(new SqlParameter[] {
                 new SqlParameter("@PropertyId",PropertyId)
            });
            _cmd.CommandText = "SP_GetRentProperty";
            return GetProperty<PropertyRentModel>();
        }
    }
}
