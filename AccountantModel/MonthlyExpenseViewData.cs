namespace PersonalAccountant.Data
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Media;

    public class MonthlyExpenseViewData : INotifyPropertyChanged
    {
        private decimal spentFunds;
        private decimal plannedFunds;

        public event PropertyChangedEventHandler PropertyChanged;

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
                OnPropertyChanged("SpentFunds");
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