using CurseWaterPool.Pages.AdminPages;
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
    /// Логика взаимодействия для BuySubP.xaml
    /// </summary>
    public partial class BuySubP : Page
    {
        users context;
        public BuySubP()
        {
            InitializeComponent();
            SubscrDG.ItemsSource = App.DB.subscription.ToList();
            SortCB.ItemsSource = App.DB.typePool.ToList();
            context = App.LoggedUser;
            DataContext = context;
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserP());
        }

        private void BuyBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedSub = SubscrDG.SelectedItem as subscription;
                var selectedUser = context;
                if (selectedUser.balance >= selectedSub.cost)
                {
                    if (selectedUser != null)
                    {
                        hystory operation = new hystory();
                        operation.idUser = selectedUser.id;
                        operation.idSubscription = selectedSub.id;
                        operation.dateActivation = DateTime.Now;
                        operation.dateValidity = DateTime.Now.AddMonths(1);
                        context.balance -= selectedSub.cost;
                        App.DB.hystory.Add(operation);
                        App.DB.SaveChanges();
                        MessageBox.Show("Успешно");
                        NavigationService.Navigate(new UserP());
                    }
                }
                else MessageBox.Show("Недостаточно средств");
               
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void AboutBT_Click(object sender, RoutedEventArgs e)
        {
            string isTr = "";
            var selectedSub = SubscrDG.SelectedItem as subscription;
            if (selectedSub.isTrainer == true)
            {
                isTr = "Да";
            }
            else isTr = "Нет";
            if (selectedSub != null)
            {
                MessageBox.Show("Тип: " + selectedSub.typePool.name + "\nЦена: " + selectedSub.cost + "\nИмя: " + selectedSub.name + "\nОписание: " + selectedSub.description + "\nПоддержка тренера: " + isTr);
            }
            else MessageBox.Show("Выберите что-то");
        }
        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedType = SortCB.SelectedItem as typePool;
            SubscrDG.ItemsSource = App.DB.subscription.Where(a => a.typePool.id == selectedType.id).ToList();

        }
        private void ClearBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BuySubP());
        }
    }
}
