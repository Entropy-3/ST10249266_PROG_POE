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

namespace WpfApp2.Windows
{
    /// <summary>
    /// Interaction logic for clearRecipeWindow.xaml
    /// </summary>
    public partial class clearRecipeWindow : Window
    {
        public List<RecipeClass> printRecipeList3;

        public clearRecipeWindow(List<RecipeClass> recipes)
        {
            InitializeComponent();
            printRecipeList3 = recipes;

            allRecipeOut.Text = "";
            int no = 1;

            // Foreach loop that will go through the recipe list and print the recipe name to the TextBlock
            foreach (RecipeClass recipe in printRecipeList3)
            {
                allRecipeOut.Text += no.ToString() + ") " + recipe.RecipeName + Environment.NewLine;
                no++;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //Method that clears the recipe based on the recipe name
        private void ClearRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTXT.Text;
            RecipeClass recipeOBJ = printRecipeList3.Find(recipe => recipe.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipeOBJ == null)
            {
                MessageBox.Show("Recipe not found");
                return;
            }

            // prompt the user to confirm the deletion of the recipe
            MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the recipe '{recipeName}'?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // Remove the recipe from the list
                printRecipeList3.Remove(recipeOBJ);

                MessageBox.Show($"Recipe '{recipeName}' has been successfully deleted.");
                allRecipeOut.Text = "";
                int no = 1;

                // Foreach loop that will go through the recipe list and print the recipe name to the TextBlock
                foreach (RecipeClass recipe in printRecipeList3)
                {
                    allRecipeOut.Text += no.ToString() + ") " + recipe.RecipeName + Environment.NewLine;
                    no++;
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
//---------------------------------------------------------EOF--------------------------------------------------------------------------\\