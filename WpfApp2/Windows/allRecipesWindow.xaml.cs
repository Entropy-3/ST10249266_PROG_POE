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
    
    public partial class allRecipesWindow : Window
    {
        public List<RecipeClass> printRecipeList1;
        public allRecipesWindow(List<RecipeClass> recipes)
        {
            InitializeComponent();
            printRecipeList1 = recipes;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //Method that will print all the recipes to the TextBlock
        private void ViewRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            //foreach that will go through the recipe list and use the PrintRecipe method to print the recipe to the TextBlock
            foreach (RecipeClass recipe in printRecipeList1)
            {
                allRecipeOut.Text += recipe.PrintRecipe() + Environment.NewLine;
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
//---------------------------------------------------------EOF--------------------------------------------------------------------------\\