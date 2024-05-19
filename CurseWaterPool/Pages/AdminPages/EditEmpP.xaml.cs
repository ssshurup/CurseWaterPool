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
    /// Логика взаимодействия для EditEmpP.xaml
    /// </summary>
    public partial class EditEmpP : Page
    {
        employee context;
        public EditEmpP(employee editedEmp)
        {
            InitializeComponent();
            PostCB.ItemsSource = App.DB.post.ToList();
            context = editedEmp;
            DataContext = context ;
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeeP());
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            if( context == null)
            {
                App.DB.employee.Add(context);
            }
            App.DB.SaveChanges();
            NavigationService.Navigate(new EmployeeP());
        }
    }
}
