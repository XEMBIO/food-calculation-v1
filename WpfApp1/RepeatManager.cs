using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace food_calculation
{
    public class RepeatManager
    {
        public List<List<Ingredient>> repeatLists = new List<List<Ingredient>>();
        public List<Ingredient> ingredients = new List<Ingredient>();

        public RepeatManager(List<Ingredient> ingredients)
        {
            this.ingredients = ingredients;
        }

        public void FindRepeats()
        {
            repeatLists.Clear();
            foreach (var ingredient in ingredients)
            {
                
            }
        }
    }
}
