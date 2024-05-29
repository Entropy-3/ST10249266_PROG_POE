//Nathan Teixiera
//ST10249266
//Group 2
namespace ST10249266_PROG_POE.Classes
{
    public class Ingredients
    {
        private string ingredientName;
        private float ingredientQuantity;
        private float originalQuantity;
        private string ingredientMeasurement;
        private string originalMeasurement;
        private string ingredientFoodGroup;
        private int ingredientCalories;
        private int originalCalories;

        //getters and setters for the ingredient name, quantity and measurement
        public string IngredientName { get => ingredientName; set => ingredientName = value; }

        public float IngredientQuantity { get => ingredientQuantity; set => ingredientQuantity = value; }
        public string IngredientMeasurement { get => ingredientMeasurement; set => ingredientMeasurement = value; }
        public string IngredientFoodGroup { get => ingredientFoodGroup; set => ingredientFoodGroup = value; }
        public int IngredientCalories { get => ingredientCalories; set => ingredientCalories = value; }
        public int OriginalCalories { get => originalCalories; set => originalCalories = value; }
        public string OriginalMeasurement { get => originalMeasurement; set => originalMeasurement = value; }
        public float OriginalQuantity { get => originalQuantity; set => originalQuantity = value; }


        //--------------------------------------------------------------------------------------------------------------------------------------------------\\
        //constructor that takes in the ingredient name, quantity and measurement
        public Ingredients(string ingredientName, float ingredientQuantity, string ingredientMeasurement, string ingredientFoodGroup, int ingredientCalories)
        {
            this.ingredientName = ingredientName;
            this.ingredientQuantity = ingredientQuantity;
            this.OriginalQuantity = ingredientQuantity;
            this.ingredientMeasurement = ingredientMeasurement;
            this.OriginalMeasurement = ingredientMeasurement;
            this.IngredientFoodGroup = ingredientFoodGroup;
            this.IngredientCalories = ingredientCalories;
            this.OriginalCalories = ingredientCalories;
        }
    }
}
//-------------------------------------EOF----------------------------------------\\