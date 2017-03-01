namespace PersonalAccountant
{
    using PersonalAccountant.Data;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Input;
    using ViewModel;
    using System;
    using System.ComponentModel;

    public class AccountantViewModel : INotifyPropertyChanged
    {
        private bool canExecute = true;

        public event PropertyChangedEventHandler PropertyChanged;

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

        public ICommand UpdateButtonCommand { get; set; }
        public ICommand SettingsButtonCommand { get; set; }

        

        public Accountant _Accountant { get; set; }

        public AccountantViewModel(string path)
        {
            if (File.Exists(path))
            {
                _Accountant = Accountant.Load(path);
            }
            else
            {
                _Accountant = new Accountant();
            }
            UpdateButtonCommand = new RelayCommand(UpdateAccountInfo, param => this.canExecute);
            SettingsButtonCommand = new RelayCommand(ChangeSettings, param => this.canExecute);
        }

        private void UpdateAccountInfo(object obj)
        {
            OnPropertyChanged("SavingPlan");
            OnPropertyChanged("PlannedExpenses");
        }
        private void ChangeSettings(object obj)
        {
            _Accountant.AddProfit("Selary", "1000");
        }


        public ICollection<MonthlyExpenseViewData> MonthlyExpenses
        {
            get
            {
                return _Accountant.ExpensesView.ExpensesViewDataList;
            }
        }

        public decimal MonthlyProfit
        {
            get
            {
                return _Accountant.MonthlyProfit;
            }
        }

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