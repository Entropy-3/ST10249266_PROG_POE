using System;

namespace ST10249266_PROG_POE.Classes
{
    internal class WorkerClass
    {
        private int noIngredients;
        private int noSteps;
        private RecipeClass recipe = new RecipeClass();

        //----------------------------------------\\
        // this is the method that will run all of the code and is called in the main method
        public void startHere()
        {
            //calls method that contains the menu
            menuOptions();
        }

        //----------------------------------------\\
        //method that houses the switch statement for the menu
        private void menuOptions()
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1) Create a recipe");
                Console.WriteLine("2) Print a recipe");
                Console.WriteLine("3) Clear a recipe");
                Console.WriteLine("4) Scale a recipe");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        createRecipe();
                        break;

                    case 2:
                        // Code to print a recipe
                        printRecipe();
                        break;

                    case 3:
                        //method that contains the code to clear a recipe
                        clearRecipe();

                        break;

                    case 4:
                        // Code to scale a recipe

                        break;

                    default:
                        Console.WriteLine("Invalid option, please choose a number between 1 and 4.");
                        startHere();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid option, please choose a number between 1 and 4.");
                startHere();
            }
        }

        //----------------------------------------\\
        //method to create a recipe
        private void createRecipe()
        {
            Console.WriteLine("Hi! Welcome to this recipe builder" +
                "\nPlease Enter the number of different ingridients you want to have");

            //----------------------------------------\\
            //try catch that handles input validation
            try
            {
                //this is the number of ingredients that the user wants to have, converts the input to an integer
                noIngredients = Convert.ToInt32(Console.ReadLine());

                //if the number of ingredients is less than 1, it will ask the user to enter a number above zero
                if (noIngredients < 1)
                {
                    Console.WriteLine("Please enter a number above zero");
                    startHere();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number");
                startHere();
            }

            //for loop that will deal with getting ingridient information from the user
            for (int i = 0; i < noIngredients; i++)
            {
                //creates an object of the Ingredients class
                Ingredients ingredient = new Ingredients();

                //Asks for user input for ingredient name
                Console.WriteLine("Please enter the name of the ingredient");
                string ingredientName = Console.ReadLine();
                ingredient.IngredientName = ingredientName;

                //asks for user input for ingredient quantity
                bool validInput = false;
                //while loop that will keep asking the user for a valid number until they enter one
                while (!validInput)
                {
                    Console.WriteLine("Please enter the quantity of the ingredient");
                    try
                    {
                        float ingredientQuantity = Convert.ToSingle(Console.ReadLine());
                        ingredient.IngredientQuantity = ingredientQuantity;
                        validInput = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                }

                //asks for user input for ingredient measurement
                Console.WriteLine("Please enter the measurement of the ingredient");
                string ingredientMeasurement = Console.ReadLine();
                ingredient.IngredientMeasurement = ingredientMeasurement;

                //adds ingredient to the recipe array list
                recipe.IngredientList.Add(ingredient);
            }

            bool validinput = false;
            //while loop that will keep asking the user for a valid number until they enter one
            while (!validinput)
            {
                Console.WriteLine("Please enter the number of steps you want to have in your recipe");
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
                Console.WriteLine("Please enter the step");
                string step = Console.ReadLine();

                //adds the step to the steps list
                recipe.Steps1.Add(step);
            }
            menuOptions();
        }

        private void clearRecipe()
        {
            Console.WriteLine("doing this will delete the previous recipe, are you sure? (y/n)");

            //accepts user input and capitalises it (ai helped me find .ToUpper())
            string answer = Console.ReadLine().ToUpper();
            switch (answer)
            {
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

                case "N":
                    //takes user back to menu
                    menuOptions();
                    break;

                default:
                    Console.WriteLine("Invalid option, please choose a y or n");
                    clearRecipe();
                    break;
            }
        }

        private void printRecipe()
        {
            if (recipe.IngredientList.Count > 0 && recipe.Steps1.Count > 0)
            {
                Console.WriteLine("------------------------------------------------------");
                foreach (Ingredients ingredient in recipe.IngredientList)
                {
                    int j = 1;
                    Console.WriteLine($"{j}{ingredient.IngredientQuantity} {ingredient.IngredientMeasurement} of {ingredient.IngredientName} ");
                    j = j++;
                }
                Console.WriteLine("------------------------------------------------------");
                for (int k = 0; k < noSteps; k++)
                {
                    Console.WriteLine(k + recipe.Steps1[k]);
                }
            }
            else
            {
                Console.WriteLine("There is currently no recipe saved");
                menuOptions();
            }
        }
    }
}