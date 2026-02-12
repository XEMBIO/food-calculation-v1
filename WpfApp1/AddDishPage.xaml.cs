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
    /// Interaktionslogik für AddDishPage.xaml
    /// </summary>
    /// 

    
    public partial class AddDishPage : Page
    {

        private DishManager dishManager;
        private List<Ingredient> ingredients = new List<Ingredient>();
        double newFontSize = 0;

        public AddDishPage(DishManager dishManager_)
        {
            InitializeComponent();
            dishManager = dishManager_;

            this.SizeChanged += ChangedSize_AddDish;
            
        }

        private void ChangedSize_AddDish(object sender, SizeChangedEventArgs e)
        {
            newFontSize = this.ActualWidth * 0.05;
            Title.FontSize = newFontSize;
            backButton.FontSize = newFontSize * 0.5;
            AddButton.FontSize = newFontSize * 0.4;
            DishNameTextBox.FontSize = newFontSize * 0.5;
            acceptButton.FontSize = newFontSize * 0.5;
            foreach (var ingredient in IngredientListPanel.Children.OfType<TextBlock>())
            {
                ingredient.FontSize = newFontSize * 0.4;    
            }
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
                        page1.RefreshFromManager();
                        return;
                    }
                    mainFrame.Navigate(new Page1(dishManager));
                }
            }
        }

        private void AcceptButton(object sender, RoutedEventArgs e)
        {
            string name = DishNameTextBox?.Text?.Trim();
            bool isVegan;
            bool isVegetarisch;

            if (vegan.IsChecked == true)
            {
                isVegan = true;
            }
            else
            {
                isVegan = false;
            }

            if (vegetarisch.IsChecked == true)
            {
                isVegetarisch = true; 
            }
            else
            {
                isVegetarisch = false; 
            }

            if (ingredients != null)
            {
                dishManager.AddDish(ingredients, name, isVegan, isVegetarisch);
            }
            Window parentWindow = Window.GetWindow(this);
            var mainFrame = parentWindow.FindName("MainFrame") as Frame;
            var page1 = mainFrame.Content as Page1;
            if (page1 != null)
            {
                page1.RefreshFromManager();
            }
            BackButton(sender, e);

        }

        private void IngredientButton(object sender, RoutedEventArgs e)
        {
            string[] ingBox = IngredientName?.Text?.Trim().Split(' ');
            

            if (ingBox != null && ingBox.Length == 3)
            {
                string name = ingBox[0];
                string amount = ingBox[1] + " " + ingBox[2];

                ingredients.Add(new Ingredient(name, amount));
                IngredientName.Text = "";
            }

            RefreshIngredients();
        }

        private void RefreshIngredients()
        {
            if (ingredients.Count > 0)
            {
                IngredientListPanel.Children.Clear();
                foreach (var ingredient in ingredients)
                {
                    string text = $"{ingredient.Name}: {ingredient.Amount} / Person";
                    IngredientListPanel.Children.Add(new TextBlock { Text = text, Foreground = Brushes.White, FontSize = newFontSize * 0.4 });
                }
            }
        }

        private void vegetarisch_Click(object sender, RoutedEventArgs e)
        {
            if (vegetarisch.IsChecked == true)
            {
                vegan.IsChecked = false;
            }
        }

        private void vegan_Click(object sender, RoutedEventArgs e)
        {
            if (vegan.IsChecked == true)
            {
                vegetarisch.IsChecked = false;
            }
        }
    }
}
