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

        public AddDishPage(DishManager dishManager_)
        {
            InitializeComponent();
            dishManager = dishManager_;
            
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
                    mainFrame.Navigate(new Page1());
                }
            }
        }

        private void AcceptButton(object sender, RoutedEventArgs e)
        {
            string name = DishNameTextBox?.Text?.Trim();
            dishManager.AddDish(null, name);
            Window parentWindow = Window.GetWindow(this);
            var mainFrame = parentWindow.FindName("MainFrame") as Frame;
            var page1 = mainFrame.Content as Page1;
            if (page1 != null)
            {
                page1.RefreshFromManager();
            }
            BackButton(sender, e);

        }
    }
}
