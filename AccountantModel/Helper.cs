namespace PersonalAccountant.Data
{
    using System;
    using System.Collections.Generic;

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
            categories.Add("Single income");
            categories.Add("Monthly income");

            foreach (ExpenseCategory expCategory in Enum.GetValues(typeof(ExpenseCategory)))
            {
                categories.Add(Helper.ToString(expCategory));
            }

            return categories;
        }

        public static string ToCurrencyString(this decimal value)
        {
            return string.Format("{0:C}", value);
        }
    }
}