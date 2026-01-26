using System.Text;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DishManager dishManager = new DishManager();
        public MainWindow()
        {
            InitializeComponent();
            this.SizeChanged += MainWindow_SizeChanged;
            
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateFontSizes();
        }

        private void UpdateFontSizes()
        {
            // Schriftgröße basierend auf Fensterbreite berechnen
            double fontSize = this.ActualWidth * 0.06; // 4% der Breite
            MeineZutaten.FontSize = fontSize;
            GerichteButton.FontSize = fontSize;
            Title.FontSize = fontSize; // Titel etwas größer
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page1(dishManager));
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MyIngredients(dishManager));
        }
    }
}