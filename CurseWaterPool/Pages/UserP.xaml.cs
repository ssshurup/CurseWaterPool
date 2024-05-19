using CurseWaterPool.Pages.UserPages;
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

namespace CurseWaterPool.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserP.xaml
    /// </summary>
    public partial class UserP : Page
    {
        public UserP()
        {
            InitializeComponent();
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());
        }

        private void SubBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BuySubP());
        }

        private void ProfileBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfileP());
        }
    }
}
