using System;
using System.Collections.Generic;

namespace ezExPrep.Models
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
