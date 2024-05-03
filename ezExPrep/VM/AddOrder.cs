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
            using (var context = new user2Context())
            {
                Products = context.Products.ToList();
            }

            ADD = new CommandVM(() =>
            {
                using (var context = new user2Context())
                {
                    var orderStatus = context.OrderStatuses.FirstOrDefault(s => s.Id == 4); // Получаем статус "Принят"

                    var order = new Order
                    {
                        ProductId = SelectedProduct.Id,
                        Cost = Cost,
                        OrderStaus = orderStatus
                    };

                    context.Orders.Add(order);
                    context.SaveChanges();
                    MessageBox.Show("Заказ сохранен.");
                }
            });
        }

    }
}
