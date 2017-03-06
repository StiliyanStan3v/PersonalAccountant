using System;

namespace PersonalAccountant
{
    public enum ProfitCategory
    {
        Salary,
        Other
    }

    public sealed class Profit : Transaction
    {
        public Profit()
        {

        }
        public Profit(string description, decimal value) 
            : base(description, value)
        {

        }
        public Profit(string category, string description, decimal value)
            : base(category, description, value)
        {
            this.Category = category;
        }
        public Profit(string category, string description, decimal value, string dateTime)
            : base(category, description, value)
        {
            this.Category = category;
            this.TransactionDate = DateTime.Parse(dateTime);
        }
    }
}