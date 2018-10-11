using System;
using System.Web.Http;
using Rent.Services.Interfaces;
using Rent.Entities.Model;
using System.Collections.Generic;
using System.Linq;
namespace Rent.API
{
    public class LocationAPIController : ApiController
    {
        ILocation _location;
        public LocationAPIController(ILocation location)
        {
            _location = location;
        }

        public IList<City> GetCitites(int StateId)
        {
            try
            {
                return _location.GetCities(StateId);
            }
            catch
            {
                throw;
            }
        }

        public IList<State> GetStates()
        {
            try
            {
                return _location.GetState();
            }
            catch
            {
                throw;
            }
        }

        public IList<PropertyType> GetProperty()
        {
            try
            {
                return _location.GetPropertyType();
            }
            catch
            {
                throw;
            }
        }
    }
}
