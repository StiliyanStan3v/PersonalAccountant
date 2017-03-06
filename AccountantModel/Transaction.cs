namespace PersonalAccountant
{
    using System;

    public abstract class Transaction : ITransaction
    {
        #region Properties
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Category { get; set; }
        #endregion
        #region Constructors
        protected Transaction() { }

        protected Transaction(string description, decimal value)
        {
            this.Description = description;
            this.Value = value;
            this.TransactionDate = DateTime.Now;
        }

        protected Transaction(string category, string description, decimal value)
        {
            this.Category = category;
            this.Description = description;
            this.Value = value;
            this.TransactionDate = DateTime.Now;
        }

        protected Transaction(string category, string description, decimal value, DateTime transactionDate)
        {
            this.Category = category;
            this.Description = description;
            this.Value = value;
            this.TransactionDate = transactionDate;
        }
        #endregion
    }
}