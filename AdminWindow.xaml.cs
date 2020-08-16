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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        AirportServiceEntities dataEntities = new AirportServiceEntities();

        public AdminWindow()
        {
            InitializeComponent();

            item1.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFF70FE2"));
            itemImg1.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFF70FE2"));
            rectangleItem1.Visibility = Visibility.Visible;
        }

        // Фокус 1-й итем
        private void item1_MouseEnter(object sender, MouseEventArgs e)
        {
            item1.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFF70FE2"));
            itemImg1.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFF70FE2"));
        }

        // При потере фокуса с 1-го итема
        private void item1_MouseLeave(object sender, MouseEventArgs e)
        {
            item1.Foreground = System.Windows.Media.Brushes.White;
            itemImg1.Foreground = System.Windows.Media.Brushes.White;
        }

        // Фокус 2-й итем
        private void item2_MouseEnter(object sender, MouseEventArgs e)
        {
            item2.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFF70FE2"));
            itemImg2.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFF70FE2"));
        }

        // Потеря фокуса 2-й итем
        private void item2_MouseLeave(object sender, MouseEventArgs e)
        {
            item2.Foreground = System.Windows.Media.Brushes.White;
            itemImg2.Foreground = System.Windows.Media.Brushes.White;
        }

        string type = "";
        // Клик на 1-й итем
        private void item1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rectangleItem1.Visibility = Visibility.Visible;
            rectangleItem2.Visibility = Visibility.Hidden;
            BtnsStackPanel.Visibility = Visibility.Visible;
            StatisticOneGrid.Visibility = Visibility.Hidden;
            StatisticHeadLabel.Content = "";
            type = "";
            FromStatisticPicker.SelectedDate = null;
            ToStatisticPicker.SelectedDate = null;
            flightLabelStatistic.Text = "";
            EmployeesGrid.Visibility = Visibility.Hidden;
        }

        // Клик на 2-й итем
        private void item2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rectangleItem1.Visibility = Visibility.Hidden;
            rectangleItem2.Visibility = Visibility.Visible;
            BtnsStackPanel.Visibility = Visibility.Hidden;
            EmployeesGrid.Visibility = Visibility.Visible;
            StatisticHeadLabel.Content = "Сотрудники";

            // Loading grid
            var query = from users in dataEntities.Employees
                        join roles in dataEntities.Roles on users.roleId equals roles.Id
                        select new
                        {
                            Номер = users.id,
                            Фамилия = users.lastname,
                            Имя = users.firstname,
                            Должность = roles.name,
                            Логин = users.login,
                            Пароль = users.password
                        };
            EmployeesDataGrid.ItemsSource = query.ToList();
        }

        // Клик на кнопку "Количество билетов по рейсам"
        private void StatisticOneBtn_Click(object sender, RoutedEventArgs e)
        {
            FlightLabelStatistic.Visibility = Visibility.Visible;
            flightLabelStatistic.Visibility = Visibility.Visible;
            BtnsStackPanel.Visibility = Visibility.Hidden;
            StatisticOneGrid.Visibility = Visibility.Visible;
            ResultStatisticLabel.Content = "";
            StatisticHeadLabel.Content = "Количество билетов по рейсам";
            type = "statisticOne";
        }

        // Иконка "Выход"
        private void itemExit_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?",
                "Сообщение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                MainWindow form = new MainWindow();
                this.Close();
                form.Show();
            }
        }

        // Кнопка "Применить"
        private void ApplyStatisticBtn_Click(object sender, RoutedEventArgs e)
        {
            if(flightLabelStatistic.Text == "" ||
                FromStatisticPicker.SelectedDate == null ||
                ToStatisticPicker.SelectedDate == null)
            {
                MessageBox.Show("Заполните фильтр!");
            }
            else
            {
                if(type == "statisticOne")
                {
                    int flightNumber = Convert.ToInt32(flightLabelStatistic.Text);
                    var startDate = new DateTime(FromStatisticPicker.SelectedDate.Value.Ticks, DateTimeKind.Unspecified).Date;
                    var endDate = new DateTime(ToStatisticPicker.SelectedDate.Value.Ticks, DateTimeKind.Unspecified).Date;
                    var item = dataEntities.Tickets.Where(w => w.flight == flightNumber && w.date > startDate && w.date < endDate);

                    ResultStatisticLabel.Content = "Количество проданных билетов на рейс " + flightNumber + " : " + item.Count();
                }
                else
                {
                    var startDate = new DateTime(FromStatisticPicker.SelectedDate.Value.Ticks, DateTimeKind.Unspecified).Date;
                    var endDate = new DateTime(ToStatisticPicker.SelectedDate.Value.Ticks, DateTimeKind.Unspecified).Date;
                    var item = dataEntities.Tickets.Where(w => w.date > startDate && w.date < endDate);

                    ResultStatisticLabel.Content = "проданных билетов на заданный период: " + item.Count();
                }
            }
        }

        // Количество проданных авиабилетов
        private void StatisticTwoBtn_Click(object sender, RoutedEventArgs e)
        {
            type = "statisticTwo";
            FlightLabelStatistic.Visibility = Visibility.Hidden;
            flightLabelStatistic.Visibility = Visibility.Hidden;

            BtnsStackPanel.Visibility = Visibility.Hidden;
            StatisticOneGrid.Visibility = Visibility.Visible;
            ResultStatisticLabel.Content = "";
            StatisticHeadLabel.Content = "Количество проданных авиабилетов";
        }

        int userId = 0;

        // Кнопка "Добавить сотрудника"
        private void AddEmployBtn_Click(object sender, RoutedEventArgs e)
        {
            Registration form = new Registration();
            form.Show();
        }

        // Кнопка "Удалить сотрудника"
        private void DeleteEmployBtn_Click(object sender, RoutedEventArgs e)
        {
            if(userId == 0)
            {
                MessageBox.Show("Выберите сотрудника!");
            }
            else
            {
                if (MessageBox.Show("Вы действительно хотите удалить этого сотрудника?",
                "Сообщение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    Employees employ = new Employees
                    {
                        id = userId
                    };

                    dataEntities.Employees.Attach(employ);
                    dataEntities.Employees.Remove(employ);
                    dataEntities.SaveChanges();

                    MessageBox.Show("Сотрудник успешно удалён");
                }
            }
        }

        private void EmployeesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = EmployeesDataGrid.SelectedItem;
            if(item == null)
            {
                EmployeesDataGrid.SelectedIndex = -1;
            }
            else
            {
                userId = Convert.ToInt32(item.GetType().GetProperty("Номер").GetValue(item, null));
            }
        }

        // Кнопка "Обновить"
        private void UpdateEmployBtn_Click(object sender, RoutedEventArgs e)
        {
            // Loading grid
            var query = from users in dataEntities.Employees
                        join roles in dataEntities.Roles on users.roleId equals roles.Id
                        select new
                        {
                            Номер = users.id,
                            Фамилия = users.lastname,
                            Имя = users.firstname,
                            Должность = roles.name,
                            Логин = users.login,
                            Пароль = users.password
                        };
            EmployeesDataGrid.ItemsSource = query.ToList();
        }
    }
}
