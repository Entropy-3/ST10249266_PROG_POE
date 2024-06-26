﻿using ST10249266_PROG_POE.Classes;
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
    }
}
