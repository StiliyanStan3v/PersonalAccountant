using System.Collections.Generic;

namespace PersonalAccountant
{
    public sealed class TransactionsLog
    {
        private static readonly TransactionsLog TransactionInstance = new TransactionsLog();

        private readonly List<Transaction> transactions = new List<Transaction>();
        private TransactionsLog() { }

        public static TransactionsLog Instance()
        {
            return TransactionInstance;
        }

        public void SaveToLog(Transaction transaction)
        {
            this.transactions.Add(transaction);
        }

        public List<Transaction> LogList()
        {
            return this.transactions;
        }
    }
}