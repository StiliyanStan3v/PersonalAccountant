using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PersonalAccountant.Data
{
    public class Account : INotifyPropertyChanged
    {
        private decimal currentFunds;

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
            this.CurrentExpens = monthlyExpens;
            this.MonthlyExpenses = monthlyExpenses;
            this.MonthlyProfits = monthlyProfits;
        }

        public decimal CurrentFunds
        {
            get
            {
                return this.currentFunds;
            }
            set
            {
                this.currentFunds = value;
                OnPropertyChanged("CurrentFunds");
            }
        }
        public decimal Savings { get; private set; }
        public decimal CurrentExpens { get; private set; }
        public decimal MonthlyProfit
        {
            get
            {
                return this.MonthlyProfits.Sum(mp => mp.Value);
            }
        }

        public decimal SavingPlan
        {
            get
            {
                return this.MonthlyProfits.Sum(mp => mp.Value) - Expense.ExpenseViewData.Sum(exp => exp.PlannedFunds);
            }
        }

        public IList<Expense> MonthlyExpenses { get; private set; }
        public IList<Profit> MonthlyProfits { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddProfit(Profit profit)
        {
            this.CurrentFunds += profit.Value;
            this.MonthlyProfits.Add(profit);
            OnPropertyChanged("MonthlyProfit");
            OnPropertyChanged("SavingPlan");

            TransactionsLog.Instance().SaveToLog(profit);
        }
        public void AddExpense(Expense expense)
        {
            this.CurrentFunds -= expense.Value;
            this.CurrentExpens += expense.Value;
            this.MonthlyExpenses.Add(expense);
            OnPropertyChanged("CurrentExpens");

            Expense.ExpenseViewData.Where(evd => evd.Category == expense.Category)
                                    .FirstOrDefault()
                                    .SpentFunds += expense.Value;

            TransactionsLog.Instance().SaveToLog(expense);
        }

        public void AddSaving(decimal saving)
        {
            this.Savings += saving;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}