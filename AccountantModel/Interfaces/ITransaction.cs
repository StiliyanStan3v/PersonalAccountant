namespace PersonalAccountant
{
    using System;

    public interface ITransaction
    {
        string Description { get; set; }

        decimal Value { get; set; }

        DateTime TransactionDate { get; set; }

        string Category { get; set; }
    }
}