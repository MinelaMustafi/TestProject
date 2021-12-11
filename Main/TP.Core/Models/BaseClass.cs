using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TP.Core.Models
{
    public class BaseClass
    {
        public BaseClass()
        {
            IsDeleted = false;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
