using ST10249266_PROG_POE.Classes;
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
using WpfApp2.CreateRecipeWindows;

namespace WpfApp2.Windows
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
        public RecipeClass newRecipe { get; private set; }
        List<string> steps = new List<string>();
        List<Ingredients> ingredientList = new List<Ingredients>();

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        // method that will open the add ingredient window
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            addIngredientWindow addIngredientWin = new addIngredientWindow();

            //copilot helped me implement this code that will allow the Addingredientwindow_Closed method to be called when the window is closed
            addIngredientWin.Closed += AddIngredientWindow_Closed;

            addIngredientWin.ShowDialog();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        // method that will be called when the add ingredient window is closed
        private void AddIngredientWindow_Closed(object sender, EventArgs e)
        {
            addIngredientWindow addIngredientWin = (addIngredientWindow)sender;
            Ingredients newIngredient = addIngredientWin.NewIngredient;
            if (newIngredient != null)
            {
                ingredientList.Add(newIngredient);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //method that will add the steps to the recipe based on the text in the textbox
        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            string step = stepTextBox.Text;
            steps.Add(step);
            stepTextBox.Text = "";
        }


        private void SubmitRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (steps.Count > 0 && recipeNameTextBox != null && ingredientList.Count > 0)
            {
                RecipeClass recipe = new RecipeClass(recipeNameTextBox.Text, ingredientList, steps);
                newRecipe = recipe;
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Please fill in all the textboxes");
            }

            

        }
    }
}
