//Nathan Teixiera
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
        private List<RecipeClass> recipes = new List<RecipeClass>();
        private RecipeClass recipe = new RecipeClass();
        private List<object> orignalList = new List<object>();

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
                        createRecipe();
                        break;

                    case 2:
                        Console.WriteLine("Enter the name of the recipe you want to print:");
                        string printname = Console.ReadLine().ToLower().Trim();
                        printRecipe(printname);
                        break;

                    case 3:
                        Console.WriteLine("Enter the name of the recipe you want to clear:");
                        string clearname = Console.ReadLine().ToLower().Trim();
                        clearRecipe(clearname);
                        break;

                    case 4:
                        Console.WriteLine("Enter the name of the recipe you want to scale:");
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
        private void createRecipe()
        {
            Console.WriteLine();
            //prompts the user to enter the name of the recipe
            Console.Write("Hi! Welcome to this recipe builder" +
                "\nPlease enter the name of the recipe you would like to create: ");
            string recipename = Console.ReadLine().ToLower().Trim();
            recipe.RecipeName = recipename;

            Console.WriteLine();
            Console.Write("how many ingredients do you want in the recipe?: ");
            //--------------------------------------------------------------------------------------------------------------------------------------------------\\
            //try catch that handles input validation
            try
            {
                //this is the number of ingredients that the user wants to have, converts the input to an integer
                noIngredients = Convert.ToInt32(Console.ReadLine());

                //if the number of ingredients is less than 1, it will ask the user to enter a number above zero
                if (noIngredients < 1)
                {
                    Console.WriteLine();
                    //sets background colour to red and displays an error message
                    errorColourChanger("Please enter a number above zero");
                    createRecipe();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
                //sets background colour to red and displays an error message
                errorColourChanger("Please enter a valid number");

                createRecipe();
            }

            //for loop that will deal with getting ingridient information from the user
            for (int i = 0; i < noIngredients; i++)
            {
                //creates an object of the Ingredients class
                Ingredients ingredient = new Ingredients();

                Console.WriteLine();
                //Asks for user input for ingredient name
                Console.Write("Please enter the name of the ingredient: ");
                string ingredientName = Console.ReadLine();
                ingredient.IngredientName = ingredientName;

                //asks for user input for ingredient quantity
                bool validInput = false;
                //while loop that will keep asking the user for a valid number until they enter one
                while (!validInput)
                {
                    Console.WriteLine();
                    Console.Write("Please enter the quantity of the ingredient (e.g. 1): ");
                    //try catch that handles input validation
                    try
                    {
                        //converts the user input from a string to a float
                        float ingredientQuantity = Convert.ToSingle(Console.ReadLine());

                        //checks to see if the user input is greater than 0
                        if (ingredientQuantity > 0)
                        {
                            ingredient.IngredientQuantity = ingredientQuantity;
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine();
                            //sets background colour to red and displays an error message
                            errorColourChanger("Please enter a number above zero");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine();
                        //sets background colour to red and displays an error message
                        errorColourChanger("Please enter a valid number");
                    }
                }

                Console.WriteLine();
                //asks for user input for ingredient measurement
                Console.Write("Please enter the measurement of the ingredient (e.g. teaspoon): ");
                string ingredientMeasurement = Console.ReadLine();
                ingredient.IngredientMeasurement = ingredientMeasurement;

                //adds ingredient to the recipe array list
                recipe.IngredientList.Add(ingredient);
            }

            bool validinput = false;
            //while loop that will keep asking the user for a valid number until they enter one(github copilot assisted with while loop)
            while (!validinput)
            {
                Console.WriteLine();
                Console.Write("Please enter the number of steps you want to have in your recipe: ");
                //try catch that handles input validation
                try
                {
                    //converts the input to an integer
                    noSteps = Convert.ToInt32(Console.ReadLine());

                    validinput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    //sets background colour to red and displays an error message
                    errorColourChanger("Please enter a valid number");
                }
            }

            //for loop that will deal with getting the steps from the user
            for (int i = 0; i < noSteps; i++)
            {
                Console.WriteLine();
                Console.Write("Please enter the step: ");

                //takes user input for the step
                string step = Console.ReadLine();

                //adds the step to the steps list
                recipe.Steps1.Add(step);
            }
            recipes.Add(recipe);
            menuOptions();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //method that contains the code to clear a recipe
        private void clearRecipe(string nameclear)
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
                        //// If the recipe was found, clear it
                        //recipeToClear.IngredientList.Clear();
                        //recipeToClear.Steps1.Clear();

                        //resets variables to 0
                        noIngredients = 0;
                        noSteps = 0;

                        recipes.Remove(recipeToClear);

                        Console.WriteLine();
                        Console.WriteLine("The recipe han now been deleted!");

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
        //method that contains the code to print a recipe
        private void printRecipe(string printname)
        {
            RecipeClass recipeToPrint = recipes.Find(recipe => recipe.RecipeName == printname);
            //if statement that ensures that nothing is pringted when there is no recipe saved
            if (recipeToPrint != null)
            {
                Console.WriteLine();
                colourChanger("------------------------------------------------------");
                colourChanger("INGREDIENTS:");

                //foreach statement that prints out the ingredients(github copilot helped me with the foreach statemment)
                int j = 1;
                foreach (Ingredients ingredient in recipeToPrint.IngredientList)
                {
                    //sets the colour of the text to green
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine($"{j}) {ingredient.IngredientQuantity} {ingredient.IngredientMeasurement} of {ingredient.IngredientName} ");
                    j++;
                    Console.ResetColor();
                }
                colourChanger("------------------------------------------------------");

                //sets the colour of the text to magenta
                colourChanger("INSTRUCTIONS:");

                //for statement that prints out the steps for the recipe
                int no = 1;
                for (int k = 0; k < noSteps; k++)
                {
                    //sets the colour of the text to cyan
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Step " + no + ") " + recipeToPrint.Steps1[k]);
                    Console.ResetColor();
                    no++;
                }
                colourChanger("------------------------------------------------------");
                menuOptions();
            }

            //returns user to menu if no recipe is saved
            else
            {
                Console.WriteLine();
                //sets the colour of the text to red and displays an error message
                errorColourChanger("There is currently no recipe saved");
                menuOptions();
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //method that contains the code to scale a recipe
        private void scaleRecipe(string namescale)
        {
            RecipeClass recipeToScale = recipes.Find(recipe => recipe.RecipeName == namescale);

            //if statement that ensures that there is a recipe saved
            if (recipe.IngredientList.Count > 0 && recipe.Steps1.Count > 0)
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
                            //saves the original recipe
                            saveOriginal();

                            //foreach statement that scales the recipe to 0.5x
                            foreach (Ingredients ingredient in recipe.IngredientList)
                            {
                                ingredient.IngredientQuantity = ingredient.IngredientQuantity / 2;
                            }
                            printRecipe(namescale);
                            break;

                        //case 2 scales the recipe to 2x
                        case 2:
                            saveOriginal();

                            //foreach statement that scales the recipe to 2x
                            foreach (Ingredients ingredient in recipe.IngredientList)
                            {
                                ingredient.IngredientQuantity = ingredient.IngredientQuantity * 2;
                            }
                            printRecipe(namescale);
                            break;

                        //case 3 scales the recipe to 3x
                        case 3:
                            saveOriginal();

                            //foreach statement that scales the recipe to 3x
                            foreach (Ingredients ingredient in recipe.IngredientList)
                            {
                                ingredient.IngredientQuantity = ingredient.IngredientQuantity * 3;
                            }
                            printRecipe(namescale);
                            break;

                        //case 4 resets the recipe to original values
                        case 4:
                            if (orignalList.Count == 0)
                            {
                                errorColourChanger("The recipe is already at its original values");
                            }
                            else
                            {
                                Console.WriteLine();
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
                                        printRecipe(namescale);
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
        private void errorColourChanger(string change)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(change);
            Console.ResetColor();
        }
    }
}

//-------------------------------------EOF----------------------------------------\\