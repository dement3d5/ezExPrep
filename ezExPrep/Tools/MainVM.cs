using ezExPrep.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ezExPrep.Tools
{
    public class MainVM : BaseVM
    {

        public Page currentPage;
        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                Signal();
            }
        }

        public CommandVM OrdersPage { get; set; }
        public CommandVM UsersPage { get; set; }  

        public MainVM() 
        {
            OrdersPage = new CommandVM(() =>
            {
                CurrentPage = new ListOrdersWaiterPage();

            });
            UsersPage = new CommandVM(() =>
            {
                CurrentPage = new ListOrdersWaiterPage();

            });




        }

    }
}
