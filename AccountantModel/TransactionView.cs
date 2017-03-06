namespace AccountantModel
{
    using PersonalAccountant;
    using PersonalAccountant.Data;
    using System;
    using System.Windows.Media;
    public sealed class TransactionView
    {
        public ITransaction Transaction { get; set; }
        public Brush Color
        {
            get
            {
                if (Type == "Single income")
                    return new SolidColorBrush(Colors.Green);
                else if (Type == "Monthly income")
                    return new SolidColorBrush(Colors.Blue);
                else
                    return new SolidColorBrush(Colors.Red);
            }
        }

        public string Category
        {
            get
            {
                return Transaction.GetType().Name;
            }
        }

        public string Type
        {
            get
            {
                return Transaction.Category;
            }
        }

        public decimal Value
        {
            get
            {
                return Transaction.Value;
            }
        }

        public string ValueCurrency
        {
            get
            {
                return Value.ToCurrencyString();
            }
        }

        public string TransactionDate
        {
            get
            {
                return Transaction.TransactionDate.ToShortDateString();
            }
        }

        public string Description
        {
            get
            {
                return Transaction.Description;
            }
        }

        public TransactionView(ITransaction transaction)
        {
            Transaction = transaction;
        }
    }
}