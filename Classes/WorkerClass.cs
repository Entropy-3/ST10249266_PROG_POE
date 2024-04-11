using System;

namespace ST10249266_PROG_POE.Classes
{
    internal class WorkerClass
    {
        private int noIngredients;
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
                Ingredients ingredient = new Ingredients();

                Console.WriteLine("Please enter the name of the ingredient");
                string ingredientName = Console.ReadLine();
                ingredient.IngredientName = ingredientName;

                Console.WriteLine("Please enter the quantity of the ingredient");
                float ingredientQuantity = Convert.ToSingle(Console.ReadLine());
                ingredient.IngredientQuantity = ingredientQuantity;

                Console.WriteLine("Please enter the measurement of the ingredient");
                string ingredientMeasurement = Console.ReadLine();
                ingredient.IngredientMeasurement = ingredientMeasurement;

                recipe.IngredientList.Add(ingredient);
            }
        }
    }
}