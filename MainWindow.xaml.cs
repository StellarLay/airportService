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
using System.Data.Entity;

namespace AirportService
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Установка таймера
        System.Windows.Threading.DispatcherTimer timer1 = new System.Windows.Threading.DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            // Заранее подгрузка БД
            var initializer = new CreateDatabaseIfNotExists<DbContext>();
            using (var context = new Models.DbTestContext())
            {
                initializer.InitializeDatabase(context);
            }
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

        // Клик по кнопке Авторизоваться
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {

            // Если поля пустые то выдать ошибку
            if(loginText.Text == "Имя пользователя" && passText.Text == "Пароль")
            {
                errorLabel.Content = "Заполните поля";
            }

            // Иначе проверяем на совпадение в БД
            else
            {
                using (var context = new Models.DbTestContext())
                {
                    var user = context.Users;

                    string login = loginText.Text;
                    string pass = passText.Text;

                    // Глобальный класс в App.xaml
                    // Передаем туда имя юзера, чтобы отобразить на сплеш скрине
                    App.My.username = loginText.Text;

                    // Проводим авторизацию
                    var getLogin = user.FirstOrDefault(p => p.username == login && p.password == pass);
                    if (getLogin == null)
                    {
                        errorLabel.Content = "Неверный логин или пароль";
                        errorImg.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        loginBtn.Visibility = Visibility.Hidden;
                        loadingBar.Visibility = Visibility.Visible;

                        // Параметры таймера
                        timer1.Tick += new EventHandler(timerTick);
                        timer1.Interval = TimeSpan.FromMilliseconds(1);
                        timer1.Start();
                    }
                }
            }
        }

        // Загрузка прогресс бара при авторизации
        private void timerTick(object sender, EventArgs e)
        {
            loadingBar.Value++;
            if(loadingBar.Value == 100)
            {
                loadingBar.Visibility = Visibility.Hidden;
                loginBtn.Visibility = Visibility.Visible;

                this.Hide();

                // Открываем сплеш-скрин
                SplashScreen form = new SplashScreen();
                form.Show();
                timer1.Stop();
            }
        }
    }
}
