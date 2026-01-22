using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Printing;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for MyIngredients.xaml
    /// </summary>
    public partial class MyIngredients : Page
    {

        DishManager dishManager;
        public RepeatManager repeatManager;
        public MyIngredients(DishManager dishManager)
        {
            InitializeComponent();

            this.dishManager = dishManager;
            repeatManager = new RepeatManager(dishManager.addedIngredients);
            InnitIngredients();
        }

        public void InnitIngredients()
        {
            repeatManager.ingredients = dishManager.addedIngredients;
            IngredientsStackPanel.Children.Clear();
            if (dishManager.addedIngredients.Count != 0)
            {
                foreach (Ingredient ingredient in dishManager.addedIngredients)
                {

                    TextBlock ingredientText = new TextBlock();

                    ingredientText = new TextBlock
                    {
                        Text = $"{ingredient.Name}: {ingredient.Amount}",
                        FontSize = 16,
                        Margin = new Thickness(5)
                    };
                    
                    IngredientsStackPanel.Children.Add(ingredientText);

                }
            }
            else
            {
                IngredientsStackPanel.Children.Add(new TextBlock
                {
                    Text = "No ingredients added.",
                    FontSize = 16,
                    Margin = new Thickness(5)
                });
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                var mainFrame = parentWindow.FindName("MainFrame") as Frame;
                if (mainFrame != null)
                {
                    mainFrame.Content = null;
                }
            }
        }
    }
}