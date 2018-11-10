using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent.Entities.Model;
namespace Rent.Services.Interfaces
{
    public interface IRent
    {
        PropertyRentModel SaveRentProperty(PropertyRentModel model);
        bool SaveFile(PropertyFileModel file);
        IList<PropertyRentSearchModel> GetProperties(PropertyRentSearchModel SearchModel);
    }
}
