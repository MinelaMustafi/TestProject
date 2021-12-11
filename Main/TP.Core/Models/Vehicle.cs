using System.Collections.Generic;
using System.ComponentModel;

namespace TP.Core.Models
{
    public class Vehicle : BaseClass
    {
        [Description("Required")]
        public string Name { get; set; }
        [Description("Required")]
        public virtual Company Company { get; set; }
    }
}
