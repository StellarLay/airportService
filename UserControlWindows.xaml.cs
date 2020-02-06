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
            //MessageBox.Show(window.ToString());
        }
    }
}
