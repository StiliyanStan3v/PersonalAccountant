using System;
using System.ComponentModel;

namespace PersonalAccountant
{
    public abstract class Transaction : INotifyPropertyChanged
    {
        private decimal value;
        private string description;
        private DateTime transactionDate;

        public event PropertyChangedEventHandler PropertyChanged;

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

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
                OnPropertyChanged("Description");
            }
        }

        public decimal Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
                OnPropertyChanged("Value");
            }
        }
        public DateTime TransactionDate
        {
            get
            {
                return this.transactionDate;
            }
            set
            {
                this.transactionDate = value;
                OnPropertyChanged("TransactionDate");
            }
        }
        public string Category { get; set; }


        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}