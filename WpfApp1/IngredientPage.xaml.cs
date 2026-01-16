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
        public IngredientPage()
        {
            InitializeComponent();
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
                TextBlock ingredientText = new TextBlock
                {
                    Text = $"{ingredient.Name}: {ingredient.Amount}",
                    Margin = new Thickness(5)
                };
                IngredientsPanel.Children.Add(ingredientText);
            }
        }

    }
}
