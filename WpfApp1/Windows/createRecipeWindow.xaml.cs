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
using System.Windows.Shapes;
using WpfApp1.CreateRecipeWindows;


namespace WpfApp1.Windows
{
    /// <summary>
    /// Interaction logic for createRecipeWindow.xaml
    /// </summary>
    public partial class createRecipeWindow : Window
    {
        public createRecipeWindow()
        {
            InitializeComponent();
        }
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            // Create and show the CreateRecipeWindow
            addIngredientWindow addIngredientWindow = new addIngredientWindow();
            addIngredientWindow.Show();

            
        }
    }
}
