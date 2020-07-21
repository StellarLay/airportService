using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        AirportServiceEntities dataEntities = new AirportServiceEntities();

        public ManagerWindow()
        {
            InitializeComponent();

            welcomeText.Content = "Приветствуем, " + App.My.username;

            // Загрузим селект боксы
            var query = from cities in dataEntities.City
                        select new { cities.name };
            item1DepCombo.ItemsSource = query.ToList();
            item1DepCombo.DisplayMemberPath = "name";
            item1DepCombo.SelectedIndex = 0;
            item1DesCombo.ItemsSource = query.ToList();
            item1DesCombo.DisplayMemberPath = "name";
            item1DesCombo.SelectedIndex = 0;

            // Спрячем элементы некоторые или покажем
            item1ticketLabel.Visibility = Visibility.Hidden;
            numTicketBox.Visibility = Visibility.Hidden;
            rectangleItem1.Visibility = Visibility.Visible;
        }

        // При фокусе на 1-й итем
        private void item1_MouseEnter(object sender, MouseEventArgs e)
        {
            item1.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF70FE2"));
            itemImg1.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF70FE2"));
        }

        // При потере фокуса с 1-го итема
        private void item1_MouseLeave(object sender, MouseEventArgs e)
        {
            item1.Foreground = Brushes.White;
            itemImg1.Foreground = Brushes.White;
        }
        
        // Фокус 2-й итем
        private void item2_MouseEnter(object sender, MouseEventArgs e)
        {
            item2.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF70FE2"));
            itemImg2.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF70FE2"));
        }

        // Потеря фокуса 2-й итем
        private void item2_MouseLeave(object sender, MouseEventArgs e)
        {
            item2.Foreground = Brushes.White;
            itemImg2.Foreground = Brushes.White;
        }

        // Фокус 3-й итем
        private void item3_MouseEnter(object sender, MouseEventArgs e)
        {
            item3.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF70FE2"));
            itemImg3.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF70FE2"));
        }

        // Потеря фокуса 3-й итем
        private void item3_MouseLeave(object sender, MouseEventArgs e)
        {
            item3.Foreground = Brushes.White;
            itemImg3.Foreground = Brushes.White;
        }

        // Клик на 1-й итем
        private void item1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Hover effect
            if (rectangleItem2.Visibility == Visibility.Visible ||
                rectangleItem3.Visibility == Visibility.Visible)
            {
                rectangleItem2.Visibility = Visibility.Hidden;
                rectangleItem3.Visibility = Visibility.Hidden;

                panelItem2.Visibility = Visibility.Hidden;
                panelItem3.Visibility = Visibility.Hidden;
            }
            rectangleItem1.Visibility = Visibility.Visible;
            nameItemLabel.Content = "Бронирование авиабилетов";
        }

        // Клик на 2-й итем
        private void item2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Hover effect
            if (rectangleItem1.Visibility == Visibility.Visible || 
                rectangleItem3.Visibility == Visibility.Visible)
            {
                rectangleItem1.Visibility = Visibility.Hidden;
                rectangleItem3.Visibility = Visibility.Hidden;

                panelItem3.Visibility = Visibility.Hidden;
            }
            rectangleItem2.Visibility = Visibility.Visible;
            panelItem2.Visibility = Visibility.Visible;
            nameItemLabel.Content = "Продажа авиабилетов";
        }

        // Клик на 3-й итем
        private void item3_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Hover effect
            if (rectangleItem1.Visibility == Visibility.Visible ||
                rectangleItem2.Visibility == Visibility.Visible)
            {
                rectangleItem1.Visibility = Visibility.Hidden;
                rectangleItem2.Visibility = Visibility.Hidden;

                panelItem2.Visibility = Visibility.Hidden;
            }
            rectangleItem3.Visibility = Visibility.Visible;
            panelItem3.Visibility = Visibility.Visible;
            nameItemLabel.Content = "Список пассажиров";
        }

        // Клик на кнопку "Найти билеты"
        private void item1SearchTicket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Если всё заполнили
                if (item1DepCombo.SelectedItem != null && item1DesCombo != null && item1DatePicker.SelectedDate != null)
                {
                    // DataGrid loading
                    var date = new DateTime(item1DatePicker.SelectedDate.Value.Ticks, DateTimeKind.Unspecified).Date;
                    var query = from routes in dataEntities.Flights
                                where routes.departure == item1DepCombo.Text &&
                                routes.destination == item1DesCombo.Text &&
                                routes.date == date
                                select new
                                {
                                    Номер = routes.id,
                                    Дата = routes.date.Day + "." + routes.date.Month + "." + routes.date.Year,
                                    Отправление = routes.deptime.ToString(),
                                    Прибытие = routes.destime.ToString(),
                                    Авиакомпания = routes.airline,
                                    Цена = routes.ticketprice
                                };
                    item1ResultGrid.ItemsSource = query.ToList();
                    
                    // Если билеты не найдены
                    if(item1ResultGrid.Items.Count == 0)
                    {
                        ticketNoneLabel.Visibility = Visibility.Visible;
                        item1ResultGrid.Visibility = Visibility.Hidden;
                        item1ticketLabel.Visibility = Visibility.Hidden;
                        numTicketBox.Visibility = Visibility.Hidden;
                        item1NextBtn.IsEnabled = false;
                    }
                    else
                    {
                        item1ResultGrid.Visibility = Visibility.Visible;
                        ticketNoneLabel.Visibility = Visibility.Hidden;
                        item1ticketLabel.Visibility = Visibility.Visible;
                        numTicketBox.Visibility = Visibility.Visible;
                        item1NextBtn.IsEnabled = true;
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Заполните все необходимые поля!",
                        "Информация",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Убираем placeholder когда выбрали дату
        private void item1DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            selectDateLabel.Visibility = Visibility.Hidden;
        }

        // Кнопка "Далее"
        private void item1NextBtn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Загрузим селект бокс "Гражданство"
            var query = from states in dataEntities.States
                        select new { states.name };
            stateComboBox.ItemsSource = query.ToList();
            stateComboBox.DisplayMemberPath = "name";
            stateComboBox.SelectedIndex = 0;

            Item1GridPersonal.Visibility = Visibility.Visible;
            item1Grid.Visibility = Visibility.Hidden;
        }

        // Кнопка "Забронировать"
        private void BuyBtn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Если хоть какое то поле не заполнено, то не бронировать
                if (stateComboBox.SelectedItem == null ||
                    passportBox.SelectedItem == null ||
                    textbox1.Text == "" ||
                    textbox2.Text == "" ||
                    textbox3.Text == "" ||
                    textboxLastname.Text == "" ||
                    textboxFirstname.Text == "" ||
                    textboxMiddlename.Text == "" ||
                    dateBirthdayPicker.SelectedDate == null ||
                    comboboxGender.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Заполните все необходимые поля!",
                        "Информация",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else
                {
                    int gender = 1;
                    int state = 1;
                    if(comboboxGender.Text == "женский")
                    {
                        gender = 2;
                    }
                    switch (stateComboBox.Text)
                    {
                        case "Российская федерация":
                            state = 1;
                            break;
                        case "Американское гражданство":
                            state = 2;
                            break;
                        case "Римское гражданство":
                            state = 3;
                            break;
                    }

                    // Внесём пассажира в соответствующую таблицу в БД
                    Passengers passenger = new Passengers
                    {
                        firstname = textboxFirstname.Text,
                        lastname = textboxLastname.Text,
                        middlename = textboxMiddlename.Text,
                        gender = gender,
                        datebirthday = dateBirthdayPicker.DisplayDate,
                        state = state,
                        passport = Convert.ToInt32(textbox2.Text) + Convert.ToInt32(textbox3.Text)
                    };
                    dataEntities.Passengers.Add(passenger);
                    dataEntities.SaveChanges();

                    MessageBox.Show(
                        "Билет успешно забронирован!",
                        "Информация",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
