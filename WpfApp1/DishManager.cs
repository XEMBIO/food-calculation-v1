using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;
using food_calculation;
using System.Security.RightsManagement;
using System.Windows.Media.TextFormatting;

namespace food_calculation
{
    public class DishManager
    {

        private List<Dish> dishes = new List<Dish>();
        private List<Dish> filteredDishes = new List<Dish>();
        public List<Ingredient> addedIngredients = new List<Ingredient>();



        public List<Dish> Dishes
        {
            get => dishes;
            set => dishes = value;
        }

        public List<Dish> FilteredDishes
        {
            get => filteredDishes;
            set => filteredDishes = value;
        }

        public DishManager()
        {


            dishes.Add(new Dish("Pasta", new List<Ingredient>
            {
                new Ingredient("Pasta", "100 g"),
                new Ingredient("Tomato Sauce", "50 ml"),
                new Ingredient("Cheese", "20 g")
            }, false, false));

            dishes.Add(new Dish("Salad", new List<Ingredient>
            {
                new Ingredient("Lettuce", "50 g"),
                new Ingredient("Tomato", "30 g"),
                new Ingredient("Cucumber", "30 g"),
                new Ingredient("Dressing", "20 ml")
            }, false, false));

            dishes.Add(new Dish("Sandwich", new List<Ingredient>
            {
                new Ingredient("Bread", "2 slices"),
                new Ingredient("Ham", "50 g"),
                new Ingredient("Cheese", "20 g"),
                new Ingredient("Lettuce", "10 g"),
                new Ingredient("Tomato", "10 g")
            }, false, false));
        }

        public void RefreshDishes(Page1 gerichtSeite)
        {

            gerichtSeite.ClearDishes();

            foreach (var dish in dishes)
            {
                gerichtSeite.AddDish(dish.Name);
            }
        }

        public void ApplyFilter(List<Ingredient> filteredIngredients, bool _vegan, bool _vegetarisch)
        {
            filteredDishes.Clear();
            foreach (var dish in Dishes)
            {


            }
        }

        public void AddDish(List<Ingredient> ingredients, string name, bool vegan, bool vegetarisch)
        {
            Dishes.Add(new Dish(name, ingredients, vegan, vegetarisch));
        }


    }
}
