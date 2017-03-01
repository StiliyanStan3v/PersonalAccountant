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

    public class Expense : Transaction
    {

        public Expense(string category, string description, decimal value)
            : base(description, value)
        {

        }

        public Expense(string category, string description, decimal value, DateTime transactionTime)
            : base(category, description, value, transactionTime)
        {

        }
    }
}