namespace PersonalAccountant.Data
{
    using System.Collections.Generic;

    public interface IAccount
    {
        ICollection<Expense> MonthlyExpenses { get; set; }
        ICollection<Profit> MonthlyProfits { get; set; }
        decimal Funds { get; set; }
        decimal MonthlyProfit { get; set; }
    }
}