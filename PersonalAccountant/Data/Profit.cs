using System;

namespace PersonalAccountant
{
    public enum ProfitCategory
    {
        Salary,
        Other
    }

    public class Profit : Transaction
    {
        public Profit()
        {

        }
        public Profit(string description, decimal value, DateTime transactionDate) 
            : base(description, value, transactionDate)
        {

        }
        public Profit(string category, string description, decimal value, DateTime transactionDate)
            : base(category, description, value, transactionDate)
        {
            this.Category = category;
        }
    }
}