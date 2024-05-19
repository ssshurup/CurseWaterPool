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
    /// Логика взаимодействия для EmployeeP.xaml
    /// </summary>
    public partial class EmployeeP : Page
    {
        employee context;
        public EmployeeP()
        {
            InitializeComponent();
            EmployeeDG.ItemsSource = App.DB.employee.ToList();
            context = new employee();
            DataContext = context;
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminP());
        }

        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmp = EmployeeDG.SelectedItem as employee;
            if (selectedEmp != null)
            {
                App.DB.employee.Remove(selectedEmp);
                App.DB.SaveChanges();
                EmployeeDG.ItemsSource = App.DB.employee.ToList();
            }
            else MessageBox.Show("Выберите что-тo");
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmp = EmployeeDG.SelectedItem as employee;
            if (selectedEmp != null)
            {
            NavigationService.Navigate(new EditEmpP(selectedEmp));

            }
            else MessageBox.Show("Выберите что-тo");

        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmpP());
        }
    }
}
