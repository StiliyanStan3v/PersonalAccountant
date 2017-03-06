namespace PersonalAccountant
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using System.ComponentModel;
    using PersonalAccountant.Data;
    using ViewModel;
    using AccountantModel;

    public class AccountantViewModel : INotifyPropertyChanged
    {
        private bool canExecute = true;

        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties
        public ICommand UpdateButtonCommand { get; set; }

        public ICommand AddFundsCommand { get; set; }

        public ICommand AddTransactionCommand { get; set; }

        public ICommand SaveButtonCommand { get; set; }

        public ICommand RestartingCommand { get; set; }

        public IList<string> TransactionCategories
        {
            get
            {
                IList<string> categories = Helper.Categories();
                return categories;
            }
        }

        public ICollection<MonthlyExpenseViewData> MonthlyExpenses
        {
            get
            {
                return _Accountant.ExpensesView.ExpensesViewDataList;
            }
        }

        public ICollection<TransactionView> TransactionLog
        {
            get
            {
                return TransactionsLog.Instance().LogList();
            }
        }


        public Accountant _Accountant { get; set; }

        public string MonthlyProfit
        {
            get
            {
                return _Accountant.MyAccount.MonthlyProfit.ToCurrencyString();
            }
        }

        public decimal GetAddFundValue { get; set; }

        public string Funds
        {
            get
            {
                return _Accountant.MyAccount.Funds.ToCurrencyString();
            }
        }

        public string CurrentExpenses
        {
            get
            {
                return _Accountant.CurrentExpenses.ToCurrencyString();
            }
        }

        public string GetSelectedCategory { get; set; }

        public string GetExpenseDescription { get; set; }

        public decimal GetExpenseValue { get; set; }

        public string SavingPlan
        {
            get { return _Accountant.SavingPlan.ToCurrencyString(); }
        }

        public string PlannedSpentStatus
        {
            get { return _Accountant.PlannedSpentStatus.ToCurrencyString(); }
        }

        public string PlannedExpenses
        {
            get
            {
                return _Accountant.PlannedExpenses.ToCurrencyString();
            }
        }

        public bool CanExecute
        {
            get
            {
                return this.canExecute;
            }

            set
            {
                if (this.canExecute == value)
                {
                    return;
                }

                this.canExecute = value;
            }
        }
        
        #endregion
        #region Private Methods
        private void UpdateAccountInfo(object obj)
        {
            OnPropertyChanged("");
        }

        private void AddTransaction(object obj)
        {
            _Accountant.AddTransaction(GetSelectedCategory, GetExpenseDescription, GetExpenseValue);
            OnPropertyChanged("");
        }

        private void Save(object obj)
        {
            _Accountant.Save();
        }

        private void Restart(object obj)
        {
            _Accountant.New();
            OnPropertyChanged("");
        }
        #endregion
        #region Construcotrs
        public AccountantViewModel(string path)
        {
            _Accountant = new Accountant();

            _Accountant.Load(path);


            UpdateButtonCommand = new RelayCommand(UpdateAccountInfo, param => this.canExecute);
            AddTransactionCommand = new RelayCommand(AddTransaction, param => this.canExecute);
            SaveButtonCommand = new RelayCommand(Save, param => this.canExecute);
            RestartingCommand = new RelayCommand(Restart, param => this.canExecute);
        } 
        #endregion
        #region Protected Methods
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}