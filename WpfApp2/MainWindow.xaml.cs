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
using WpfApp2.Windows;
using ST10249266_PROG_POE.Classes;

namespace WpfApp2
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
        List<RecipeClass> recipeList = new List<RecipeClass>();


        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        // When the CreateRecipe button is clicked
        //opens the CreateRecipeWindow and hides the main window
        private void CreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Create and show the CreateRecipeWindow
            createRecipeWindow createRecipeWindow = new createRecipeWindow();
            // Hide the MainWindow
            this.Hide();

            //copilot helped me implement this code that will allow the createRecipeWindow_closed method to be called when the window is closed
            createRecipeWindow.Closed += createRecipeWindow_Closed;

            createRecipeWindow.ShowDialog();

            
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //Method executes When the createRecipeWindow is closed
        private void createRecipeWindow_Closed(object sender, EventArgs e)
        {
            createRecipeWindow createRecipeWindow = (createRecipeWindow)sender;
            RecipeClass newRecipe = createRecipeWindow.newRecipe;
            if (newRecipe != null)
            {
                recipeList.Add(newRecipe);
            }
            this.Show();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        // Opens the ViewRecipeWindow
        private void ViewRecipe_Click(object sender, RoutedEventArgs e)
        {
            viewRecipeWindow viewRecipeWindow = new viewRecipeWindow(recipeList);
            viewRecipeWindow.ShowDialog();
        }
        
        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        // Opens the ViewRecipeWindow
        private void ViewAll_Click(object sender, RoutedEventArgs e)
        {
            allRecipesWindow allRecipesWindow = new allRecipesWindow(recipeList);
            allRecipesWindow.ShowDialog();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        // Opens the ScaleRecipeWindow
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            scaleRecipeWindow scaleRecipeWindow = new scaleRecipeWindow(recipeList);
            scaleRecipeWindow.ShowDialog();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        // Opens the ClearRecipeWindow
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            clearRecipeWindow clearRecipeWindow = new clearRecipeWindow(recipeList);
            clearRecipeWindow.ShowDialog();
        }
    }
}
//-------------------------------------------------------------EOF-------------------------------------------------------------------------------------\\
