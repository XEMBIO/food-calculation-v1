using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace food_calculation
{
    /// <summary>
    /// Interaction logic for IngredientPage.xaml
    /// </summary>
    public partial class IngredientPage : Page
    {

        private Dish currDish;
        private DishManager dishManager;
        public List<Ingredient> newIngredients = new List<Ingredient>();
        public IngredientPage(Dish currDish, DishManager dishManager)
        {
            InitializeComponent();
            this.currDish = currDish;
            this.dishManager = dishManager;


        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService?.CanGoBack == true)
            {
                this.NavigationService.GoBack();
                return;
            }

            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                var mainFrame = parentWindow.FindName("MainFrame") as Frame;
                if (mainFrame != null)
                {
                    var page1 = mainFrame.Content as Page1;
                    if (page1 != null)
                    {
                        mainFrame.Navigate(page1);
                        return;
                    }
                    mainFrame.Navigate(new Page1(dishManager));
                }
            }
        }

        public void Display(Dish dish)
        {
            List<Ingredient> ingredients = dish.Ingredients;
            IngredientsPanel.Children.Clear();
            foreach (var ingredient in ingredients)
            {
                string text = $"{ingredient.Name}: {ingredient.Amount}";
                TextBlock ingredientText = new TextBlock
                {
                    Text = text,
                    FontSize = 16,
                    Margin = new Thickness(5)
                };
                IngredientsPanel.Children.Add(ingredientText);
            }
        }

        private void RefreshIngredients(object sender, RoutedEventArgs e)
        {
            IngredientAmountPanel.Children.Clear();
            double amountPeople = 1;
            if (AmountPeople.Text != null && AmountPeople.Text != "")
            {
                amountPeople = int.Parse(AmountPeople.Text);
            }

            
            double newAmount;
            List<Ingredient> ingredients = currDish.Ingredients;

            foreach (var ingredient in ingredients)
            {
                string[] splitAmount = ingredient.Amount.Split(' ');
                double oldAmount = double.Parse(splitAmount[0]);
                newAmount = oldAmount * amountPeople;
                newAmount = FormatAmount(newAmount, splitAmount[1]);
                if (newAmount != oldAmount * amountPeople)
                {
                    splitAmount[1] = FormatUnit(splitAmount[1]);
                }
                newIngredients.Add(new Ingredient(ingredient.Name, newAmount.ToString() + " " + splitAmount[1]));
                string newAmountString = newAmount.ToString() + " " + splitAmount[1];
                IngredientAmountPanel.Children.Add(new TextBlock
                {
                    Text = newAmountString,
                    FontSize = 16,
                    Margin = new Thickness(5)
                });
            }
        }

        private string FormatUnit(string unit)
        {
            switch(unit)
            {
                case "g":
                    return "kg";
                    
                case "kg":
                    return "g";
                    
                case "ml":
                    return "l";

                case "l":
                    return "ml";

                default:
                    return unit;
            }
        }

        private double FormatAmount(double amount, string unit)
        {
            if (unit == "g" || unit == "ml")
            {
                if (amount >= 1000)
                {
                    return amount / 1000;
                }
                return amount;
            }
            else if (unit == "kg")
            {
                if (amount < 1)
                {
                    return amount * 1000;
                }
                else
                {
                    return amount;
                }
            }
            else if (unit == "l")
            {
                if (amount < 1)
                {
                    return amount * 1000;
                }
                else
                {
                    return amount;
                }
            }
            else
            {
                return amount;
            }
        }

        private void NumberTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextNumeric(e.Text);
        }

        private bool IsTextNumeric(string text)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(text, "^[0-9]+$");
        }

        private void DoneButton(object sender, RoutedEventArgs e)
        {
            dishManager.addedIngredients.AddRange(newIngredients);
            BackButton(sender, e);
        }
    }
}
