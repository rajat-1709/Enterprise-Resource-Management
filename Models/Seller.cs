using System;
using System.Collections.Generic;

#nullable disable

namespace demoerpnxt.Models
{
    public partial class Seller
    {
        public Seller()
        {
            Bills = new HashSet<Bill>();
        }

        public int Sellerid { get; set; }
        public string Sellername { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
