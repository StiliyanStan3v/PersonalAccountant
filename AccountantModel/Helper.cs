namespace PersonalAccountant.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class CustomControlObservableColletion : System.Collections.ObjectModel.ObservableCollection<MonthlyExpenseViewData>
    {
        // Required because, by default, it is not possible to find out which items
        // have been cleared when the CollectionChanged event is fired after a .Clear() call.
        protected override void ClearItems()
        {
            foreach (var item in Items.ToList())
                Remove(item);
        }

    }

    public static class Helper
    {
        public static string ToString(ExpenseCategory category)
        {
            switch (category)
            {
                case ExpenseCategory.UtilityBills:
                    return "Utility Bills";
                case ExpenseCategory.FoodAndSupplies:
                    return "Food and Supplies";
                case ExpenseCategory.ClothesAndShoes:
                    return "Clothes and Shoes";
                case ExpenseCategory.CigarettesAndAlcohol:
                    return "Cigarettes And Alchohol";
                case ExpenseCategory.EatingOut:
                    return "Eating out";
                case ExpenseCategory.SportHobby:
                    return "Sport and Hobbies";
                case ExpenseCategory.TravelVacation:
                    return "Travel and Vacation";
                default:
                    return category.ToString();
            }
        }

        public static List<string> Categories()
        {
            var categories = new List<string>();

            foreach (ExpenseCategory expCategory in Enum.GetValues(typeof(ExpenseCategory)))
            {
                categories.Add(Helper.ToString(expCategory));
            }

            return categories;
        }
    }
}