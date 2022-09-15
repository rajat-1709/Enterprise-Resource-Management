using System;
using System.Collections.Generic;

#nullable disable

namespace demoerpnxt.Models
{
    public partial class Buyer
    {
        public Buyer()
        {
            Bills = new HashSet<Bill>();
        }

        public int Buyerid { get; set; }
        public string Buyername { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
