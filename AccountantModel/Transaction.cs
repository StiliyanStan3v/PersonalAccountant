namespace PersonalAccountant
{
    using System;

    public abstract class Transaction : ITransaction
    {

        protected Transaction() { }

        protected Transaction(string description, decimal value)
        {
            this.Description = description;
            this.Value = value;
        }

        protected Transaction(string description, decimal value, DateTime transactionDate)
        {
            this.Description = description;
            this.Value = value;
            this.TransactionDate = transactionDate;
        }

        protected Transaction(string category, string description, decimal value, DateTime transactionDate)
        {
            this.Category = category;
            this.Description = description;
            this.Value = value;
            this.TransactionDate = transactionDate;
        }

        public string Description { get; set; }

        public decimal Value { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Category { get; set; }
    }
}