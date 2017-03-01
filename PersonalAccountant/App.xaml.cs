using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PersonalAccountant
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            PersonalAccountant.MainWindow window = new MainWindow();
            AccountantViewModel AccVM = new AccountantViewModel("");
            window.DataContext = AccVM;
            window.Show();
        }
    }
}