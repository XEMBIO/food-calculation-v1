using System;
using System.Collections.Generic;
using System.Linq;
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

        Dish currDish;
        public IngredientPage(Dish currDish)
        {
            InitializeComponent();
            this.currDish = currDish;
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                var mainFrame = parentWindow.FindName("MainFrame") as Frame;
                if (mainFrame != null)
                {
                    mainFrame.Content = null;
                    mainFrame.Navigate(new Page1());
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
            int amountPeople = 1;
            if (AmountPeople.Text != null && AmountPeople.Text != "")
            {
                amountPeople = int.Parse(AmountPeople.Text);
            }

            
            int newAmount;
            List<Ingredient> ingredients = currDish.Ingredients;

            foreach (var ingredient in ingredients)
            {
                string[] splitAmount = ingredient.Amount.Split(' ');
                int oldAmount = int.Parse(splitAmount[0]);
                newAmount = oldAmount * amountPeople;
                string newAmountString = newAmount.ToString() + " " + splitAmount[1];
                IngredientAmountPanel.Children.Add(new TextBlock
                {
                    Text = newAmountString,
                    FontSize = 16,
                    Margin = new Thickness(5)
                });
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

    }
}
