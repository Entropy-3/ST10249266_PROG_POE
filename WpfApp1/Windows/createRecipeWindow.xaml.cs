using ST10249266_PROG_POE.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.CreateRecipeWindows;


namespace WpfApp1.Windows
{
    /// <summary>
    /// Interaction logic for createRecipeWindow.xaml
    /// </summary>
    public partial class createRecipeWindow : Window
    {
        
        public createRecipeWindow()
        {
            InitializeComponent();

        }

        //List<Ingredients> ingredientList = new List<Ingredients>();

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            
            addIngredientWindow addIngredientWin = new addIngredientWindow();
            var dialogResult = addIngredientWin.ShowDialog(); // ShowDialog makes the window modal and waits for it to close

            if (dialogResult.HasValue && dialogResult.Value)
            {
                Ingredients newIngredient = addIngredientWin.NewIngredient;
                // Now you have the newIngredient object, and you can add it to your list or process it as needed
                //ingredientList.Add(newIngredient);
            }
        }

        private void SubmitRecipe_Click(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
