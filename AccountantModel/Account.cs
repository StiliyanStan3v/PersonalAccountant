namespace PersonalAccountant.Data
{
    using System.Collections.Generic;
    public class Account : IAccount
    {
        #region Properties
        public ICollection<Expense> MonthlyExpenses { get; set; }
        public ICollection<Profit> MonthlyProfits { get; set; }
        public decimal Funds { get; set; }
        public decimal MonthlyProfit { get; set; }
        public decimal CurrentExpenses { get; set; }
        #endregion
        #region Constructors
        public Account()
        {
            MonthlyExpenses = new List<Expense>();
            MonthlyProfits = new List<Profit>();
        }
        public Account(decimal funds, decimal monthlyProfit, decimal currentExpenses,
            IList<Expense> monthlyExpenses, IList<Profit> monthlyProfits)
        {
            this.Funds = funds;
            this.CurrentExpenses = currentExpenses;
            this.MonthlyProfit = monthlyProfit;
            this.MonthlyExpenses = monthlyExpenses;
            this.MonthlyProfits = monthlyProfits;
        }
        #endregion
    }
}