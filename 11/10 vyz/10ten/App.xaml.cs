using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace _lab11
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        TicketsContext db;

        private void OnStartup(object sender, StartupEventArgs e)
        {

            db = new TicketsContext();
            db.Lexturys.Load();

            List<Lextury> lexturys = db.Lexturys.ToList();
            MainWindow view = new MainWindow();
            MainViewModel viewModel = new MainViewModel(lexturys);
            view.DataContext = viewModel;
            view.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            db.Dispose();
        }
    }
}