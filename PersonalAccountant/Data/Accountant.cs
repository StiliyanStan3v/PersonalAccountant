using PersonalAccountant.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace PersonalAccountant
{
    public static class Accountant
    {
        //private const float dreamlineBuffer = 1.3f;

        static Accountant()
        {
            Expense.ExpenseViewData = new List<ExpenseViewData>();
            
            var expensesCategories = Enum.GetValues(typeof(ExpenseCategory)).Cast<ExpenseCategory>();
            
            foreach (var ctg in expensesCategories)
            {
                Expense.ExpenseViewData.Add(new ExpenseViewData(ctg));
            }
            Account = new Account();
        }

        public static void AddExpense(string category, string description, string amount)
        {
            Account.AddExpense(new Expense(category, description, decimal.Parse(amount), DateTime.Now));
            ((MainWindow)System.Windows.Application.Current.MainWindow).LogDG.Items.Refresh();
        }

        public static void AddProfit(string description, string value)
        {
            Account.AddProfit(new Profit(description, decimal.Parse(value), DateTime.Now));
            ((MainWindow)System.Windows.Application.Current.MainWindow).LogDG.Items.Refresh();
        }

        private static Account Account { get; set; }

        public static void Init(string v)
        {

        }

        public static void BindingViews(Grid accountGrid, DataGrid dataGridExpenses, DataGrid dataGridLog)
        {
            dataGridExpenses.ItemsSource = Expense.ExpenseViewData;
            accountGrid.DataContext = Account;
            dataGridLog.ItemsSource = TransactionsLog.Instance().LogList();
        }
        public static void BindingExpenses(ComboBox dataExpensesView)
        {
            dataExpensesView.ItemsSource = Expense.ExpenseViewData;
        }
    }
}