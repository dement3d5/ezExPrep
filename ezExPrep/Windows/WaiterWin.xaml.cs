﻿using ezExPrep.Tools;
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
using System.Windows.Shapes;

namespace ezExPrep
{
    /// <summary>
    /// Логика взаимодействия для WaiterWin.xaml
    /// </summary>
    public partial class WaiterWin : Window
    {
        public WaiterWin()
        {
            InitializeComponent();
            DataContext = new MainVM();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWaiterWindow aoww = new AddOrderWaiterWindow();
            aoww.Show();
        }
    }
}
