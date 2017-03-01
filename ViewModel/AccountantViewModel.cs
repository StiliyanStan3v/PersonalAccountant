namespace PersonalAccountant
{
    using PersonalAccountant.Data;
    using System.Collections.Generic;
    using System.IO;


    public class AccountantViewModel
    {
        public Accountant _Accountant { get; set; }

        public AccountantViewModel(string path)
        {
            if (File.Exists(path))
            {
                _Accountant = Accountant.Load(path);
            }
            else
            {
                _Accountant = new Accountant();
            }
        }

        public ICollection<MonthlyExpenseViewData> MonthlyExpenses
        {
            get
            {
                return _Accountant.ExpensesView.ExpensesViewDataList;
            }
        }

        public decimal MonthlyProfit
        {
            get
            {
                return _Accountant.MonthlyProfit;
            }
        }

        public decimal CurrentExpenses
        {
            get
            {
                return _Accountant.CurrentExpenses;
            }
        }

        public decimal SavingPlan
        {
            get
            {
                return _Accountant.SavingPlan;
            }
        }
    }
}