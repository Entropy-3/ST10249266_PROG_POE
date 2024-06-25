﻿//Nathan Teixiera
//ST10249266
//Group 2
using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10249266_PROG_POE.Classes
{
    public class WorkerClass
    {
        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //variables that will be used in the class
        private int noIngredients;

        private int noSteps;
        private List<RecipeClass> recipes = new List<RecipeClass>();

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //method that houses the switch statement for the menu
        public void menuOptions()
        {
            //try catch to ensure that a null value does not break the code
            try
            {
                Console.WriteLine();
                //outputs the menu options to the user
                colourChanger("------------------------------------------------------");
                colourChanger("MENU");
                colourChanger("------------------------------------------------------");
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1) Create a recipe");
                Console.WriteLine("2) Print a recipe");
                Console.WriteLine("3) Clear a recipe");
                Console.WriteLine("4) Scale a recipe");
                Console.WriteLine("5) Exit");
                colourChanger("------------------------------------------------------");

                //takes user input and converts it to an integer
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    //case that contains the code to create a recipe
                    case 1:
                        
                        break;

                    //case that contains the code to print a recipe
                    case 2:
                        Console.WriteLine("Enter the name of the recipe you want to print:");
                        printRecipeName();
                        string printname = Console.ReadLine().ToLower().Trim();
                        //printRecipe(printname);
                        break;

                    //case that contains the code to clear a recipe
                    case 3:
                        Console.WriteLine("Enter the name of the recipe you want to clear:");
                        printRecipeName();
                        string clearname = Console.ReadLine().ToLower().Trim();
                        clearRecipe(clearname);
                        break;

                    //case that contains the code to scale a recipe
                    case 4:
                        Console.WriteLine("Enter the name of the recipe you want to scale:");
                        printRecipeName();
                        string scalename = Console.ReadLine().ToLower().Trim();
                        scaleRecipe(scalename);
                        break;

                    //case that exits the program
                    case 5:
                        Console.WriteLine();
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);

                        break;

                    default:
                        Console.WriteLine();
                        //sets background colour to red and displays an error message
                        errorColourChanger("Invalid option, please choose a number between 1 and 4.");

                        menuOptions();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                //sets background colour to red and displays an error message
                errorColourChanger("Invalid option, please choose a number between 1 and 4.");

                menuOptions();
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //method to create a recipe
        

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //method that contains the code to clear a recipe
        public void clearRecipe(string nameclear)
        {
            RecipeClass recipeToClear = recipes.Find(recipe => recipe.RecipeName == nameclear);
            if (recipeToClear != null)
            {
                Console.WriteLine();
                Console.Write("doing this will delete the previous recipe, are you sure? (y/n): ");

                //accepts user input and capitalises it (gitgub Copilot helped me find .ToUpper())
                string answer = Console.ReadLine().ToUpper();
                switch (answer)
                {
                    //case that clears the recipe
                    case "Y":
                        recipes.Remove(recipeToClear);

                        Console.WriteLine();
                        Console.WriteLine("The recipe has now been deleted!");

                        //returns user to menu
                        menuOptions();
                        break;

                    //case that takes user back to menu
                    case "N":
                        //takes user back to menu
                        menuOptions();
                        break;

                    default:
                        Console.WriteLine();
                        //sets background colour to red and displays an error message
                        errorColourChanger("Invalid option, please choose a y or n");
                        clearRecipe(nameclear);
                        break;
                }
            }
            else
            {
                Console.WriteLine();
                //sets background colour to red and displays an error message
                errorColourChanger("there is no recipe by that name");
                menuOptions();
            }
        }

      
        


        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //method that contains the code to scale a recipe
        private void scaleRecipe(string namescale)
        {
            RecipeClass recipeToScale = recipes.Find(recipe => recipe.RecipeName == namescale);

            //if statement that ensures that there is a recipe saved
            if (recipeToScale != null)
            {
                Console.WriteLine();
                //prompts user to enter the number of servings they would like to scale the recipe to
                colourChanger("------------------------------------------------------");
                colourChanger("SCALING MENU");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Please enter the number of servings you would like to scale the recipe to:");
                Console.WriteLine("1) 0.5x");
                Console.WriteLine("2) 2x");
                Console.WriteLine("3) 3x");
                Console.WriteLine("4) reset");
                Console.WriteLine("5) back");
                colourChanger("------------------------------------------------------");

                //converts user input from a string to an integer
                int choice = Convert.ToInt32(Console.ReadLine());

                //try catch that handles if a user inputs a null value
                try
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

                        //case 5 takes user back to the menu
                        case 5:
                            menuOptions();
                            break;

                        //default case that prompts the user to enter a valid number
                        default:
                            Console.WriteLine();
                            //sets background colour to red and displays an error message
                            errorColourChanger("Invalid option, please choose a number between 1 and 5.");
                            scaleRecipe(namescale);
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    //sets background colour to red and displays an error message
                    errorColourChanger("Invalid option, please choose a number between 1 and 5.");
                    scaleRecipe(namescale);
                }
            }

            //takes user back to the menu if there is no recipe saved
            else
            {
                Console.WriteLine();
                //sets background colour to red and displays an error message
                errorColourChanger("There is currently no recipe saved");
                menuOptions();
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //changes the colour of a string to blue
        private void colourChanger(string change)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(change);
            Console.ResetColor();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //changes the colour of a string to red
        public void errorColourChanger(string change)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(change);
            Console.ResetColor();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //method that prints the recipe names in alphabetical order
        private void printRecipeName()
        {
            //github copilot helped me with the orderby statement
            var sortedRecipes = recipes.OrderBy(recipe => recipe.RecipeName);
            int j = 1;
            //foreach statement that prints out the recipe names
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine($"{j}): {recipe.RecipeName}");
                j++;
            }
        }
        
        
        

    }
}

//-------------------------------------EOF----------------------------------------\\