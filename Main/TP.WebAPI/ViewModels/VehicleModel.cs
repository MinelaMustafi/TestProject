using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP.WebAPI.ViewModels
{
    public class VehicleModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public CompanyModel Company { get; set; }
    }
}
