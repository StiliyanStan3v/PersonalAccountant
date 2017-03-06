namespace PersonalAccountant.Data
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Media;

    public class MonthlyExpenseViewData : INotifyPropertyChanged
    {
        #region private fields
        private decimal spentFunds;
        private decimal plannedFunds;
        #endregion
        #region Properties
        public string Category { get; set; }
        public decimal PlannedFunds
        {
            get
            {
                return this.plannedFunds;
            }
            set
            {
                this.plannedFunds = value;
                OnPropertyChanged("Color");
                OnPropertyChanged("FontWeight");
            }
        }

        public string PlannedFundsCurrency
        {
            get
            {
                return PlannedFunds.ToCurrencyString();
            }
        }
        public decimal SpentFunds
        {
            get
            {
                return this.spentFunds;
            }
            set
            {
                this.spentFunds = value;
                OnPropertyChanged("Color");
                OnPropertyChanged("FontWeight");
                OnPropertyChanged("SpentFundsCurrency");
            }
        }

        public string SpentFundsCurrency
        {
            get
            {
                return SpentFunds.ToCurrencyString();
            }
        }

        public Brush Color
        {
            get
            {
                return SpentFunds > PlannedFunds ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Black);
            }
        }
        public FontWeight FontWeight
        {
            get
            {
                return SpentFunds > PlannedFunds ? FontWeights.Bold : FontWeights.Normal;
            }
        }
        #endregion
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Protected methods
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