//Nathan Teixiera
//ST10249266
//Group 2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ST10249266_PROG_POE.Classes
{
    public class RecipeClass
    {
        //string that will hold the recipe name
        private string recipeName;

        //list that will hold the ingredient object
        private List<Ingredients> ingredientList = new List<Ingredients>();

        //getter and setter for the ingredient list
        public List<Ingredients> IngredientList { get => ingredientList; set => ingredientList = value; }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //list that will hold the steps for the recipe
        private List<string> Steps = new List<string>();

        //getter and setter for the steps list
        public List<string> Steps1 { get => Steps; set => Steps = value; }

        public string RecipeName { get => recipeName; set => recipeName = value; }
       
        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        public int totalCalories()
        {
            //variable that will hold the total calories
            int totalCalories = 0;

            //loop that will go through the ingredient list and add the calories of each ingredient to the total calories
            foreach (Ingredients ingredient in ingredientList)
            {
                totalCalories += ingredient.IngredientCalories;
            }

            //output the total calories
            return totalCalories;
        }
    }
}

//-------------------------------------EOF----------------------------------------\\