using System.Windows;

namespace PersonalAccountant
{
    /// <summary>
    /// Interaction logic for ExpenseWindow.xaml
    /// </summary>
    public partial class ExpenseWindow : Window
    {
        public ExpenseWindow()
        {
            InitializeComponent();
            Accountant.BindingExpenses(ExpensesCategoryCB);
        }

        private void AddProfitBtn_Click(object sender, RoutedEventArgs e)
        {
            decimal n;
            bool isNumeric = decimal.TryParse(ExpenseTB.Text, out n);

            if (isNumeric && !string.IsNullOrEmpty(ExpensesCategoryCB.Text))
            {
                Accountant.AddExpense(ExpensesCategoryCB.Text, DescriptionTB.Text, ExpenseTB.Text);
                this.Close();
            }
        }
    }
}