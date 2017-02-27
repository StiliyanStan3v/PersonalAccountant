using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace PersonalAccountant.Data
{
    public class ExpensesViewData : INotifyPropertyChanged
    {
        private decimal plannedFunds;
        private decimal spentFunds;

        public Brush Color { get; set; }
        public FontWeight FontWeight { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ExpensesViewData(ExpenseCategory category)
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