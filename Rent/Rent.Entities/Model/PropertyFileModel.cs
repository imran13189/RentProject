﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Entities.Model
{
    public class PropertyFileModel
    {
        public long PhotoId { get; set; }
        public string FileName { get; set; }
        public long PropertyId { get; set; }
    }
}
