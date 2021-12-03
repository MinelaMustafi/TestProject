using System.Collections.Generic;

namespace TP.Core.Models
{
    public class Vehicle
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public ICollection<Driver> Drivers { get; set; }
    }
}
