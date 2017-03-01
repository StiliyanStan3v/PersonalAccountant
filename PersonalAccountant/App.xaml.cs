using System.Windows;

namespace PersonalAccountant
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        AccountantViewModel AccVM;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            AccVM = new AccountantViewModel("Settings.xml");
            window.DataContext = AccVM;
            window.Show();
        }
    }
}