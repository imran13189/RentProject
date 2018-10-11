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
                _db.PropertyRents.Add(rent);
                model.PropertyId= _db.SaveChanges();
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
    }
}
