namespace PersonalAccountant.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Accountant
    {
        #region Properties
        public Account MyAccount { get; set; }
        public MonthlyExpensesControl ExpensesView { get; set; }
        public ICollection<MonthlyExpenseViewData> MonthlyExpenseView { get; private set; }
        public decimal AddFund { get; set; }
        public decimal PlannedExpenses
        {
            get
            {
                return ExpensesView.ExpensesViewDataList.Select(expData => expData.PlannedFunds).Sum();
            }
        }
        public decimal SavingPlan
        {
            get
            {
                return MyAccount.MonthlyProfit - ExpensesView.ExpensesViewDataList.Select(expData => expData.PlannedFunds).Sum();
            }
        }
        #endregion
        #region Constructors
        public Accountant()
        {
            MyAccount = new Account();
            ExpensesView = new MonthlyExpensesControl();
        }
        public static Accountant Load(string path)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Public Methods
        public void AddExpense(string category, decimal value)
        {
            MyAccount.Funds -= value;
            MyAccount.CurrentExpenses += value;

            ExpensesView.ExpensesViewDataList.Where(evd => evd.Category == category)
                                    .FirstOrDefault()
                                    .SpentFunds += value;
        }
        public decimal AddingFunds(decimal value)
        {
            return MyAccount.Funds += value;
        }
        #endregion
    }
}