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
    public partial class scaleRecipeWindow : Window
    {
        public List<RecipeClass> printRecipeList2;
        public scaleRecipeWindow(List<RecipeClass> recipes)
        {
            InitializeComponent();
            printRecipeList2 = recipes;

            RecipeNameOut.Text = "";
            int no = 1;
            // Foreach loop that will go through the recipe list and print the recipe name to the TextBlock
            foreach (RecipeClass recipe in printRecipeList2)
            {
                RecipeNameOut.Text += no.ToString() + ") " + recipe.RecipeName + Environment.NewLine;
                no++;
            }
        }

        private void scaleHalf_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = scaleFactorTextBox.Text;
            RecipeClass recipeOBJ = printRecipeList2.Find(recipe => recipe.RecipeName == recipeName);
            if (recipeOBJ == null)
            {
                MessageBox.Show("Recipe not found");
                return;
            }
            recipeOBJ.scaleRecipe(1);
            RecipeOut.Text = recipeOBJ.PrintRecipe();
        }

        private void scaleDouble_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = scaleFactorTextBox.Text;
            RecipeClass recipeOBJ = printRecipeList2.Find(recipe => recipe.RecipeName == recipeName);
            if (recipeOBJ == null)
            {
                MessageBox.Show("Recipe not found");
                return;
            }
            recipeOBJ.scaleRecipe(2);
            RecipeOut.Text = recipeOBJ.PrintRecipe();
        }

        private void scaleTriple_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = scaleFactorTextBox.Text;
            RecipeClass recipeOBJ = printRecipeList2.Find(recipe => recipe.RecipeName == recipeName);
            if (recipeOBJ == null)
            {
                MessageBox.Show("Recipe not found");
                return;
            }
            recipeOBJ.scaleRecipe(3);
            RecipeOut.Text = recipeOBJ.PrintRecipe();

        }
        private void resetRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = scaleFactorTextBox.Text;
            RecipeClass recipeOBJ = printRecipeList2.Find(recipe => recipe.RecipeName == recipeName);
            if (recipeOBJ == null)
            {
                MessageBox.Show("Recipe not found");
                return;
            }

            //outputs a message box asking the user if they are sure they want to reset the recipe
            MessageBoxResult result = MessageBox.Show("Are you sure you want to reset the recipe?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                recipeOBJ.scaleRecipe(4);
                RecipeOut.Text = recipeOBJ.PrintRecipe();
            }

        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
