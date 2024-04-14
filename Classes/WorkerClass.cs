﻿//Nathan Teixiera
//ST10249266
//Group 2
using System;
using System.Collections.Generic;

namespace ST10249266_PROG_POE.Classes
{
    internal class WorkerClass
    {
        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //variables that will be used in the class
        private int noIngredients;

        private int noSteps;
        private RecipeClass recipe = new RecipeClass();
        private List<object> orignalList = new List<object>();

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //method that houses the switch statement for the menu
        public void menuOptions()
        {
            //try catch to ensure that a null value does not break the code
            try
            {
                Console.WriteLine("");
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1) Create a recipe");
                Console.WriteLine("2) Print a recipe");
                Console.WriteLine("3) Clear a recipe");
                Console.WriteLine("4) Scale a recipe");
                Console.WriteLine("5) Exit");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    //case that contains the code to create a recipe
                    case 1:
                        createRecipe();
                        break;

                    //case that contains the code to print a recipe
                    case 2:
                        // Code to print a recipe
                        printRecipe();
                        break;

                    //case that contains the code to clear a recipe
                    case 3:
                        //method that contains the code to clear a recipe
                        clearRecipe();

                        break;

                    //case that contains the code to scale a recipe
                    case 4:
                        // Code to scale a recipe
                        scaleRecipe();
                        break;

                    //case that exits the program
                    case 5:
                        break;

                    default:
                        Console.WriteLine("Invalid option, please choose a number between 1 and 4.");
                        menuOptions();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid option, please choose a number between 1 and 4.");
                menuOptions();
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //method to create a recipe
        private void createRecipe()
        {
            Console.WriteLine("Hi! Welcome to this recipe builder" +
                "\nPlease Enter the number of different ingridients you want to have:");

            //--------------------------------------------------------------------------------------------------------------------------------------------------\\
            //try catch that handles input validation
            try
            {
                //this is the number of ingredients that the user wants to have, converts the input to an integer
                noIngredients = Convert.ToInt32(Console.ReadLine());

                //if the number of ingredients is less than 1, it will ask the user to enter a number above zero
                if (noIngredients < 1)
                {
                    Console.WriteLine("Please enter a number above zero");
                    menuOptions();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number");
                menuOptions();
            }

            //for loop that will deal with getting ingridient information from the user
            for (int i = 0; i < noIngredients; i++)
            {
                //creates an object of the Ingredients class
                Ingredients ingredient = new Ingredients();

                //Asks for user input for ingredient name
                Console.WriteLine("Please enter the name of the ingredient:");
                string ingredientName = Console.ReadLine();
                ingredient.IngredientName = ingredientName;

                //asks for user input for ingredient quantity
                bool validInput = false;
                //while loop that will keep asking the user for a valid number until they enter one
                while (!validInput)
                {
                    Console.WriteLine("Please enter the quantity of the ingredient (e.g. 1):");
                    //try catch that handles input validation
                    try
                    {
                        float ingredientQuantity = Convert.ToSingle(Console.ReadLine());
                        if (ingredientQuantity > 0)
                        {
                            ingredient.IngredientQuantity = ingredientQuantity;
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("please enter a number higher than 0.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                }

                //asks for user input for ingredient measurement
                Console.WriteLine("Please enter the measurement of the ingredient (e.g. teaspoon):");
                string ingredientMeasurement = Console.ReadLine();
                ingredient.IngredientMeasurement = ingredientMeasurement;

                //adds ingredient to the recipe array list
                recipe.IngredientList.Add(ingredient);
            }

            bool validinput = false;
            //while loop that will keep asking the user for a valid number until they enter one(github copilot assisted with while loop)
            while (!validinput)
            {
                Console.WriteLine("Please enter the number of steps you want to have in your recipe:");
                //try catch that handles input validation
                try
                {
                    //converts the input to an integer
                    noSteps = Convert.ToInt32(Console.ReadLine());

                    validinput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }

            //for loop that will deal with getting the steps from the user
            for (int i = 0; i < noSteps; i++)
            {
                Console.WriteLine("Please enter the step:");
                string step = Console.ReadLine();

                //adds the step to the steps list
                recipe.Steps1.Add(step);
            }
            menuOptions();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //method that contains the code to clear a recipe
        private void clearRecipe()
        {
            if (recipe.IngredientList.Count > 0 && recipe.Steps1.Count > 0)
            {
                Console.WriteLine("doing this will delete the previous recipe, are you sure? (y/n):");

                //accepts user input and capitalises it (gitgub Copilot helped me find .ToUpper())
                string answer = Console.ReadLine().ToUpper();
                switch (answer)
                {
                    //case that clears the recipe
                    case "Y":
                        //clears the ingredients array
                        recipe.IngredientList.Clear();

                        //clears the steps array
                        recipe.Steps1.Clear();

                        //resets variables to 0
                        noIngredients = 0;
                        noSteps = 0;

                        Console.WriteLine("The recipe han now been deleted!");

                        menuOptions();
                        break;

                    //case that takes user back to menu
                    case "N":
                        //takes user back to menu
                        menuOptions();
                        break;

                    default:
                        Console.WriteLine("Invalid option, please choose a y or n:");
                        clearRecipe();
                        break;
                }
            }
            else
            {
                Console.WriteLine("there is no recipe to clear");
                menuOptions();
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //method that contains the code to print a recipe
        private void printRecipe()
        {   //if statement that ensures that nothing is pringted when there is no recipe saved
            if (recipe.IngredientList.Count > 0 && recipe.Steps1.Count > 0)
            {
                Console.WriteLine("------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("INGREDIENTS:");
                Console.ResetColor();

                //foreach statement that prints out the ingredients(github copilot helped me with the foreach statemment)
                int j = 1;
                foreach (Ingredients ingredient in recipe.IngredientList)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine($"{j}){ingredient.IngredientQuantity} {ingredient.IngredientMeasurement} of {ingredient.IngredientName} ");
                    j++;
                    Console.ResetColor();
                }
                Console.WriteLine("------------------------------------------------------");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("INSTRUCTIONS:");
                Console.ResetColor();

                //for statement that prints out the steps for the recipe
                int no = 1;
                for (int k = 0; k < noSteps; k++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(no + ")" + recipe.Steps1[k]);
                    Console.ResetColor();
                    no++;
                }
                Console.WriteLine("------------------------------------------------------");
                menuOptions();
            }

            //returns user to menu if no recipe is saved
            else
            {
                Console.WriteLine("There is currently no recipe saved");
                menuOptions();
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //method that contains the code to scale a recipe
        private void scaleRecipe()
        {
            //if statement that ensures that there is a recipe saved
            if (recipe.IngredientList.Count > 0 && recipe.Steps1.Count > 0)
            {
                //prompts user to enter the number of servings they would like to scale the recipe to
                Console.WriteLine("Please enter the number of servings you would like to scale the recipe to:");
                Console.WriteLine("1) 0.5x");
                Console.WriteLine("2) 2x");
                Console.WriteLine("3) 3x");
                Console.WriteLine("4) reset");
                Console.WriteLine("5) back");

                int choice = Convert.ToInt32(Console.ReadLine());

                //try catch that handles if a user inputs a null value
                try
                {
                    switch (choice)
                    {
                        //case 1 scales the recipe to 0.5x
                        case 1:
                            saveOriginal();
                            //foreach statement that scales the recipe to 0.5x
                            foreach (Ingredients ingredient in recipe.IngredientList)
                            {
                                ingredient.IngredientQuantity = ingredient.IngredientQuantity / 2;
                            }
                            printRecipe();
                            break;

                        //case 2 scales the recipe to 2x
                        case 2:
                            saveOriginal();
                            //foreach statement that scales the recipe to 2x
                            foreach (Ingredients ingredient in recipe.IngredientList)
                            {
                                ingredient.IngredientQuantity = ingredient.IngredientQuantity * 2;
                            }
                            printRecipe();
                            break;

                        //case 3 scales the recipe to 3x
                        case 3:
                            saveOriginal();
                            //foreach statement that scales the recipe to 3x
                            foreach (Ingredients ingredient in recipe.IngredientList)
                            {
                                ingredient.IngredientQuantity = ingredient.IngredientQuantity * 3;
                            }
                            printRecipe();
                            break;

                        //case 4 resets the recipe to original values
                        case 4:
                            if (orignalList.Count == 0)
                            {
                                Console.WriteLine("The recipe is already at its original values");
                                scaleRecipe();
                            }
                            else
                            {
                                Console.WriteLine("are you sure you want to reset the recipe to its original values? (y/n)");
                                string answer1 = Console.ReadLine().ToUpper();
                                switch (answer1)
                                {
                                    case "Y":
                                        int no = 0;
                                        //foreach statement that overrides the scaled recipe with the original values
                                        foreach (Ingredients ingredient in recipe.IngredientList)
                                        {
                                            Ingredients originalIngredient = (Ingredients)orignalList[no];
                                            ingredient.IngredientQuantity = originalIngredient.IngredientQuantity;
                                            no++;
                                        }
                                        printRecipe();
                                        break;

                                    case "N":
                                        //takes user back to menu
                                        scaleRecipe();
                                        break;

                                    default:
                                        Console.WriteLine("Invalid option, please choose a y or n:");
                                        scaleRecipe();
                                        break;
                                }
                            }
                            break;

                        //case 5 takes user back to the menu
                        case 5:
                            menuOptions();
                            break;

                        //default case that prompts the user to enter a valid number
                        default:
                            Console.WriteLine("Invalid option, please choose a number between 1 and 3.");
                            scaleRecipe();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid option, please choose a number between 1 and 3.");
                    scaleRecipe();
                }
            }

            //takes user back to the menu if there is no recipe saved
            else
            {
                Console.WriteLine("There is currently no recipe saved");
                menuOptions();
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //method that saves the original recipe
        private void saveOriginal()
        {
            //foreach statement that creates a copy of the ingredient list
            foreach (Ingredients ingredient in recipe.IngredientList)
            {
                //creates a local instance of ingredients that wont get overriden when scaling the recipe
                //github copilot helped me with the local instance of ingredients
                Ingredients copy = new Ingredients
                {
                    IngredientQuantity = ingredient.IngredientQuantity,
                };
                orignalList.Add(copy);
            }
        }
    }
}

//-------------------------------------EOF----------------------------------------\\