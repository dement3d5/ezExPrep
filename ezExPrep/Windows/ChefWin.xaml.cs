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
using System.Windows.Shapes;

namespace ezExPrep
{
    /// <summary>
    /// Логика взаимодействия для ChefWin.xaml
    /// </summary>
    public partial class ChefWin : Window
    {
        public ChefWin()
        {
            InitializeComponent();
            DataContext = new ChefVM();
        }

        private void Gotovitsa_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ChefVM chefVM && chefVM.ListOrder != null)
            {
                chefVM.UpdateOrderStatus(chefVM.ListOrder, "Готовиться", 3);
            }
        }

        private void Gotov_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ChefVM chefVM && chefVM.ListOrder != null)
            {
                chefVM.UpdateOrderStatus(chefVM.ListOrder, "Готов", 4);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ChefVM chefVM)
            {
                chefVM.RefreshOrders();

            }
        }

      
    }
}
