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
using food_calculation;
using WpfApp1;

namespace food_calculation
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private DishManager dishManager;
        public Page1()
        {
            InitializeComponent();

            dishManager = new DishManager();

            dishManager.RefreshDishes(this);

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

        private void DishClicked(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            Window parentWindow = Window.GetWindow(this);
            var mainFrame = parentWindow.FindName("MainFrame") as Frame; 
            string dishName = clickedButton.Content.ToString();
            Dish selectedDish = dishManager.Dishes.FirstOrDefault(d => d.Name == dishName);
            if (selectedDish != null)
            {
                IngredientPage ingredientPage = new IngredientPage();
                ingredientPage.Title.Content = selectedDish.Name;
                mainFrame.Content = null;
                mainFrame.Navigate(ingredientPage);
                ingredientPage.Display(selectedDish);

            }
        }

        private void RefreshMenu(object sender, RoutedEventArgs e)
        {
            dishManager.RefreshDishes(this);
        }

        public void AddDish(string name)
        {
            Button btn = new Button
            {
                Content = name,
                FontSize = 25,
                
            };

            btn.Click += DishClicked;

            GerichtScroll.Children.Add(btn);
        }

        public void ClearDishes()
        {
            GerichtScroll.Children.Clear();
        }


    }
}
