using System;
using System.Collections.Generic;
using System.Text;

namespace TP.Core.Models
{
    public class Company
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Driver> Drivers { get; set; }
    }
}
