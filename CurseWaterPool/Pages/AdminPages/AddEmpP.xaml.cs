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
    /// Логика взаимодействия для AddEmpP.xaml
    /// </summary>
    public partial class AddEmpP : Page
    {
        employee context;
        public AddEmpP()
        {
            InitializeComponent();
            PostCB.ItemsSource = App.DB.post.ToList();
            context = new employee();
            DataContext = context;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.DB.employee.Add(context);
                App.DB.SaveChanges();
                NavigationService.Navigate(new EmployeeP());
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeP());
        }
    }
}
