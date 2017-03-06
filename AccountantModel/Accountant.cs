namespace PersonalAccountant.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using AccountantModel;

    public class Accountant
    {
        #region Properties
        public Account MyAccount { get; set; }
        public MonthlyExpensesControl ExpensesView { get; set; }

        public ICollection<MonthlyExpenseViewData> MonthlyExpenseView { get; private set; }
        public decimal AddFund { get; set; }
        public decimal PlannedExpenses
        {
            get
            {
                return ExpensesView.ExpensesViewDataList.Select(expData => expData.PlannedFunds).Sum();
            }
        }
        public decimal SavingPlan
        {
            get
            {
                return MyAccount.MonthlyProfit - ExpensesView.ExpensesViewDataList.Select(expData => expData.PlannedFunds).Sum();
            }
        }

        public decimal CurrentExpenses
        {
            get
            {
                return ExpensesView.ExpensesViewDataList.Select(evd => evd.SpentFunds).Sum();
            }
        }

        public decimal PlannedSpentStatus
        {
            get
            {
                return ExpensesView.PlannedSpentStatus;
            }
        }
        #endregion
        #region Constructors
        public Accountant()
        {
            MyAccount = new Account();
            ExpensesView = new MonthlyExpensesControl();
        }
        public Accountant(Account acc, MonthlyExpensesControl monthlyExpCtrl)
        {
            MyAccount = acc;
            ExpensesView = monthlyExpCtrl;
        }

        #endregion
        #region Public Methods
        public void Load(string path)
        {
            ParseFromXML(path);
        }
        public void New()
        {
            MyAccount = new Account();
            ExpensesView = new MonthlyExpensesControl();
            TransactionsLog.Instance().NewLog();
        }

        public void AddTransaction(string category, string description, decimal value)
        {
            try
            {
                if(value != 0)
                {
                    if (category == "Single income")
                    {
                        ITransaction profit = new Profit(category, description, value);
                        MyAccount.Funds += value;
                        TransactionsLog.Instance().SaveToLog(new TransactionView(profit));
                    }
                    else if(category == "Monthly income")
                    {
                        ITransaction profit = new Profit(category, description, value);
                        TransactionsLog.Instance().SaveToLog(new TransactionView(profit));
                        MyAccount.MonthlyProfits.Add(profit); 
                    }
                    else
                    {
                        ITransaction expense = new Expense(category, description, value);

                        MyAccount.Funds -= value;

                        ExpensesView.ExpensesViewDataList.Where(evd => evd.Category == category)
                                                .FirstOrDefault()
                                                .SpentFunds += value;

                        MyAccount.MonthlyExpenses.Add(expense);
                        TransactionsLog.Instance().SaveToLog(new TransactionView(expense));
                    }
                }   
            }
            catch (Exception ex)
            {

            }  
        }

        public void Save()
        {
            DataToXML();
        }
        #endregion
        #region Private methods
        private void DataToXML()
        {
            XElement settings = new XElement("AccountantSettings", new XElement("AccountBudget", new XAttribute("Funds", MyAccount.Funds),
                new XAttribute("MonthlyProfit", MyAccount.MonthlyProfit), new XAttribute("CurrentExpenses", CurrentExpenses),
                new XAttribute("SavingPlan", SavingPlan), new XAttribute("PlannedExpenses", PlannedExpenses)));

            XElement monthlyExpenses = new XElement("MonthlyExpenses");

            foreach (var expense in ExpensesView.ExpensesViewDataList)
            {
                monthlyExpenses.Add(new XElement(expense.Category.Replace(" ", string.Empty),
                    new XAttribute("PlannedFunds", expense.PlannedFunds),
                    new XAttribute("SpentFunds", expense.SpentFunds)));
            }

            settings.Add(monthlyExpenses);

            XElement transactionsLog = new XElement("TransactionsLog");
            foreach (var item in TransactionsLog.Instance().LogList())
            {
                var description = string.Empty;
                if(item.Description != null)
                {
                    description = item.Description;
                }

                transactionsLog.Add(new XElement("Transaction",
                    new XAttribute("Category", item.Category),
                    new XAttribute("Type", item.Type),
                    new XAttribute("Description", description),
                    new XAttribute("Value", item.Value),
                    new XAttribute("TransactionDate", item.TransactionDate)));
            }
            settings.Add(transactionsLog);

            settings.Add(new XElement("DateTime", DateTime.Now.ToShortDateString()));

            settings.Save("Settings.xml");
        }

        private void ParseFromXML(string path)
        {
            XElement settings;
            try
            {
                settings = XElement.Load(path);

                var fund = settings.Element("AccountBudget").Attribute("Funds").Value;
                var monthlyProfit = settings.Element("AccountBudget").Attribute("MonthlyProfit").Value;

                MyAccount.Funds = Decimal.Parse(fund);

                var expViewDataXml = settings.Element("MonthlyExpenses");

                foreach (var ev in ExpensesView.ExpensesViewDataList)
                {
                    var currEl = expViewDataXml.Element(ev.Category.Replace(" ", string.Empty));

                    ev.PlannedFunds = Decimal.Parse(currEl.Attribute("PlannedFunds").Value);
                    ev.SpentFunds = Decimal.Parse(currEl.Attribute("SpentFunds").Value);
                }

                foreach (var item in settings.Element("TransactionsLog").Elements())
                {
                    var category = item.Attribute("Category").Value;

                    if (category == "Profit")
                        TransactionsLog.Instance().SaveToLog(new TransactionView(new Profit(item.Attribute("Type").Value,
                            item.Attribute("Description").Value, decimal.Parse(item.Attribute("Value").Value),
                            item.Attribute("TransactionDate").Value)));
                    else
                        TransactionsLog.Instance().SaveToLog(new TransactionView(new Expense(item.Attribute("Type").Value,
                        item.Attribute("Description").Value, decimal.Parse(item.Attribute("Value").Value),
                        item.Attribute("TransactionDate").Value)));
                }
            }
            catch (Exception)
            {

            }
        } 
        #endregion
    }
}