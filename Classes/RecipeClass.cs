//Nathan Teixiera
//ST10249266
//Group 2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static ST10249266_PROG_POE.Classes.WorkerClass;

namespace ST10249266_PROG_POE.Classes
{
    public class RecipeClass
    {
        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //declaring the delegate
        public delegate void CheckCaloriesDelegate(int calories);

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
        //default constructor
        public RecipeClass()
        {
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //constructor that takes in all information required to make a recipe
        public RecipeClass(string recipeName, List<Ingredients> ingredientList, List<string> steps)
        {
            this.recipeName = recipeName;
            this.ingredientList = ingredientList;
            this.Steps = steps;
        }

        public int totalCalories()
        {
            //variable that will hold the total calories
            int totalCalories = 0;

            //loop that will go through the ingredient list and add the calories of each ingredient to the total calories
            foreach (Ingredients ingredient in ingredientList)
            {
                totalCalories += ingredient.IngredientCalories;
            }

            //calls the checkCalories delegate
            checkCalories(totalCalories);
            //output the total calories
            return totalCalories;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        public CheckCaloriesDelegate checkCalories = (calories) =>
        {
            bool healthy = true;
            if (calories >= 300)
            {
                healthy = false;
            }
        };

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //method that will print the recipe
        public string PrintRecipe()
        {
            string result = "";
            result += Environment.NewLine;
            result += this.recipeName;
            result += Environment.NewLine;
            result += "------------------------------------------------------";
            result += Environment.NewLine;
            result += "INGREDIENTS:";

            // Foreach statement that prints out the ingredients
            int j = 1;
            foreach (Ingredients ingredient in this.IngredientList)
            {
                // Sets the color of the text to green
                result += Environment.NewLine;
                result += $"{j}) {ingredient.IngredientQuantity} {ingredient.IngredientMeasurement} of {ingredient.IngredientName} Calories: {ingredient.IngredientCalories} food group: {ingredient.IngredientFoodGroup}";
                result += Environment.NewLine;
                j++;
            }
            result += Environment.NewLine;
            result += "Total Calories: " + this.totalCalories();
            result += Environment.NewLine;
            result += "------------------------------------------------------";

            result += Environment.NewLine;
            result += "INSTRUCTIONS:";

            // For statement that prints out the steps for the recipe
            int no = 1;
            for (int k = 0; k < Steps.Count; k++)
            {
                // Sets the color of the text to cyan
                result += Environment.NewLine;
                result += "Step " + no + ") " + this.Steps1[k];
                no++;
            }
            result += Environment.NewLine;
            result += "------------------------------------------------------";

            return result;
        }

        private void scaleRecipe(string namescale, int choice)
        {
            string recipeToScale = namescale;

            //if statement that ensures that there is a recipe saved
            if (recipeToScale != null)
            {
                switch (choice)
                {
                    //case 1 scales the recipe to 0.5x
                    case 1:
                        //foreach statement that scales the recipe to 0.5x
                        foreach (Ingredients ingredient in recipeToScale.IngredientList)
                        {
                            ingredient.IngredientQuantity = ingredient.IngredientQuantity / 2;
                            ingredient.IngredientCalories = ingredient.IngredientCalories / 2;

                            //calls the scaler method from the unit converter class
                            //temp methods allow for ingredient object to be a ref
                            float tempIngredientQuantity = ingredient.IngredientQuantity;
                            string tempIngredientMeasurement = ingredient.IngredientMeasurement;

                            UnitConverter.scaler(ref tempIngredientMeasurement, ref tempIngredientQuantity);

                            ingredient.IngredientMeasurement = tempIngredientMeasurement;
                            ingredient.IngredientQuantity = tempIngredientQuantity;
                        }
                        //printRecipe(namescale);
                        break;

                    //case 2 scales the recipe to 2x
                    case 2:
                        //foreach statement that scales the recipe to 2x
                        foreach (Ingredients ingredient in recipeToScale.IngredientList)
                        {
                            ingredient.IngredientQuantity = ingredient.IngredientQuantity * 2;
                            ingredient.IngredientCalories = ingredient.IngredientCalories * 2;

                            //calls the scaler method from the unit converter class
                            //temp methods allow for ingredient object to be a ref
                            float tempIngredientQuantity = ingredient.IngredientQuantity;
                            string tempIngredientMeasurement = ingredient.IngredientMeasurement;

                            UnitConverter.scaler(ref tempIngredientMeasurement, ref tempIngredientQuantity);

                            ingredient.IngredientMeasurement = tempIngredientMeasurement;
                            ingredient.IngredientQuantity = tempIngredientQuantity;
                        }
                        //printRecipe(namescale);
                        break;

                    //case 3 scales the recipe to 3x
                    case 3:
                        //foreach statement that scales the recipe to 3x
                        foreach (Ingredients ingredient in recipeToScale.IngredientList)
                        {
                            ingredient.IngredientQuantity = ingredient.IngredientQuantity * 3;
                            ingredient.IngredientCalories = ingredient.IngredientCalories * 3;

                            //calls the scaler method from the unit converter class
                            //temp methods allow for ingredient object to be a ref
                            float tempIngredientQuantity = ingredient.IngredientQuantity;
                            string tempIngredientMeasurement = ingredient.IngredientMeasurement;

                            UnitConverter.scaler(ref tempIngredientMeasurement, ref tempIngredientQuantity);

                            ingredient.IngredientMeasurement = tempIngredientMeasurement;
                            ingredient.IngredientQuantity = tempIngredientQuantity;
                        }
                        //printRecipe(namescale);
                        break;

                    //case 4 resets the recipe to original values
                    case 4:

                        Console.WriteLine();
                        Console.WriteLine("are you sure you want to reset the recipe to its original values? (y/n)");
                        string answer1 = Console.ReadLine().ToUpper();
                        switch (answer1)
                        {
                            case "Y":

                                //foreach statement that overrides the scaled recipe with the original values
                                foreach (Ingredients ingredient in recipeToScale.IngredientList)
                                {
                                    ingredient.IngredientMeasurement = ingredient.OriginalMeasurement;
                                    ingredient.IngredientQuantity = ingredient.OriginalQuantity;
                                    ingredient.IngredientCalories = ingredient.OriginalCalories;
                                }
                                //printRecipe(namescale);
                                break;

                            case "N":
                                //takes user back to scale recipe menu
                                scaleRecipe(namescale);
                                break;

                            default:
                                Console.WriteLine();
                                //sets background colour to red and displays an error message
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid option, please choose a y or n:");
                                Console.ResetColor();
                                scaleRecipe(namescale);
                                break;
                        }

                        break;
                }
            }
        }
    }
}

//-------------------------------------EOF----------------------------------------\\