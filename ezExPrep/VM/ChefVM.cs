
using ezExPrep.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ezExPrep.VM
{
    public class ChefVM : BaseVM
    {
        public List<Order> orders { get; set; }
        private Order listOrder;
        public Order ListOrder
        {
            get => listOrder;
            set
            {
                listOrder = value;
                Signal();

            }
        }

        public void UpdateOrderStatus(Order order, int statusId)
        {
            using (var db = new user2Context())
            {
                var updatedOrder = db.Orders.FirstOrDefault(o => o.Id == order.Id);
                if (updatedOrder != null)
                {
                    updatedOrder.OrderStausId = statusId;
                    db.SaveChanges();
                }
            }
        }

        public void RefreshOrders()
        {
            using (var db = new user2Context())
            {
                orders = db.Orders.Include(o => o.Product).Include(o => o.OrderStaus).ToList();
                Signal(nameof(orders));
            }
        }

          
        public ChefVM()
        {
            using ( var db = new user2Context())
            {
                orders = db.Orders.Include(o => o.Product).Include(o => o.OrderStaus).ToList();
            }

        
        
        
        } 
    }
}
