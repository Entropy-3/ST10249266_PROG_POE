using System;

namespace ST10249266_PROG_POE.Classes
{
    internal class WorkerClass
    {
        private int noIngredients;

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

            for (int i = 0; i < noIngredients; i++)
            {
            }
        }
    }
}