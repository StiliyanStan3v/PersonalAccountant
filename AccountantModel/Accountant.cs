namespace PersonalAccountant.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;

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
        }

        public void AddExpense(string category, decimal value)
        {
            try
            {
                MyAccount.Funds -= value;

                ExpensesView.ExpensesViewDataList.Where(evd => evd.Category == category)
                                        .FirstOrDefault()
                                        .SpentFunds += value;
            }
            catch (Exception)
            {

            }  
        }
        public decimal AddingFunds(decimal value)
        {
            return MyAccount.Funds += value;
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
                new XAttribute("MonthlyProfit", MyAccount.MonthlyProfit), new XAttribute("CurrentExpenses", MyAccount.CurrentExpenses),
                new XAttribute("SavingPlan", SavingPlan), new XAttribute("PlannedExpenses", PlannedExpenses)));

            XElement monthlyExpenses = new XElement("MonthlyExpenses");

            foreach (var expense in ExpensesView.ExpensesViewDataList)
            {
                monthlyExpenses.Add(new XElement(expense.Category.Replace(" ", string.Empty),
                    new XAttribute("PlannedFunds", expense.PlannedFunds),
                    new XAttribute("SpentFunds", expense.SpentFunds)));
            }

            settings.Add(monthlyExpenses);
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
                MyAccount.MonthlyProfit = Decimal.Parse(monthlyProfit);

                var expViewDataXml = settings.Element("MonthlyExpenses");

                foreach (var ev in ExpensesView.ExpensesViewDataList)
                {
                    var currEl = expViewDataXml.Element(ev.Category.Replace(" ", string.Empty));

                    ev.PlannedFunds = Decimal.Parse(currEl.Attribute("PlannedFunds").Value);
                    ev.SpentFunds = Decimal.Parse(currEl.Attribute("SpentFunds").Value);
                }
            }
            catch (Exception)
            {

            }
        } 
        #endregion
    }
}