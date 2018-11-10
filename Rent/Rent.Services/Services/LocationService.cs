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
    public class LocationService:Connection,ILocation
    {
        public IList<City> GetCities(int StateId)
        {
            //_dbCmd.Parameters.AddRange(new SqlParameter[] {
            //             new SqlParameter("@Drugname",DrugName ),
            //             new SqlParameter("@CountryId",CountryId ),
            //             new SqlParameter("@UserId",UserID ),
            //                 new SqlParameter("@IsMedicine",IsMedicine)


            //        });
            
            _cmd.Parameters.AddRange(new SqlParameter[] {
                 new SqlParameter("@StateId",StateId ),
            });
            _cmd.CommandText = "SP_GetCity";
            return  GetList<City>();
        }

        public IList<State> GetState()
        {
            _cmd.CommandText = "SP_GetState";
            return GetList<State>();
        }

        public IList<PropertyType> GetPropertyType()
        {
            _cmd.CommandText = "SP_GetPropertyType";
            return GetList<PropertyType>();
        }
    }
}
