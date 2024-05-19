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
    /// Логика взаимодействия для PoolListP.xaml
    /// </summary>
    public partial class PoolListP : Page
    {
        public PoolListP()
        {
            InitializeComponent();
            PoolDG.ItemsSource = App.DB.pool.ToList();
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminP());
        }

        private void LessonListBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LessonListP());

        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedPool = PoolDG.SelectedItem as pool;

            if (selectedPool != null)
            {
                NavigationService.Navigate(new AddLessonP(selectedPool));

            }
            else MessageBox.Show("Выберите что-то");
        }

        private void AboutBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedPool = PoolDG.SelectedItem as pool;

            if (selectedPool != null)
            {
                MessageBox.Show("Номер бассейна: " + selectedPool.id + "\nГлубина: " + selectedPool.deth + "\nШирина: " + selectedPool.width + "\nВысота: " + selectedPool.height);
            }
            else MessageBox.Show("Выберите что-то");
        }
    }
}
