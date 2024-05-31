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

namespace ezExPrep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = txt_login.Text;
            string password = txt_password.Text;

            User user = GetUser(login, password);

            if (user != null)
            {
                string userRole = GetUserRole(user.RoleId);

                switch (userRole)
                {
                    case "admin":
                        OpenAdminWindow();
                        break;
                    case "chef":
                        OpenChefWindow(user.Id);
                        break;
                    case "waiter":
                        OpenWaiterWindow();
                        break;
                    default:
                        MessageBox.Show("Неправильная роль пользователя.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль.");
            }

        }
        private User GetUser(string login, string password)
        {
            using (var context = new user2Context()) 
            {
                return context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            }
        }

        private string GetUserRole(int? roleId)
        {
            using (var context = new user2Context()) 
            {
                Role role = context.Roles.FirstOrDefault(r => r.Id == roleId);
                return role?.Title;
            }
        }

        private void OpenAdminWindow()
        {
            AdminWin adminWindow = new AdminWin();
            adminWindow.Show();
            this.Close();
        }

        private void OpenChefWindow(int chefId)
        {

            ChefWin chefWindow = new ChefWin();
            chefWindow.Show();
            this.Close();
        }

        private void OpenWaiterWindow()
        {

            WaiterWin waiterWindow = new WaiterWin();
            waiterWindow.Show();
            this.Close();
        }

        private void txt_login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
