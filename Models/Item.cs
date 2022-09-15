using System;
using System.Collections.Generic;

#nullable disable

namespace demoerpnxt.Models
{
    public partial class Item
    {
        public Item()
        {
            Bills = new HashSet<Bill>();
        }

        public int Itemid { get; set; }
        public string Itemname { get; set; }
        public int? Itemquant { get; set; }
        public int? Itemprice { get; set; }
        public DateTime? Itemlastupdate { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
