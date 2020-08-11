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
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.ComponentModel;
using System.Drawing;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Parsing;

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

        // Фокус 3-й итем
        private void item3_MouseEnter(object sender, MouseEventArgs e)
        {
            item3.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFF70FE2"));
            itemImg3.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFF70FE2"));
        }

        // Потеря фокуса 3-й итем
        private void item3_MouseLeave(object sender, MouseEventArgs e)
        {
            item3.Foreground = System.Windows.Media.Brushes.White;
            itemImg3.Foreground = System.Windows.Media.Brushes.White;
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
                    if (rectangleItem3.Visibility == Visibility.Hidden)
                    {
                        if (MessageBox.Show("Некоторые поля заполнены, вы действительно хотите переключиться?",
               "Сообщение",
               MessageBoxButton.YesNo,
               MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            item1Grid.Visibility = Visibility.Visible;
                            Item1GridPersonal.Visibility = Visibility.Hidden;
                            rectangleItem1.Visibility = Visibility.Visible;
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
                        item1Grid.Visibility = Visibility.Visible;
                        Item1GridPersonal.Visibility = Visibility.Hidden;
                        rectangleItem1.Visibility = Visibility.Visible;
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
                    if(rectangleItem3.Visibility == Visibility.Hidden)
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
            item1Grid.Visibility = Visibility.Hidden;
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
                    DateBuy.Content = "Дата покупки: " + DateTime.Now.ToString("MM/dd/yyyy");

                    PrintBtn.Visibility = Visibility.Hidden;
                }
                // Если бронируем
                else
                {
                    int getSerialPassport = Convert.ToInt32(textbox2.Text);
                    var getPassenger = dataEntities.Passengers.Where(x => x.passport == getSerialPassport).FirstOrDefault();
                    if (getPassenger == null)
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
                    }
                    else
                    {
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
            }
            else
            {
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

            PdfDocument document = new PdfDocument();

            document.PageSettings.Orientation = PdfPageOrientation.Landscape;
            document.PageSettings.Margins.All = 50;

            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 20);

            PdfImage image = PdfImage.FromFile(@"C:\VSProjects\AirportService\resources\logo.png");
            RectangleF bounds = new RectangleF(300, 0, 150, 130);
            page.Graphics.DrawImage(image, bounds);

            graphics.DrawString("Ticket " + ticketId, font, PdfBrushes.Black, new PointF(340, 0));

            PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
            bounds = new RectangleF(0, bounds.Bottom + 50, graphics.ClientSize.Width, 30);

            graphics.DrawRectangle(solidBrush, bounds);

            PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);

            PdfTextElement element = new PdfTextElement("Ticket information ", subHeadingFont);
            element.Brush = PdfBrushes.White;

            PdfLayoutResult result = element.Draw(page, new PointF(10, bounds.Top + 8));
            string currentDate = "DATE " + DateTime.Now.ToString("MM/dd/yyyy");

            SizeF textSize = subHeadingFont.MeasureString(currentDate);
            PointF textPosition = new PointF(graphics.ClientSize.Width - textSize.Width - 10, result.Bounds.Y);

            graphics.DrawString(currentDate, subHeadingFont, element.Brush, textPosition);
            PdfFont timesRoman = new PdfStandardFont(PdfFontFamily.TimesRoman, 15);

            // Draw ticket
            element = new PdfTextElement("Ticket code: " + ticketId, timesRoman);
            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 12));

            element = new PdfTextElement("Departure: " + item1DepCombo.Text, timesRoman);
            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 12));

            element = new PdfTextElement("Destination: " + item1DesCombo.Text, timesRoman);
            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 12));

            var depTime = dataEntities.Flights.Where(w => w.id == ticketId).Select(s => s.deptime).FirstOrDefault();
            element = new PdfTextElement("Departure time: " + depTime, timesRoman);
            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 12));

            var desTime = dataEntities.Flights.Where(w => w.id == ticketId).Select(s => s.destime).FirstOrDefault();
            element = new PdfTextElement("Destination time: " + desTime, timesRoman);
            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 12));

            var airlineId = dataEntities.Flights.Where(w => w.id == ticketId).Select(s => s.airline).FirstOrDefault();
            var airline = dataEntities.Airlines.Where(w => w.id == airlineId).Select(s => s.name).FirstOrDefault();
            element = new PdfTextElement("Airline: " + airline, timesRoman);
            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 12));

            var typeAircraftId = dataEntities.Flights.Where(w => w.id == ticketId).Select(s => s.typeaircraft).FirstOrDefault();
            var typeAircraft = dataEntities.Aircraft.Where(w => w.id == typeAircraftId).Select(s => s.name).FirstOrDefault();
            element = new PdfTextElement("Type aircraft: " + typeAircraft, timesRoman);
            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 12));

            element = new PdfTextElement("Passenger: " + textboxLastname.Text + " " + textboxFirstname.Text + " " + textboxMiddlename.Text, timesRoman);
            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 12));

            element = new PdfTextElement("Date buy: " + DateTime.Now.ToString("MM/dd/yyyy"), timesRoman);
            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 12));

            PdfPen linePen = new PdfPen(new PdfColor(126, 151, 173), 0.70f);
            PointF startPoint = new PointF(0, result.Bounds.Bottom + 6);
            PointF endPoint = new PointF(graphics.ClientSize.Width, result.Bounds.Bottom + 6);

            graphics.DrawLine(linePen, startPoint, endPoint);

            //Saves and closes the document.
            document.Save("Ticket.pdf");
            document.Close(true);
        }

        // Кнопка "Найти по серии"
        private void SearchPassportBtn_Click(object sender, RoutedEventArgs e)
        {
            // Если пассажир есть в БД, то подставим его данные
            int getPassport = 0;

            if (textbox2.Text != "")
            {
                getPassport = Convert.ToInt32(textbox2.Text);
            }
            
            var passenger = dataEntities.Passengers.Where(w => w.passport == getPassport).FirstOrDefault();
            if (passenger != null)
            {
                var state = dataEntities.States.Where(w => w.id == passenger.state).Select(s => s.name).FirstOrDefault();
                var gender = dataEntities.Gender.Where(w => w.id == passenger.gender).Select(s => s.name).FirstOrDefault();

                textboxLastname.Text = passenger.lastname;
                textboxFirstname.Text = passenger.firstname;
                textboxMiddlename.Text = passenger.middlename;
                stateComboBox.Text = state;
                dateBirthdayPicker.SelectedDate = passenger.datebirthday;
                comboboxGender.Text = gender;
            }
            else
            {
                MessageBox.Show("Пассажира нет в базе");
            }
        }

        private void getPassengersList()
        {
            if(FilterNameTextbox.Text == "" ||
                FilterLastnameTextbox.Text == "" ||
                DateBirthdayFilter.DisplayDate == null ||
                FilterPassportTextbox.Text == "")
            {
                MessageBox.Show("Заполните поля для фильтра!");
            }
            else
            {
                int passportSerial = Convert.ToInt32(FilterPassportTextbox.Text);
                var date = new DateTime(DateBirthdayFilter.SelectedDate.Value.Ticks, DateTimeKind.Unspecified).Date;
                var query = from passengers in dataEntities.Passengers
                            where passengers.firstname == FilterNameTextbox.Text &&
                            passengers.lastname == FilterLastnameTextbox.Text &&
                            passengers.datebirthday == date &&
                            passengers.passport == passportSerial
                            select new
                            {
                                Номер = passengers.id,
                                Фамилия = passengers.lastname,
                                Имя = passengers.firstname,
                                Отчество = passengers.middlename,
                                ДатаРождения = passengers.datebirthday.Day + "." + passengers.datebirthday.Month + "." + passengers.datebirthday.Year,
                                Паспорт = passengers.passport
                            };
                if (query.Count() == 0)
                {
                    PassengersDataGrid.Visibility = Visibility.Hidden;
                    PassengerNotFoundLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    PassengersDataGrid.ItemsSource = query.ToList();
                    PassengersDataGrid.Visibility = Visibility.Visible;
                    PassengerNotFoundLabel.Visibility = Visibility.Hidden;
                }
            }
        }
        // Кнопка "Загрузить список"
        private void LoadPassengersBtn_Click(object sender, RoutedEventArgs e)
        {
            getPassengersList();
        }

        // Кнопка "Обновить" Таблицу пассажиров
        private void RefreshPassengersBtn_Click(object sender, RoutedEventArgs e)
        {
            getPassengersList();
        }

        // Иконка "Выход"
        private void item4_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
    }
}
