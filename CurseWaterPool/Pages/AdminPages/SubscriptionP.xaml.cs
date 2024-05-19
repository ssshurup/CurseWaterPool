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
    /// Логика взаимодействия для SubscriptionP.xaml
    /// </summary>
    public partial class SubscriptionP : Page
    {
        subscription context;
        public SubscriptionP()
        {
            InitializeComponent();
            SubscrDG.ItemsSource = App.DB.subscription.ToList();
            SortCB.ItemsSource = App.DB.typePool.ToList();
            context = new subscription();
            DataContext = context;
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminP());
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSubP());
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedType = SortCB.SelectedItem as typePool;
            SubscrDG.ItemsSource = App.DB.subscription.Where(a => a.typePool.id == selectedType.id).ToList();

        }
        private void ClearBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SubscriptionP());
        }


        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedSub = SubscrDG.SelectedItem as subscription;
            if (selectedSub != null)
            {
                NavigationService.Navigate(new EditSubP(selectedSub));
            }
            else MessageBox.Show("Выберите что-то");
        }

        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedSub = SubscrDG.SelectedItem as subscription;
            if (selectedSub != null)
            {
               App.DB.subscription.Remove(selectedSub);
               App.DB.SaveChanges();
               SubscrDG.ItemsSource = App.DB.subscription.ToList();
            }
            else MessageBox.Show("Выберите что-то");
        }

        private void AboutBT_Click(object sender, RoutedEventArgs e)
        {
            string isTr = "";
            var selectedSub = SubscrDG.SelectedItem as subscription;
            if (selectedSub.isTrainer == true)
            {
                isTr = "Да";
            } else isTr = "Нет";
            if (selectedSub != null)
            {
                MessageBox.Show("Тип: " + selectedSub.typePool.name + "\nЦена: " + selectedSub.cost + "\nИмя: " + selectedSub.name + "\nОписание: " + selectedSub.description + "\nПоддержка тренера: " + isTr);
            }
            else MessageBox.Show("Выберите что-то");
        }

       
        private void GiveSubBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedSub = SubscrDG.SelectedItem as subscription;
            if (selectedSub != null)
            {
                NavigationService.Navigate(new GiveSubP(selectedSub));
            }
            else MessageBox.Show("Выберите что-то");
        }
    }
}
