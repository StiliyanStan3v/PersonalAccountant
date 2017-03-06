using System;

namespace PersonalAccountant
{
    public enum ExpenseCategory
    {
        UtilityBills,
        Home,
        FoodAndSupplies,
        Transport,
        Car,
        Kids,
        ClothesAndShoes,
        Personal,
        CigarettesAndAlcohol,
        Entertainment,
        EatingOut,
        Education,
        Gifts,
        SportHobby,
        TravelVacation,
        Medicine,
        Pets,
        Other
    }

    public sealed class Expense : Transaction
    {

        public Expense(string category, string description, decimal value)
            : base(category, description, value)
        {
            base.TransactionDate = DateTime.Now;
        }
        public Expense(string category, string description, decimal value, string dateTime)
            : base(category, description, value)
        {
            base.TransactionDate = DateTime.Parse(dateTime);
        }


    }
}