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
    /// Логика взаимодействия для LessonListP.xaml
    /// </summary>
    public partial class LessonListP : Page
    {
        public LessonListP()
        {
            InitializeComponent();
            LessonDG.ItemsSource = App.DB.lesson.ToList();
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PoolListP());
        }
        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedLesson = LessonDG.SelectedItem as lesson;
            if (selectedLesson != null)
            {
                App.DB.lesson.Remove(selectedLesson);
                App.DB.SaveChanges();
                LessonDG.ItemsSource = App.DB.lesson.ToList();
            }
            else MessageBox.Show("Выберите что-то");
        }
    }
}
