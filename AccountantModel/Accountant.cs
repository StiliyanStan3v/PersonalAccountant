namespace PersonalAccountant.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public class Accountant : INotifyPropertyChanged
    {
        public Account MyAccount { get; set; }
        public MonthlyExpensesControl ExpensesView { get; set; }

        public ICollection<MonthlyExpenseViewData> MonthlyExpenseView { get; private set; }

        public Accountant()
        {
            MyAccount = new Account();
            ExpensesView = new MonthlyExpensesControl();
        }

        public decimal MonthlyProfit
        {
            get
            {
                return MyAccount.MonthlyProfits != null ? MyAccount.MonthlyProfits.Select(mp => mp.Value).Sum() : 0;
            }
        }

        public decimal CurrentExpenses
        {
            get
            {
                return MyAccount.MonthlyExpenses != null ? MyAccount.MonthlyExpenses.Select(mp => mp.Value).Sum() : 0;
            }
        }

        public decimal SavingPlan
        {
            get
            {
                return MonthlyProfit - ExpensesView.ExpensesViewDataList.Select(expData => expData.PlannedFunds).Sum();
            }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        public static Accountant Load(string path)
        {
            throw new NotImplementedException();
        }

        public void AddExpense(string category, string description, string amount)
        {
            MyAccount.MonthlyExpenses.Add((new Expense(category, description, decimal.Parse(amount), DateTime.Now)));
        }

        public void AddProfit(string description, string value)
        {
            MyAccount.MonthlyProfits.Add(new Profit(description, decimal.Parse(value), DateTime.Now));
        }
    }
}