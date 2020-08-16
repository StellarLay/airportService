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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        AirportServiceEntities dataEntities = new AirportServiceEntities();

        public Registration()
        {
            InitializeComponent();
        }

        // Кнопка "Регистрация"
        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            if(nameInput.Text == "" ||
                surnameInput.Text == "" ||
                addressInput.Text == "" ||
                phoneInput.Text == "" ||
                loginInput.Text == "" ||
                passInput.Text == "" ||
                confirmPassInput.Text == "" ||
                AdministatorRadio.IsChecked == false &&
                ManagerRadio.IsChecked == false)
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                if(confirmPassInput.Text != passInput.Text)
                {
                    MessageBox.Show("Подтверждающий пароль не совпадает");
                }
                else
                {
                    int roleId = 0;
                    if (AdministatorRadio.IsChecked == true)
                    {
                        roleId = 1;
                    }
                    else
                    {
                        roleId = 2;
                    }

                    Employees employ = new Employees
                    {
                        firstname = nameInput.Text,
                        lastname = surnameInput.Text,
                        address = addressInput.Text,
                        phone = phoneInput.Text,
                        login = loginInput.Text,
                        password = passInput.Text,
                        roleId = roleId
                    };

                    dataEntities.Employees.Add(employ);
                    dataEntities.SaveChanges();

                    MessageBox.Show("Сотрудник успешно добавлен!");
                    this.Close();
                }
            }
        }
    }
}
