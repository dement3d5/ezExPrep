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

namespace ezExPrep.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrderWaiterWindow.xaml
    /// </summary>
    public partial class AddOrderWaiterWindow : Window
    {
        public AddOrderWaiterWindow()
        {
            InitializeComponent();
            DataContext = new AddOrder();
        }
    }
}
