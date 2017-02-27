namespace PersonalAccountant.Data
{
    using System.Collections.Generic;

    public interface IAccount
    {
        ICollection<Expense> MonthlyExpenses { get; set; }
        ICollection<Profit> MonthlyProfits { get; set; }
        decimal CurrentFunds { get; set; }
        decimal Savings { get; set; }
        decimal PotentialSavings { get; set; }
    }
}