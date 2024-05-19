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

namespace CurseWaterPool.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для ProfileP.xaml
    /// </summary>
    public partial class ProfileP : Page
    {
        public ProfileP()
        {
            InitializeComponent();
            SubscrDG.ItemsSource = App.DB.hystory.Where(a => a.idUser == App.LoggedUser.id).ToList();
            BalanceTB.Text += App.LoggedUser.balance;
        }
        private void AboutBT_Click(object sender, RoutedEventArgs e)
        {
            string isTr = "";
            var selectedSub = SubscrDG.SelectedItem as hystory;
            if (selectedSub.subscription.isTrainer == true)
            {
                isTr = "Да";
            }
            else isTr = "Нет";
            if (selectedSub != null)
            {
                MessageBox.Show("Тип: " + selectedSub.subscription.typePool.name + "\nЦена: " + selectedSub.subscription.cost + "\nИмя: " + selectedSub.subscription.name + "\nОписание: " + selectedSub.subscription.description + "\nПоддержка тренера: " + isTr);
            }
            else MessageBox.Show("Выберите что-то");
        }

        private void AddBalance_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddBalanceP());
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserP());
        }
        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedSub = SubscrDG.SelectedItem as hystory;
            if (selectedSub != null)
            {
                App.DB.hystory.Remove(selectedSub);
                App.DB.SaveChanges();
                SubscrDG.ItemsSource = App.DB.hystory.Where(a => a.idUser == App.LoggedUser.id).ToList();
            }

            else MessageBox.Show("Выберите что-то");
        }
    }
}
