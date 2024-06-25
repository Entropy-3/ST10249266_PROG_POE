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
using WpfApp1.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // When the CreateRecipe button is clicked
        //opens the CreateRecipeWindow and hides the main window
        private void CreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Create and show the CreateRecipeWindow
            createRecipeWindow createRecipeWindow = new createRecipeWindow();
            createRecipeWindow.Show();

            // Hide the MainWindow
            this.Hide();
        }

    }
}