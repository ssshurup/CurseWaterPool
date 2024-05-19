using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для AddLessonP.xaml
    /// </summary>
    public partial class AddLessonP : Page
    {
        employee lesEmp;
        pool lesPool;
        public AddLessonP(pool poolLes)
        {
            InitializeComponent();
            lesEmp = new employee();
            DataContext = lesPool;
            lesPool = poolLes;
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PoolListP());
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lesson addedLess = new lesson();
                addedLess.idTrainer = lesEmp.id;
                addedLess.idPool = lesPool.id;
                addedLess.dateLesson = DateLessonDP.SelectedDate;
                App.DB.lesson.Add(addedLess);
                App.DB.SaveChanges();
                NavigationService.Navigate(new LessonListP());
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void PhoneTB_TextChanged(object sender, TextChangedEventArgs e)
        {

            try
            {
                lesEmp = App.DB.employee.Where(a => a.phone.Contains(PhoneTB.Text)).First();
                DataContext = lesEmp;
            }
            catch
            {
                DataContext = null;
            }
        }

    }
}
