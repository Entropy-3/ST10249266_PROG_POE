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
            for (int i = 0; i <= noIngredients; i++)
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
            while (!validinput)
            {
                Console.WriteLine("Please enter the number of steps you want to have in your recipe");
                try
                {
                    noSteps = Convert.ToInt32(Console.ReadLine());
                    validinput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }

            for (int i = 0; i <= noSteps; i++)
            {
                Console.WriteLine("Please enter the step");
                string step = Console.ReadLine();
                recipe.Steps1.Add(step);
            }
        }
    }
}