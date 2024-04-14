﻿//Nathan Teixiera
//ST10249266
//Group 2
namespace ST10249266_PROG_POE.Classes
{
    internal class Ingredients
    {
        private string ingredientName;
        private float ingredientQuantity;
        private string ingredientMeasurement;

        //getters and setters for the ingredient name, quantity and measurement
        public string IngredientName { get => ingredientName; set => ingredientName = value; }

        public float IngredientQuantity { get => ingredientQuantity; set => ingredientQuantity = value; }
        public string IngredientMeasurement { get => ingredientMeasurement; set => ingredientMeasurement = value; }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //defualt constructor
        public Ingredients()
        {
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //constructor that takes in the ingredient name, quantity and measurement
        public Ingredients(string ingredientName, float ingredientQuantity, string ingredientMeasurement)
        {
            this.ingredientName = ingredientName;
            this.ingredientQuantity = ingredientQuantity;
            this.ingredientMeasurement = ingredientMeasurement;
        }
    }
}
//-------------------------------------EOF----------------------------------------\\