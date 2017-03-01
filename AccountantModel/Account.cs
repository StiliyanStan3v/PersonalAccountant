using System.Collections.Generic;
using System.ComponentModel;

namespace PersonalAccountant.Data
{
    public class Account : IAccount, INotifyPropertyChanged
    {
        public ICollection<Expense> MonthlyExpenses { get; set; }
        public ICollection<Profit> MonthlyProfits { get; set; }

        public decimal Funds { get; set; }

        public decimal MonthlyProfit { get; set; }
        public decimal CurrentExpenses { get; set; }

        public Account()
        {
            MonthlyExpenses = new List<Expense>();
            MonthlyProfits = new List<Profit>();
        }
        public Account(decimal currentFunds, decimal savings, decimal monthlyExpens,
            IList<Expense> monthlyExpenses, IList<Profit> monthlyProfits)
        {
            this.MonthlyExpenses = monthlyExpenses;
            this.MonthlyProfits = monthlyProfits;
        }

        public event PropertyChangedEventHandler PropertyChanged;

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