﻿using System;
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

namespace CurseWaterPool.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для AddBalanceP.xaml
    /// </summary>
    public partial class AddBalanceP : Page
    {
        users context;
        public AddBalanceP()
        {

            InitializeComponent();
            context = App.LoggedUser;
            DataContext = context;
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfileP());
        }
       
        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(SumTB.Text) <= 0)
                {
                    MessageBox.Show("Неверно введена сумма");
                    return;
                }
                context.balance += Convert.ToInt32(SumTB.Text);
                App.DB.SaveChanges();
                NavigationService.Navigate(new ProfileP());
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }
    }
}
