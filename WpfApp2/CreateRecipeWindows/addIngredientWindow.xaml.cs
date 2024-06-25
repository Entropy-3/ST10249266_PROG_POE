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

namespace WpfApp2.CreateRecipeWindows
{
    /// <summary>
    /// Interaction logic for addIngredientWindow.xaml
    /// </summary>
    public partial class addIngredientWindow : Window
    {
        public Ingredients NewIngredient { get; private set; }
        public addIngredientWindow()
        {
            InitializeComponent();
        }
        

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            //validation to see if textboxes are empty
            if (nameTextBox.Text == "" || measurementTextBox.Text == "" || quantityTextBox.Text == "" || caloriesTextBox.Text == "")
            {
                MessageBox.Show("Please fill in all the textboxes");
                return;
            }

            //validation for calories and quantity textbox to ensure that they are a float
            if (!float.TryParse(quantityTextBox.Text, out float quantity) || !int.TryParse(caloriesTextBox.Text, out int calories))
            {
                MessageBox.Show("Please enter a valid number in the quantity and calories textbox");
                return;
            }

            //allows for the unit converter to be used
            string measurement = measurementTextBox.Text;
            UnitConverter.scaler(ref measurement, ref quantity);

            //makes use of the calory delegate
            

            // Create a new ingredient object using information from the textboxes
            Ingredients newIngredient = new Ingredients(nameTextBox.Text, float.Parse(quantityTextBox.Text), measurement, foodGroupComboBox.SelectedItem.ToString(), int.Parse(caloriesTextBox.Text));
            NewIngredient = newIngredient;
            this.Close();
        }
    }
}