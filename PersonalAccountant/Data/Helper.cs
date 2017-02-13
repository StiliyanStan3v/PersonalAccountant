namespace PersonalAccountant.Data
{
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
    }
}