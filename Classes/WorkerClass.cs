//Nathan Teixiera
//ST10249266
//Group 2
using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10249266_PROG_POE.Classes
{
    internal class WorkerClass
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
                        createRecipe();
                        break;

                    //case that contains the code to print a recipe
                    case 2:
                        Console.WriteLine("Enter the name of the recipe you want to print:");
                        printRecipeName();
                        string printname = Console.ReadLine().ToLower().Trim();
                        printRecipe(printname);
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
        public void createRecipe()
        {
            RecipeClass recipe = new RecipeClass();
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
                string ingredientName;
                float ingredientQuantity = 0;
                string ingredientMeasurement;
                string ingredientFoodGroup = "";
                int ingredientCalories;

                Console.WriteLine();
                //Asks for user input for ingredient name
                Console.Write("Please enter the name of the ingredient: ");
                ingredientName = Console.ReadLine();

                Console.WriteLine();
                //asks for user input for ingredient measurement
                Console.Write("Please enter the measurement of the ingredient (teaspoon/s, tablespoon/s and cup/s): ");
                ingredientMeasurement = Console.ReadLine().ToLower().Trim();

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
                        float ingredientQuantityTest = Convert.ToSingle(Console.ReadLine());

                        //checks to see if the user input is greater than 0
                        if (ingredientQuantityTest > 0)
                        {
                            ingredientQuantity = ingredientQuantityTest;
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

                //calls the scaler method from the unit converter class
                UnitConverter.scaler(ref ingredientMeasurement, ref ingredientQuantity);

                Console.WriteLine();
                
                //calls the foodGroupSelector method
                foodGroupSelector(ref ingredientFoodGroup);

                Console.WriteLine();
                //asks for user input for the amount of calories in the ingredient
                Console.WriteLine("Please enter the amount of calories contained in the ingredient (e.g. 10):");
                int calories = Convert.ToInt32(Console.ReadLine());
                ingredientCalories = calories;

                //creates the ingredient object
                Ingredients newIngredient = new Ingredients(ingredientName, ingredientQuantity, ingredientMeasurement, ingredientFoodGroup, ingredientCalories);

                //adds ingredient to the recipe array list
                recipe.IngredientList.Add(newIngredient);
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

                    Console.WriteLine($"{j}) {ingredient.IngredientQuantity} {ingredient.IngredientMeasurement} of {ingredient.IngredientName} Calories: {ingredient.IngredientCalories} food group: {ingredient.IngredientFoodGroup}");
                    j++;
                    
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Total Calories: " + recipeToPrint.totalCalories());
                Console.ResetColor();
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
                            printRecipe(namescale);
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
                            printRecipe(namescale);
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
                            printRecipe(namescale);
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
        private void foodGroupSelector(ref string FoodGroup) {
            colourChanger("Choose a food group for the ingredient: ");
            colourChanger("------------------------------------------------------");
            Console.WriteLine("1) Carbohydrates");
            Console.WriteLine("2) Protein");
            Console.WriteLine("3) Dairy");
            Console.WriteLine("4) fruit");
            Console.WriteLine("5) fats");
            colourChanger("------------------------------------------------------");

            bool validinput1 = false;
            while (!validinput1)
            {
                try
                {
                    //takes user input and converts it to an integer
                    int foodGroup = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    //switch statement that assigns the food group to the ingredient
                    switch (foodGroup)
                    {
                        case 1:
                            FoodGroup = "Carbohydrates";
                            validinput1 = true;
                            break;

                        case 2:
                            FoodGroup = "Protein";
                            validinput1 = true;
                            break;

                        case 3:
                            FoodGroup = "Dairy";
                            validinput1 = true;
                            break;

                        case 4:
                            FoodGroup = "Fruit";
                            validinput1 = true;
                            break;

                        case 5:
                            FoodGroup = "Fats";
                            validinput1 = true;
                            break;

                        default:
                            Console.WriteLine();
                            //sets background colour to red and displays an error message
                            errorColourChanger("Invalid option, please choose a number between 1 and 5.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    //sets background colour to red and displays an error message
                    errorColourChanger("Please enter a valid number");

                }
            }
        }
    }
}

//-------------------------------------EOF----------------------------------------\\