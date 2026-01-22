using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace food_calculation
{
    public class RepeatManager
    {
        public List<string> ingredientNames = new List<string>();
        public List<string> ingredientAmounts = new List<string>();
        public List<Ingredient> ingredients = new List<Ingredient>();

        public RepeatManager(List<Ingredient> ingredients)
        {
            this.ingredients = ingredients;
        }

        public void RefreshMyIngredients()
        {
            ingredientAmounts.Clear();
            ingredientNames.Clear();
            foreach (var ingredient in ingredients)
            {
                if (ingredientNames.Contains(ingredient.Name))
                {
                    int index = ingredientNames.IndexOf(ingredient.Name);
                    string[] existingAmount = ingredientAmounts[index].Split(' ');
                    string[] newAmount = ingredient.Amount.Split(' ');
                    double existingValue = formatAmount(existingAmount[0], existingAmount[1]);
                    double newValue = formatAmount(newAmount[0], newAmount[1]);
                    existingAmount[1] = formatUnit(existingAmount[1]);
                    newAmount[1] = formatUnit(newAmount[1]);

                    double totalAmount = existingValue + newValue;

                    if (totalAmount >= 1000)
                    {
                        totalAmount = totalAmount / 1000;

                    }

                }
            }
        }

        private double formatAmount(string amount, string unit)
        {
            if (unit.ToLower() == "kg" || unit.ToLower() == "l")
            {
                return Convert.ToDouble(amount) * 1000;
            }
            else if (unit.ToLower() == "g" || unit.ToLower() == "ml")
            {
                return Convert.ToDouble(amount);
            }
            else
            {
                return Convert.ToDouble(amount);
            }
        }

        private string formatUnit(string unit)
        {
            if (unit.ToLower() == "kg" || unit.ToLower() == "l")
            {
                if (unit.ToLower() == "kg")
                {
                    return "g";
                }
                else
                {
                    return "ml";
                }
            }
            else
            {
                return unit;
            }
        }
    }
}
