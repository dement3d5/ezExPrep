using ezExPrep.VM;
using ezExPrep.Windows;
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
    /// Логика взаимодействия для AdminOrderList.xaml
    /// </summary>
    public partial class AdminOrderList : Page
    {
        public AdminOrderList()
        {
            InitializeComponent();
            DataContext = new AdminVM();
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AdminVM adminVM)
            {
                adminVM.RefreshOrders();

            }

        }


    }
}
