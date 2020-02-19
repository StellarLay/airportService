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

namespace AirportService
{
    /// <summary>
    /// Логика взаимодействия для maximizeWindow.xaml
    /// </summary>
    public partial class maximizeWindow : UserControl
    {
        public maximizeWindow()
        {
            InitializeComponent();
        }

        // Нажатие на крестик для выхода из app
        private void exitBtn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?",
                "Сообщение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                // закрываем текущую форму и всё app
                Application.Current.Shutdown();
            }
        }

        // Кнопка "Свернуть"
        private void minBtn_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Получаем текущее активное окно, а затем при клике скрываем его
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            window.WindowState = WindowState.Minimized;
        }

        // Кнопка "Развернуть"
        private void Label_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rect rec = SystemParameters.WorkArea;
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            window.Width = rec.Size.Width;
            window.Height = rec.Size.Height;
            window.Top = rec.Top;
            window.Left = rec.Left;

            returnMinimizeBtn.Visibility = Visibility.Visible;
            maximizeBtn.Visibility = Visibility.Hidden;
        }

        // Кнопка "Свернуть обратно после разворачивания"
        private void returnMinimizeBtn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            window.Width = 1000;
            window.Height = 600;

            // Делаем программно окно по центру
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = window.Width;
            double windowHeight = window.Height;
            window.Left = (screenWidth / 2) - (windowWidth / 2);
            window.Top = (screenHeight / 2) - (windowHeight / 2);

            returnMinimizeBtn.Visibility = Visibility.Hidden;
            maximizeBtn.Visibility = Visibility.Visible;
        }
    }
}
