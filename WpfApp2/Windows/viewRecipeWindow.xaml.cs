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
    /// Interaction logic for viewRecipeWindow.xaml
    /// </summary>
    public partial class viewRecipeWindow : Window
    {
        public List<RecipeClass> printRecipeList;

        public viewRecipeWindow(List<RecipeClass> recipes)
        {
            InitializeComponent();
            printRecipeList = recipes;

            RecipeNameOut.Text = "";
            int no = 1;
            // Foreach loop that will go through the recipe list and print the recipe name to the TextBlock
            foreach (RecipeClass recipe in printRecipeList)
            {
                RecipeNameOut.Text += no.ToString() + ") " + recipe.RecipeName + Environment.NewLine;
                no++;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //Method that prints the recipe based on the recipe name
        private void nameSubmit_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTXT.Text;
            RecipeClass recipeOBJ = printRecipeList.Find(recipe => recipe.RecipeName == recipeName);
            if (recipeOBJ == null)
            {
                MessageBox.Show("Recipe not found");
                return;
            }
            RecipeOut.Text = recipeOBJ.PrintRecipe();
            
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //Method that prints the recipe based on food group filtering
        private void foodGroupSubmit_Click(object sender, RoutedEventArgs e)
        {
            string selectedFoodGroup = FoodGroupComboBox.Text;
            
            string recipesOutput = "";

            //Copilot helped me implement this code that will filter the recipes based on the selected food group
            var filteredRecipes = printRecipeList.Where(recipe => recipe.IngredientList.Any(ingredient => ingredient.IngredientFoodGroup == selectedFoodGroup));

            if (!filteredRecipes.Any())
            {
                RecipeOut.Text = "No recipes found for the selected food group.";
                return;
            }

            //foreach that will go through the filtered recipes and use the PrintRecipe method to print the recipe to the TextBlock
            foreach (RecipeClass recipe in filteredRecipes)
            {
                recipesOutput += recipe.PrintRecipe() + Environment.NewLine;
            }

            // Display the recipes in the RecipeOut TextBlock
            RecipeOut.Text = recipesOutput;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //Method that prints the recipe based on the total calories
        private void caloriesSubmit_Click(object sender, RoutedEventArgs e)
        {
            int selectedCalories = int.Parse(CaloriesTextBox.Text);
            
            string recipesOutput = "";

            //Copilot helped me implement this code that will filter the recipes based on the total calories
            var filteredRecipes = printRecipeList.Where(recipe => recipe.totalCalories() <= selectedCalories);

            if (!filteredRecipes.Any())
            {
                RecipeOut.Text = "No recipes found for the selected calories.";
                return;
            }

            //foreach that will go through the filtered recipes and use the PrintRecipe method to print the recipe to the TextBlock
            foreach (RecipeClass recipe in filteredRecipes)
            {
                recipesOutput += recipe.PrintRecipe() + Environment.NewLine;
            }

            // Display the recipes in the RecipeOut TextBlock
            RecipeOut.Text = recipesOutput;
        }
    }
}
//---------------------------------------------------------EOF--------------------------------------------------------------------------\\