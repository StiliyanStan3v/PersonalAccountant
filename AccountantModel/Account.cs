namespace PersonalAccountant.Data
{
    using System.Collections.Generic;
    using System.Linq;
    public class Account : IAccount
    {
        #region Properties
        public ICollection<ITransaction> MonthlyExpenses { get; set; }
        public ICollection<ITransaction> MonthlyProfits { get; set; }
        public decimal Funds { get; set; }
        public decimal MonthlyProfit
        {
            get
            {
                return MonthlyProfits.Select(mp => mp.Value).Sum();
            }
        }
        #endregion
        #region Constructors
        public Account()
        {
            MonthlyExpenses = new List<ITransaction>();
            MonthlyProfits = new List<ITransaction>();
        }
        //public Account(decimal funds, decimal monthlyProfit, decimal currentExpenses,
        //    IList<Expense> monthlyExpenses, IList<Profit> monthlyProfits)
        //{
        //    this.Funds = funds;
        //    this.MonthlyExpenses = monthlyExpenses;
        //    this.MonthlyProfits = monthlyProfits;
        //}
        #endregion
    }
}