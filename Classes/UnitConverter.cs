﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10249266_PROG_POE.Classes
{
    internal class UnitConverter
    {
        private const int TablespoonsInCup = 16;
        private const int TeaspoonsInCup = 48;
        private const int TeasponnsInTablespoon = 3;

        // Method to convert the ingredient measurement to the smallest unit of measurement
        //copilot helped me understand ref and what it does
        public static void scaler(ref string ingredientMeasurement, ref float ingredientQuantity)
        {
            switch (ingredientMeasurement)
            {
                case "tablespoon":
                    if (ingredientQuantity >= TablespoonsInCup)
                    {
                        ingredientMeasurement = "cup";
                        ingredientQuantity /= TablespoonsInCup;
                    }
                    break;
                case "teaspoon":
                    if (ingredientQuantity >= TeaspoonsInCup)
                    {
                        ingredientMeasurement = "cup";
                        ingredientQuantity /= TeaspoonsInCup;
                    }
                    if (ingredientQuantity >= TeasponnsInTablespoon)
                    {
                        ingredientMeasurement = "tablespoon";
                        ingredientQuantity /= TeasponnsInTablespoon;
                    }
                    break;
                case "cup":
                    if (ingredientQuantity > 1)
                    {
                        ingredientMeasurement = "tablespoon";
                        ingredientQuantity *= TablespoonsInCup;
                    }
                    break;
            }
        }
    }
}
