using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Entities.Model
{
    public class PropertiesViewModel
    {
        public IList<PropertyRentSearchModel> SearchModel { get; set; }
        public Pager pager { get; set; }
    }
}
