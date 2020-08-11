
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AirportService
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Нужен для того, чтобы при вызове Application.Current.Shutdown(); форма закрывалась
        public App()
        {
            this.ShutdownMode = ShutdownMode.OnLastWindowClose;
        }

        // Передадим юзера в другую форму
        public static class My
        {
            internal static string username;
            internal static int roleId;
        }

    }
}
