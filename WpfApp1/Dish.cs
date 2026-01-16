using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace food_calculation
{
    class Dish
    {
        private List<Ingredient> ingredients;
        private string name;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public List<Ingredient> Ingredients
        {
            get => ingredients;
            set => ingredients = value;
        }

        public Dish(string name, List<Ingredient> ingredients)
        {
            this.name = name;
            this.ingredients = ingredients;
        }
    }
}
