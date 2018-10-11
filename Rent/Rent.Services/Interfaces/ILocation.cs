using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Entities.Model;
namespace Rent.Services.Interfaces
{
    public interface ILocation
    {
        IList<City> GetCities(int StateId);
        IList<State> GetState();
        IList<PropertyType> GetPropertyType();
    }
}
