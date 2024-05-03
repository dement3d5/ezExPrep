using ezExPrep.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ezExPrep.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListOrdersWaiterPage.xaml
    /// </summary>
    public partial class ListOrdersWaiterPage : Page
    {
        public ListOrdersWaiterPage()
        {
            InitializeComponent();
            DataContext = new WaiterVM();
        }

       

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is WaiterVM waiterVM)
            {
                waiterVM.RefreshOrders();

            }

        }

        private void Sold_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is WaiterVM waiterVM && waiterVM.ListOrder != null)
            {
                waiterVM.UpdateOrderStatus(waiterVM.ListOrder, "Оплачен", 2);
            }

        }
    }
}
