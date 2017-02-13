using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace PersonalAccountant.Data
{
    public class ExpenseViewData : INotifyPropertyChanged
    {
        private decimal plannedFunds;
        private decimal spentFunds;

        public event PropertyChangedEventHandler PropertyChanged;

        public ExpenseViewData(ExpenseCategory category)
        {
            this.Category = Helper.ToString(category);
            this.Color = new SolidColorBrush(Colors.Black);
            this.FontWeight = FontWeights.Light;
        }

        public string Category { get; private set; }
        public decimal PlannedFunds
        {
            get
            {
                return this.plannedFunds;
            }
            set
            {
                this.plannedFunds = value;
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
                OnPropertyChanged("SpentFunds");
            }
        }
        public Brush Color { get; set; }
        public FontWeight FontWeight { get; set; }

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