namespace PersonalAccountant
{
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Input;
    using System.ComponentModel;
    using PersonalAccountant.Data;
    using ViewModel;
    using System;

    public class AccountantViewModel : INotifyPropertyChanged
    {
        private bool canExecute = true;

        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties
        public ICommand UpdateButtonCommand { get; set; }

        public ICommand AddFundsCommand { get; set; }

        public ICommand AddExpenseCommand { get; set; }

        public ICommand SaveButtonCommand { get; set; }

        public ICommand RestartingCommand { get; set; }

        public IList<string> ExpenseCategories
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

        public Accountant _Accountant { get; set; }

        public decimal MonthlyProfit
        {
            get
            {
                return _Accountant.MyAccount.MonthlyProfit;
            }
            set
            {
                _Accountant.MyAccount.MonthlyProfit = value;
                OnPropertyChanged("MonthlyProfit");
                OnPropertyChanged("SavingPlan");
            }
        }

        public decimal AddFund { get; set; }

        public decimal Funds
        {
            get
            {
                return _Accountant.MyAccount.Funds;
            }
        }

        public decimal CurrentExpenses
        {
            get
            {
                return _Accountant.CurrentExpenses;
            }
        }

        public string SelectedCategory { get; set; }

        public decimal ExpenseValue { get; set; }

        public decimal SavingPlan
        {
            get
            {
                return _Accountant.SavingPlan;
            }
        }

        public decimal PlannedExpenses
        {
            get
            {
                return _Accountant.PlannedExpenses;
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
            OnPropertyChanged("SavingPlan");
            OnPropertyChanged("PlannedExpenses");
        }

        private void AddFunds(object obj)
        {
            _Accountant.AddingFunds(AddFund);
            OnPropertyChanged("Funds");
        }

        private void AddExpenses(object obj)
        {
            _Accountant.AddExpense(SelectedCategory, ExpenseValue);
            OnPropertyChanged("CurrentExpenses");
            OnPropertyChanged("Funds");
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
            AddFundsCommand = new RelayCommand(AddFunds, param => this.canExecute);
            AddExpenseCommand = new RelayCommand(AddExpenses, param => this.canExecute);
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