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

namespace CurseWaterPool.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для GiveSubP.xaml
    /// </summary>
    public partial class GiveSubP : Page
    {
        users context = new users();
        subscription sub;
        public GiveSubP(subscription giveSub)
        {
            InitializeComponent();
            DataContext = context;
            sub = giveSub;
        }
        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SubscriptionP());
        }

        private void GiveBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedUser = App.DB.users.Where(a => a.phone == PhoneTB.Text);
                if(selectedUser != null)
                {
                    hystory operation = new hystory();
                    operation.idUser = context.id;
                    operation.idSubscription = sub.id;
                    operation.dateActivation = DateTime.Now;
                    operation.dateValidity = DateTime.Now.AddMonths(1);
                    App.DB.hystory.Add(operation);
                    App.DB.SaveChanges();
                    MessageBox.Show("Успешно");
                    NavigationService.Navigate(new SubscriptionP());
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                context = App.DB.users.Where(a => a.phone.Contains(PhoneTB.Text)).First();
                DataContext = context;
            }
            catch
            {
                DataContext = null;
            }
            
        }
    }
}
