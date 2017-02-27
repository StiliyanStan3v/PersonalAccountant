using System.Collections.Generic;

namespace PersonalAccountant.Data
{
    public class Account : IAccount
    {
         public ICollection<Expense> MonthlyExpenses { get; set; }
         public ICollection<Profit> MonthlyProfits { get; set; }
         public decimal CurrentFunds { get; set; }
         public decimal Savings { get; set; }

        //public decimal MonthlyProfit { get; set; }
        // //{
        // //    get
        // //    {
        // //        return this.MonthlyProfits.Sum(mp => mp.Value);
        // //    }
        // //}
         public decimal PotentialSavings { get; set; }
        // //{
        // //    get
        // //    {
        // //        return this.MonthlyProfits.Sum(mp => mp.Value) - Expense.ExpenseViewData.Sum(exp => exp.PlannedFunds);
        // //    }
        // //}
        //
        public Account()
        {
            MonthlyExpenses = new List<Expense>();
            MonthlyProfits = new List<Profit>();
        }
        public Account(decimal currentFunds, decimal savings, decimal monthlyExpens,
            IList<Expense> monthlyExpenses, IList<Profit> monthlyProfits)
        {
            this.CurrentFunds = currentFunds;
            this.Savings = savings;
            this.MonthlyExpenses = monthlyExpenses;
            this.MonthlyProfits = monthlyProfits;
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void AddProfit(Profit profit)
        //{
        //    this.CurrentFunds += profit.Value;
        //    this.MonthlyProfits.Add(profit);
        //    OnPropertyChanged("MonthlyProfit");
        //    OnPropertyChanged("SavingPlan");
        //
        //    TransactionsLog.Instance().SaveToLog(profit);
        //}

        //public void AddExpense(Expense expense)
        //{
        //    this.CurrentFunds -= expense.Value;
        //    this.CurrentExpens += expense.Value;
        //    this.MonthlyExpenses.Add(expense);
        //    OnPropertyChanged("CurrentExpens");
        //
        //    Expense.ExpenseViewData.Where(evd => evd.Category == expense.Category)
        //                            .FirstOrDefault()
        //                            .SpentFunds += expense.Value;
        //
        //    TransactionsLog.Instance().SaveToLog(expense);
        //}

        //public void AddSaving(decimal saving)
        //{
        //    this.Savings += saving;
        //}

        //protected void OnPropertyChanged(string name)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(name));
        //    }
        //}
    }
}