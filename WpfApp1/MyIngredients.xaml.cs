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
            repeatManager.RefreshMyIngredients();
            if (repeatManager.ingredientNames.Count != 0)
            {
                foreach (var ingredient in repeatManager.ingredientNames)
                {
                    int index = repeatManager.ingredientNames.IndexOf(ingredient);
                    string amount = repeatManager.ingredientAmounts[index];
                    IngredientsStackPanel.Children.Add(new TextBlock
                    {
                        Text = $"{ingredient}: {amount}",
                        FontSize = 16,
                        Margin = new Thickness(5)
                    });
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