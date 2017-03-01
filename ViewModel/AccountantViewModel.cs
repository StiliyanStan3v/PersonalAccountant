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

        public ICommand SavingPlanButtonCommand { get; set; }
        public ICommand AddProfitButtonCommand { get; set; }

        

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
            SavingPlanButtonCommand = new RelayCommand(UpdateSavingPlan, param => this.canExecute);
            AddProfitButtonCommand = new RelayCommand(AddProfit, param => this.canExecute);
        }

        private void UpdateSavingPlan(object obj)
        {
            OnPropertyChanged("SavingPlan");
        }
        private void AddProfit(object obj)
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