using System;
using System.Collections.Generic;

#nullable disable

namespace demoerpnxt.Models
{
    public partial class Bill
    {
        public int Billno { get; set; }
        public int? Buyersid { get; set; }
        public string Buyersname { get; set; }
        public DateTime? Buydate { get; set; }
        public int? Itemsid { get; set; }
        public string Itemsname { get; set; }
        public int? Itemsquant { get; set; }
        public int? Sellersid { get; set; }
        public string Sellersname { get; set; }
        public double? Totalamount { get; set; }
        public double? Paidamount { get; set; }
        public double? Remainingamount { get; set; }

        public virtual Buyer Buyers { get; set; }
        public virtual Item Items { get; set; }
        public virtual Seller Sellers { get; set; }
    }
}
