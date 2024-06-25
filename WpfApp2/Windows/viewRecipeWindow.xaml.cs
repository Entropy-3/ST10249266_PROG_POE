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

        private List<RecipeClass> recipeList;

        public viewRecipeWindow(List<RecipeClass> recipes)
        {
            InitializeComponent();
            recipeList = recipes;

            // Clear existing content
            RecipeNameTXT.Text = "";
            int no = 1;
            // Foreach loop that will go through the recipe list and print the recipe name to the TextBlock
            foreach (RecipeClass recipe in recipeList)
            {
                RecipeNameTXT.Text += no.ToString() + ") " + recipe.RecipeName + Environment.NewLine;
                no++;
            }
        }
    }
}
