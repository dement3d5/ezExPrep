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

        public MainVM() 
        {


        
        
        
        }

    }
}
