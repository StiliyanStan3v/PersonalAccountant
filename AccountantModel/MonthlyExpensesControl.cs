namespace PersonalAccountant.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class MonthlyExpensesControl
    {
        public ICollection<MonthlyExpenseViewData> ExpensesViewDataList { get; set; }
        public decimal PlannedSpentStatus
        {
            get
            {
                return ExpensesViewDataList.Select(evd => evd.PlannedFunds).Sum() - ExpensesViewDataList.Select(evd => evd.SpentFunds).Sum();
            }
        }

        public MonthlyExpensesControl()
        {
            ExpensesViewDataList = new ObservableCollection<MonthlyExpenseViewData>();
            foreach (ExpenseCategory expCategory in Enum.GetValues(typeof(ExpenseCategory)))
            {
                ExpensesViewDataList.Add(new MonthlyExpenseViewData() { Category = Helper.ToString(expCategory) });
            }
        }     
    }
}