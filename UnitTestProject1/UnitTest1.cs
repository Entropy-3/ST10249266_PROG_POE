using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ST10249266_PROG_POE.Classes;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTotalCaloriesEqual()
        {
            //creates an instance of the RecipeClass
            RecipeClass recipe = new RecipeClass();
            

            //adds ingredients to the ingredient list
            Ingredients ingredient1 = new Ingredients("ingredientName1", 1, "ingredientMeasurement1", "ingredientFoodGroup1", 100); 
            recipe.IngredientList.Add(ingredient1);

            Ingredients ingredient2 = new Ingredients("ingredientName2", 1, "ingredientMeasurement2", "ingredientFoodGroup2", 200);
            recipe.IngredientList.Add(ingredient2);

            Ingredients ingredient3 = new Ingredients("ingredientName3", 1, "ingredientMeasurement3", "ingredientFoodGroup3", 300);
            recipe.IngredientList.Add(ingredient3);

            //calls the totalCalories method
            int result = recipe.totalCalories();

            //asserts that the result is equal to 600
            Assert.AreEqual(600, result);
        }

        [TestMethod]
        public void TestTotalCaloriesNotEqual()
        {
            //creates an instance of the RecipeClass
            RecipeClass recipe = new RecipeClass();


            //adds ingredients to the ingredient list
            Ingredients ingredient1 = new Ingredients("ingredientName1", 1, "ingredientMeasurement1", "ingredientFoodGroup1", 400);
            recipe.IngredientList.Add(ingredient1);

            Ingredients ingredient2 = new Ingredients("ingredientName2", 1, "ingredientMeasurement2", "ingredientFoodGroup2", 20);
            recipe.IngredientList.Add(ingredient2);

            Ingredients ingredient3 = new Ingredients("ingredientName3", 1, "ingredientMeasurement3", "ingredientFoodGroup3", 80);
            recipe.IngredientList.Add(ingredient3);

            //calls the totalCalories method
            int result = recipe.totalCalories();

            //asserts that the result is equal to 600
            Assert.AreNotEqual(700, result);
        }


    }
}