using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
            rectangleItem1.Visibility = Visibility.Visible;
        }
        int ticketId = 0;

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
            if (item1Grid.Visibility == Visibility.Hidden)
            {
                if (stateComboBox.SelectedItem != null ||
                passportBox.SelectedItem != null ||
                textbox1.Text != "" ||
                textbox2.Text != "" ||
                textbox3.Text != "" ||
                textboxLastname.Text != "" ||
                textboxFirstname.Text != "" ||
                textboxMiddlename.Text != "" ||
                dateBirthdayPicker.SelectedDate != null ||
                comboboxGender.SelectedItem != null)
                {
                    if (MessageBox.Show("Некоторые поля заполнены, вы действительно хотите переключиться?",
                "Сообщение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        item1Grid.Visibility = Visibility.Visible;
                        Item1GridPersonal.Visibility = Visibility.Hidden;
                        rectangleItem2.Visibility = Visibility.Visible;
                        nameItemLabel.Content = "Бронирование авиабилетов";
                        item1ResultGrid.Visibility = Visibility.Hidden;
                        if (rectangleItem2.Visibility == Visibility.Visible ||
                            rectangleItem3.Visibility == Visibility.Visible)
                        {
                            rectangleItem2.Visibility = Visibility.Hidden;
                            rectangleItem3.Visibility = Visibility.Hidden;

                            panelItem3.Visibility = Visibility.Hidden;
                        }
                        ticketId = 0;
                    }
                }
                else
                {
                    if (rectangleItem2.Visibility == Visibility.Visible ||
                        rectangleItem3.Visibility == Visibility.Visible)
                    {
                        rectangleItem2.Visibility = Visibility.Hidden;
                        rectangleItem3.Visibility = Visibility.Hidden;

                        panelItem3.Visibility = Visibility.Hidden;
                    }
                }
            }
            else
            {
                if (rectangleItem2.Visibility == Visibility.Visible ||
                    rectangleItem3.Visibility == Visibility.Visible)
                {
                    rectangleItem2.Visibility = Visibility.Hidden;
                    rectangleItem3.Visibility = Visibility.Hidden;

                    panelItem3.Visibility = Visibility.Hidden;
                }
                if (item1ResultGrid.Visibility == Visibility.Visible)
                {
                    item1ResultGrid.Visibility = Visibility.Hidden;
                }
                rectangleItem1.Visibility = Visibility.Visible;
                nameItemLabel.Content = "Бронирование авиабилетов";
            }
        }

        // Клик на 2-й итем
        private void item2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(item1Grid.Visibility == Visibility.Hidden)
            {
                if (stateComboBox.SelectedItem != null ||
                passportBox.SelectedItem != null ||
                textbox1.Text != "" ||
                textbox2.Text != "" ||
                textbox3.Text != "" ||
                textboxLastname.Text != "" ||
                textboxFirstname.Text != "" ||
                textboxMiddlename.Text != "" ||
                dateBirthdayPicker.SelectedDate != null ||
                comboboxGender.SelectedItem != null)
                {
                    if (MessageBox.Show("Некоторые поля заполнены, вы действительно хотите переключиться?",
                "Сообщение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        item1Grid.Visibility = Visibility.Visible;
                        Item1GridPersonal.Visibility = Visibility.Hidden;
                        rectangleItem2.Visibility = Visibility.Visible;
                        nameItemLabel.Content = "Продажа авиабилетов";
                        item1ResultGrid.Visibility = Visibility.Hidden;
                        if (rectangleItem1.Visibility == Visibility.Visible ||
                        rectangleItem3.Visibility == Visibility.Visible)
                        {
                            rectangleItem1.Visibility = Visibility.Hidden;
                            rectangleItem3.Visibility = Visibility.Hidden;
                            TicketGrid.Visibility = Visibility.Hidden;

                            panelItem3.Visibility = Visibility.Hidden;
                        }
                        ticketId = 0;
                    }
                }
                else
                {
                    if (rectangleItem1.Visibility == Visibility.Visible ||
                        rectangleItem3.Visibility == Visibility.Visible)
                    {
                        rectangleItem1.Visibility = Visibility.Hidden;
                        rectangleItem3.Visibility = Visibility.Hidden;
                        TicketGrid.Visibility = Visibility.Hidden;

                        panelItem3.Visibility = Visibility.Hidden;
                    }
                }
            }
            else
            {
                if (rectangleItem1.Visibility == Visibility.Visible ||
                        rectangleItem3.Visibility == Visibility.Visible)
                {
                    rectangleItem1.Visibility = Visibility.Hidden;
                    rectangleItem3.Visibility = Visibility.Hidden;

                    panelItem3.Visibility = Visibility.Hidden;
                }
                if (item1ResultGrid.Visibility == Visibility.Visible)
                {
                    item1ResultGrid.Visibility = Visibility.Hidden;
                }
                rectangleItem2.Visibility = Visibility.Visible;
                TicketGrid.Visibility = Visibility.Hidden;
                nameItemLabel.Content = "Продажа авиабилетов";
            }
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
                        item1NextBtn.IsEnabled = false;
                    }
                    else
                    {
                        item1ResultGrid.Visibility = Visibility.Visible;
                        ticketNoneLabel.Visibility = Visibility.Hidden;
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
            if(ticketId == 0)
            {
                MessageBox.Show("Выберите билет!");
            }
            else
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

            if(rectangleItem2.Visibility == Visibility.Visible)
            {
                BuyBtn.Content = "Перейти к оплате";
            }
            else
            {
                BuyBtn.Content = "Забронировать";
            }
        }
        
        // Кнопка "Забронировать"
        private void BuyBtn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                // Если мы покупаем билет
                if(BuyBtn.Content.ToString() == "Перейти к оплате")
                {
                    // Вытащим с БД выбранный рейс
                    var dateFrom = dataEntities.Flights.Where(w => w.id == ticketId).Select(s => s.deptime).FirstOrDefault();
                    var dateTo = dataEntities.Flights.Where(w => w.id == ticketId).Select(s => s.destime).FirstOrDefault();
                    var cost = dataEntities.Flights.Where(w => w.id == ticketId).Select(s => s.ticketprice).FirstOrDefault();

                    var airlineId = dataEntities.Flights.Where(w => w.id == ticketId).Select(s => s.airline).FirstOrDefault();
                    var airline = dataEntities.Airlines.Where(w => w.id == airlineId).Select(s => s.name).FirstOrDefault();

                    var typeAircraftId = dataEntities.Flights.Where(w => w.id == ticketId).Select(s => s.typeaircraft).FirstOrDefault();
                    var typeAircraft = dataEntities.Aircraft.Where(w => w.id == typeAircraftId).Select(s => s.name).FirstOrDefault();

                    TicketGrid.Visibility = Visibility.Visible;
                    Item1GridPersonal.Visibility = Visibility.Hidden;
                    // Заполним форму билета
                    idLabel.Content = "Код билета: " + ticketId;
                    fromLabel.Content = "От: " + item1DepCombo.Text;
                    toLabel.Content = "До: " + item1DesCombo.Text;
                    DateFromLabel.Content = "Время отправления: " + dateFrom;
                    DateToLabel.Content = "Время прибытия: " + dateTo;
                    AirlineLabel.Content = "Авиакомпания: " + airline;
                    typeLabel.Content = "Тип самолета: " + typeAircraft;
                    passLabel.Content = "Пассажир: " + textboxLastname.Text + " " + textboxFirstname.Text + " " + textboxMiddlename.Text;
                    CostLabel.Content = "Стоимость: " + cost;
                    DateBuy.Content = "Дата покупки: " + DateTime.Now.ToString();

                    PrintBtn.Visibility = Visibility.Hidden;
                }
                // Если бронируем
                else
                {
                    int getSerialPassport = Convert.ToInt32(textbox2.Text);
                    var getPassenger = dataEntities.Passengers.Where(x => x.passport == getSerialPassport).FirstOrDefault();
                    if (getPassenger != null)
                    {
                        MessageBox.Show("Пассажир с такими данными паспорта уже есть в базе!");
                    }
                    else
                    {
                        int gender = 1;
                        int state = 1;
                        if (comboboxGender.Text == "женский")
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
                            passport = getSerialPassport
                        };
                        dataEntities.Passengers.Add(passenger);
                        dataEntities.SaveChanges();

                        MessageBox.Show(
                            "Билет успешно забронирован!",
                            "Информация",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }

                    int getIdEmploye = dataEntities.Employees.Where(w => w.login == App.My.username).Select(s => s.id).FirstOrDefault();
                    // Далее после внесения пассажира бронируем билет
                    Tickets ticket = new Tickets
                    {
                        firstname = textboxFirstname.Text,
                        lastname = textboxLastname.Text,
                        middlename = textboxMiddlename.Text,
                        employee = getIdEmploye,
                        flight = ticketId,
                        date = DateTime.Now
                    };
                    dataEntities.Tickets.Add(ticket);
                    dataEntities.SaveChanges();
                }
            }
        }

        // Получим номер выбранного билета
        private void item1ResultGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = item1ResultGrid.SelectedItem;
            ticketId = Convert.ToInt32(item.GetType().GetProperty("Номер").GetValue(item, null));
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        // Кнопка "Оплатить"
        private void BuyTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            int getSerialPassport = Convert.ToInt32(textbox2.Text);
            var getPassenger = dataEntities.Passengers.Where(x => x.passport == getSerialPassport).FirstOrDefault();
            if (getPassenger != null)
            {
                MessageBox.Show("Пассажир с такими данными паспорта уже есть в базе!");
            }
            else
            {
                int gender = 1;
                int state = 1;
                if (comboboxGender.Text == "женский")
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
                    passport = getSerialPassport
                };
                dataEntities.Passengers.Add(passenger);
                dataEntities.SaveChanges();

                MessageBox.Show(
                    "Билет приобретён!",
                    "Информация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            PrintBtn.Visibility = Visibility.Visible;
        }

        // Кнопка "Скачать в pdf"
        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
