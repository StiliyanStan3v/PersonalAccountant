namespace PersonalAccountant.Data
{
    using System.Collections.Generic;

    public interface IAccount
    {
        ICollection<ITransaction> MonthlyExpenses { get; set; }
        ICollection<ITransaction> MonthlyProfits { get; set; }
        decimal Funds { get; set; }
        decimal MonthlyProfit { get; }
    }
}