namespace PersonalAccountant
{
    using AccountantModel;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System;

    public sealed class TransactionsLog
    {
        private static readonly TransactionsLog TransactionInstance = new TransactionsLog();

        private ObservableCollection<TransactionView> transactions = new ObservableCollection<TransactionView>();
        private TransactionsLog() { }

        public static TransactionsLog Instance()
        {
            return TransactionInstance;
        }

        public void SaveToLog(TransactionView transaction)
        {
            this.transactions.Add(transaction);
        }

        public ObservableCollection<TransactionView> LogList()
        {
            return this.transactions;
        }

        public void NewLog()
        {
            transactions = new ObservableCollection<TransactionView>();
        }
    }
}