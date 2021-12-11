using System.ComponentModel;

namespace TP.Core.Models
{
    public class Driver : BaseClass
    {
        [Description("Required")]
        public string Name { get; set; }
        [Description("Required")]
        public virtual Company Company { get; set; }
    }
}
