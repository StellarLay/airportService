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
using System.Windows.Shapes;

namespace AirportService
{
    /// <summary>
    /// Логика взаимодействия для SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        // Установка таймера Fade in
        System.Windows.Threading.DispatcherTimer timer1 = new System.Windows.Threading.DispatcherTimer();

        // Установка таймера Fade out
        System.Windows.Threading.DispatcherTimer timer2 = new System.Windows.Threading.DispatcherTimer();

        public SplashScreen()
        {
            InitializeComponent();

            timerStart();
            this.Opacity = 0.0;
            timer1.Start();

            usernameLabel.Content = App.My.username;
        }

        // Метод таймера
        private void timerStart()
        {
            timer1.Tick += new EventHandler(timerTick1);
            //timer1.Interval = new TimeSpan(0, 0, 1);
            timer1.Interval = TimeSpan.FromMilliseconds(1);
            timer1.Start();

            timer2.Tick += new EventHandler(timerTick2);
            timer2.Interval = TimeSpan.FromMilliseconds(1);
        }

        // Событие таймера 1
        private void timerTick1(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.05;
            }
            progressBar.Value += 0.5;
            if (progressBar.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        // Событие таймера 2
        private void timerTick2(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity < 0.1)
            {
                timer2.Stop();
                this.Close();

                // Открываем форму
                ManagerWindow form = new ManagerWindow();
                form.Show();
            }
        }
    }
}
