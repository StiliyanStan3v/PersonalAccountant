using System.Windows;

namespace PersonalAccountant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Accountant.Init("");
            Accountant.BindingViews(this.AccountGrid, this.ExpensesGrid, this.LogDG);
        }

        private void AddProfit_Click(object sender, RoutedEventArgs e)
        {
            ProfitWindow profWin = new ProfitWindow();
            profWin.ShowDialog();
        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            ExpenseWindow expWin = new ExpenseWindow();
            expWin.ShowDialog();
        }
    }
}