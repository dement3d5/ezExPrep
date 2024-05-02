using System;
using System.Collections.Generic;

namespace ezExPrep.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? OrderStausId { get; set; }
        public int? ProductId { get; set; }
        public string? Cost { get; set; }

        public virtual OrderStatus? OrderStaus { get; set; }
        public virtual Product? Product { get; set; }
    }
}
