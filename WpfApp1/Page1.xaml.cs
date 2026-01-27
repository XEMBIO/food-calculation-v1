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
        public DishManager dishManager;
        public double fontSize = 1;
        public Page1(DishManager dishManage)
        {
            InitializeComponent();

            dishManager = dishManage;

            dishManager.RefreshDishes(this);

            this.SizeChanged += Ingredient_SizeChanged;

        }

        private void Ingredient_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ChangeSizeNow();
        }

        private void ChangeSizeNow()
        {
            fontSize = this.ActualWidth * 0.05; // 5% der Breite
            Title.FontSize = fontSize; // Titel etwas größer
            BackButton.FontSize = fontSize * 0.5;
            RefreshButton.FontSize = fontSize * 0.5;
            Add_Button.FontSize = fontSize * 0.4;
            foreach (var child in GerichtScroll.Children.OfType<Button>())
            {
                child.FontSize = fontSize * 0.5;
            }
        }

        public void RefreshFromManager()
        {
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
                IngredientPage ingredientPage = new IngredientPage(selectedDish, dishManager);
                ingredientPage.Title.Content = selectedDish.Name;
                mainFrame.Content = null;
                mainFrame.Navigate(ingredientPage);
                ingredientPage.Display(selectedDish);

            }
        }


        private void AddButton(object sender, RoutedEventArgs e)
        {
            Window mainWindow = Window.GetWindow(this);

            if (mainWindow != null)
            {
                var mainFrame = mainWindow.FindName("MainFrame") as Frame;
                if (mainFrame  != null)
                {
                    mainFrame.Navigate(new AddDishPage(dishManager));
                }
            }
        }

        private void RefreshMenu(object sender, RoutedEventArgs e)
        {
            dishManager.RefreshDishes(this);
            ChangeSizeNow();
        }

        public void AddDish(string name)
        {
            Button btn = new Button
            {
                Content = name,
                FontSize = 25,
                Foreground = Brushes.White,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
            };

            var template = new ControlTemplate(typeof(Button));
            var borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(25));
            borderFactory.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(Button.BackgroundProperty));
            borderFactory.SetValue(Border.PaddingProperty, new Thickness(10));

            var contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenterFactory.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);

            borderFactory.AppendChild(contentPresenterFactory);
            template.VisualTree = borderFactory;


            btn.Template = template;
            btn.Click += DishClicked;

            GerichtScroll.Children.Add(btn);
        }

        public void ClearDishes()
        {
            GerichtScroll.Children.Clear();
        }


    }
}
