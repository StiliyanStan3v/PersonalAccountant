namespace PersonalAccountant.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public class Accountant
    {
        public Account MyAccount { get; set; }
        public MonthlyExpensesControl ExpensesView { get; set; }

        public decimal AddFund { get; set; }

        public decimal AddingFunds(decimal value)
        {
            return MyAccount.Funds += value;
        }

        public ICollection<MonthlyExpenseViewData> MonthlyExpenseView { get; private set; }

        public Accountant()
        {
            MyAccount = new Account();
            ExpensesView = new MonthlyExpensesControl();
        }

        //public decimal MonthlyProfit
        //{
        //    get
        //    {
        //        return MyAccount.MonthlyProfits != null ? MyAccount.MonthlyProfits.Select(mp => mp.Value).Sum() : 0;
        //    }
        //}

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

        public static Accountant Load(string path)
        {
            throw new NotImplementedException();
        }
        public void AddExpense(string category, decimal value)
        {
            MyAccount.Funds -= value;
            MyAccount.CurrentExpenses += value;

            ExpensesView.ExpensesViewDataList.Where(evd => evd.Category == category)
                                    .FirstOrDefault()
                                    .SpentFunds += value;
        }
    }
}