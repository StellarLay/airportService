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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // placeholder button
        private void loginBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            if(loginText.Text == "Имя пользователя")
            {
                loginText.Text = "";
            }
        }

        // placeholder button
        private void loginText_MouseLeave(object sender, MouseEventArgs e)
        {
            if (loginText.Text == "")
            {
                loginText.Text = "Имя пользователя";
            }
        }

        // placeholder button
        private void passText_MouseEnter(object sender, MouseEventArgs e)
        {
            if (passText.Text == "Пароль")
            {
                passText.Text = "";
            }
        }

        // placeholder button
        private void passText_MouseLeave(object sender, MouseEventArgs e)
        {
            if (passText.Text == "")
            {
                passText.Text = "Пароль";
            }
        }

        // перетаскивание окна зажатием ЛКМ
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        // клик по тексту "Нет аккаунта? Зарегистрируйтесь"
        private void TextBlock_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Registration form = new Registration();
            form.Show();
            this.Hide();
        }
    }
}
