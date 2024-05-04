using ezExPrep.DB;
using ezExPrep.Models;
using ezExPrep.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ezExPrep.VM
{
    public class AddOrder : BaseVM
    {
        public string Cost { get; set; }
        public List<Order> Order { get; }

        public CommandVM ADD { get; set; }

        public List<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }

        public AddOrder()
        {
            using (var db = new user2Context())
            {
                Products = db.Products.ToList();
            }

            ADD = new CommandVM(() =>
            {
                using (var db = new user2Context())
                {
                    var orderStatus = db.OrderStatuses.FirstOrDefault(s => s.Id == 1);
                    var order = new Order
                    {
                        ProductId = SelectedProduct.Id,
                        Cost = Cost,
                        OrderStaus = orderStatus
                    };
                    db.Orders.Add(order);
                    db.SaveChanges();
                    MessageBox.Show("Заказ сохранен.");
                }
            });
        }

    }
}
