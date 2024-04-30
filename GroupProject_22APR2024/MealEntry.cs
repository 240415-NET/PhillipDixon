using System;

namespace GroupProject_22APR2024
{
    public class MealEntry
    {
        public string Meal = "No Meal Selected";
         public bool Cooked = false;

        public MealEntry(string Meal)
            {
                this.Meal = Meal;
                this.Cooked = false;
            }
        public MealEntry(string Meal, bool Cooked) : this(Meal)
            {
                this.Meal = Meal;
                this.Cooked = Cooked;
            }




    public bool GetCooked()
            {
                return this.Cooked;
            }

        public void SetCooked(bool Cooked)
            {
                this.Cooked = Cooked;
            }
    }
}