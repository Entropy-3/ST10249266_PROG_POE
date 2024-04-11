using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10249266_PROG_POE.Classes
{
    internal class RecipeClass
    {
        //list that will hold the ingredient object
        private List<object> ingredientList = new List<object>();

        //getter and setter for the ingredient list
        public List<object> IngredientList { get => ingredientList; set => ingredientList = value; }

        //----------------------------------------\\
        //list that will hold the steps for the recipe
        private List<string> Steps = new List<string>();

        //getter and setter for the steps list
        public List<string> Steps1 { get => Steps; set => Steps = value; }
    }
}