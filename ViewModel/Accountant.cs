using PersonalAccountant.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace PersonalAccountant
{
    public static class Accountant
    {
        private static Account MyAccount { get; set; }
        private static IList<ExpensesViewData> ExpensesViewData { get; set; }
        //private const float dreamlineBuffer = 1.3f;

        static Accountant()
        {
            ExpensesViewData = new List<ExpensesViewData>();
            
            var expensesCategories = Enum.GetValues(typeof(ExpenseCategory)).Cast<ExpenseCategory>();
            
            foreach (var ctg in expensesCategories)
            {
                ExpensesViewData.Add(new ExpensesViewData(ctg));
            }
            Account = new Account();
        }

        public static void AddExpense(string category, string description, string amount)
        {
            Account.MonthlyExpenses.Add((new Expense(category, description, decimal.Parse(amount), DateTime.Now)));
        }

        public static void AddProfit(string description, string value)
        {
            Account.MonthlyProfits.Add(new Profit(description, decimal.Parse(value), DateTime.Now));
        }

        private static Account Account { get; set; }

        public static void Init(string v)
        {
            MyAccount = new Account();
        }

        public static void BindingViews(Grid accountGrid, DataGrid dataGridExpenses, DataGrid dataGridLog)
        {
            dataGridExpenses.ItemsSource = ExpensesViewData;
            accountGrid.DataContext = Account;
            dataGridLog.ItemsSource = TransactionsLog.Instance().LogList();
        }
        public static void BindingExpenses(ComboBox dataExpensesView)
        {
            dataExpensesView.ItemsSource = ExpensesViewData;
        }
    }
}