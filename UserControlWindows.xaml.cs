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
    /// Логика взаимодействия для UserControlWindows.xaml
    /// </summary>
    public partial class UserControlWindows : UserControl
    {
        public UserControlWindows()
        {
            InitializeComponent();
        }

        // Нажатие на крестик для выхода из app
        private void exitBtn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите выйти?",
                "Сообщение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                Window.GetWindow(this).Close();
            }
        }
        // Кнопка "Свернуть"
        private void minBtn_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
