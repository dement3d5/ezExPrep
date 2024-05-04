using ezExPrep.Tools;
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
    /// Логика взаимодействия для ListUsersPage.xaml
    /// </summary>
    public partial class ListUsersPage : Page
    {
        public ListUsersPage()
        {
            InitializeComponent();
            DataContext = new AdminVM();
        }

        private void Fired_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AdminVM adminVM && adminVM.ListUser != null)
            {
                adminVM.UpdateUserStatus(adminVM.ListUser, 5);
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is AdminVM adminVM)
            {
                adminVM.RefreshUsers();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddUserWin addUserWin = new AddUserWin();
            addUserWin.Show();
        }

       
    }
}
