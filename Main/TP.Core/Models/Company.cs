using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TP.Core.Models
{
    public class Company : BaseClass
    {
        [Description("Required")]
        public string Name { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
