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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

namespace BudgetApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Binding the combox user item choice
            cmbVehicleChoice.ItemsSource = new List<string> { "Yes", "No" };
        }

        // Method used to enable the text box for the rent amount
        private void radRent_Checked(object sender, RoutedEventArgs e)
        {
            if (radRent.IsChecked == true)
            {
                txbMonthlyRent.IsEnabled = true;
            }
        }
        // Method used to open the homeloan window for the Property purchase
        private void radBuy_Checked(object sender, RoutedEventArgs e)
        {
            if (radBuy.IsChecked == true)
            {
                txbMonthlyRent.IsEnabled = false;

                HomeLoanWindow window = new HomeLoanWindow();
                window.Show();
            }
        }

        // Clearing the UI for new user entries
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txbIncome.Clear();
            txbTaxDeductions.Clear();
            txbGroceries.Clear();
            txbWaterAndLight.Clear();
            txbTravelCosts.Clear();
            txbCellphone.Clear();
            txbOtherExpenses.Clear();
            txbMonthlyRent.Clear();
            radBuy.IsChecked = false;
            radRent.IsChecked = false;
            btnAvailabeCash.IsEnabled = false;
            lbBudgetDetails.Items.Clear();

            //cmbVehicleChoice.SelectedItem.ToString().Equals("");
            // Clear All list values for new entries
            FinanceWorker.HomeLoanList.Clear();
            FinanceWorker.vehicleCalc.Clear();
            FinanceWorker.loanCalc.Clear();
            FinanceWorker.expenseCalc.Clear();
            FinanceWorker.savingsCalc.Clear();
            FinanceWorker.savingsFutureValue.Clear();
        }

        // Method used to calculate the monthly expenditure Value
        public double MonthlyExpenseValue()
        {
            double result = 0;
            try
            {

                double groceries = Convert.ToDouble(txbGroceries.Text);
                double waterAndLights = Convert.ToDouble(txbWaterAndLight.Text);
                double travel = Convert.ToDouble(txbTravelCosts.Text);
                double cellPhoneAndTelephone = Convert.ToDouble(txbCellphone.Text);
                double otherExpenses = Convert.ToDouble(txbOtherExpenses.Text);

                MonthlyExpenses expenses = new MonthlyExpenses(groceries, waterAndLights, travel, cellPhoneAndTelephone, otherExpenses);
                if (txbGroceries.Text != null && txbWaterAndLight.Text != null && txbTravelCosts.Text != null && txbCellphone.Text != null && txbOtherExpenses != null)
                {
                    FinanceWorker.expenseCalc.Add(expenses.getMonthlyExpenses());
                    result = expenses.getMonthlyExpenses();
                }
                else
                {
                    MessageBox.Show("Populate all your fields");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Populate all fields With correct values\n" + ex.Message);
            }
            return result;
        }

        // Retrieving the homeloan value
        public double HomeLoanValue()
        {
            double value = 0;
            foreach (var item in FinanceWorker.loanCalc)
            {
                value = item;
            }
            return value;
        }

        // use this for the calculation of the total expenses
        public double vehicleValue()
        {
            double value = 0;
            foreach (var item in FinanceWorker.vehicleCalc)
            {
                value = item;
            }
            return value;
        }

        // use this for the calculation of the savings calculation
        public double savingAmount()
        {
            double value = 0;
            foreach (var item in FinanceWorker.savingsCalc)
            {
                value = item;
            }
            return value;
        }

        // use this for the calculation of the savings future value calculation
        public double savingFutureValue()
        {
            double value = 0;
            foreach (var item in FinanceWorker.savingsFutureValue)
            {
                value = item;
            }
            return value;
        }


        // This method recieves the user inputs from the user and adds it to a list in memory and performs the calculation
        public void Warning()
        {
            try
            {
                double income = Convert.ToDouble(txbIncome.Text);
                if (HomeLoanValue() > (income / 3))
                {
                    MessageBox.Show("Approval of the home loan is unlikely", "Message", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Please Populate all the homeLoan values before calculating" + "\n" + "OR" + "\n"
                    + "You may have entered an incorrect character in a field", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        // This method recieves user inputs and calculates the available cash based on the user selections
        public void AvailableCash()
        {
            lbBudgetDetails.Items.Clear();
            try
            {
                double result = 0;
                double resultLoan = 0;
                double income = Convert.ToDouble(txbIncome.Text);
                double tax = Convert.ToDouble(txbTaxDeductions.Text);
                double rent = Convert.ToDouble(txbMonthlyRent.Text);


                if (radRent.IsChecked == true && txbIncome.Text != "" && txbTaxDeductions.Text != "" && txbGroceries.Text != "" && txbWaterAndLight.Text != "" && txbTravelCosts.Text != "" && txbCellphone.Text != "" && txbOtherExpenses.Text != "" && txbMonthlyRent.Text != "")
                {
                    // Available cash with rent
                    result = income - (tax + MonthlyExpenseValue() + rent);
                    MessageBox.Show("R" + result.ToString(), "Available Cash", MessageBoxButton.OK, MessageBoxImage.Information);
                    lbBudgetDetails.Items.Add("Income: " + "\t\tR" + income.ToString());
                    lbBudgetDetails.Items.Add("Tax: " + "\t\t\tR" + tax.ToString());
                    lbBudgetDetails.Items.Add("Rent: " + "\t\t\tR" + rent.ToString());
                    lbBudgetDetails.Items.Add("Total Expenses: " + "\tR" + MonthlyExpenseValue().ToString());
                    lbBudgetDetails.Items.Add("Available Cash: " + "\tR" + Math.Round(result, 2).ToString());
                }
                else if (radBuy.IsChecked == true && cmbVehicleChoice.SelectedItem.Equals("No") && txbIncome.Text != "" && txbTaxDeductions.Text != "" && txbGroceries.Text != "" && txbWaterAndLight.Text != "" && txbTravelCosts.Text != "" && txbCellphone.Text != "" && txbOtherExpenses.Text != "")
                {
                    // Available cash with Home loan 
                    resultLoan = income - (tax + MonthlyExpenseValue() + rent + HomeLoanValue());
                    MessageBox.Show("R" + resultLoan.ToString(), "Available Cash", MessageBoxButton.OK, MessageBoxImage.Information);
                    lbBudgetDetails.Items.Add("Income: " + "\t\t\tR" + income.ToString());
                    lbBudgetDetails.Items.Add("Tax: " + "\t\t\t\tR" + tax.ToString());
                    lbBudgetDetails.Items.Add("Total Expenses: " + "\t\tR" + MonthlyExpenseValue().ToString());
                    lbBudgetDetails.Items.Add("Rent: " + "\t\t\t\tR" + rent.ToString());
                    lbBudgetDetails.Items.Add("Monthly Home Debit : " + "\tR" + HomeLoanValue().ToString());
                    lbBudgetDetails.Items.Add("Available Cash: " + "\t\tR" + Math.Round(resultLoan, 2).ToString());
                }
                else if (radBuy.IsChecked == true && cmbVehicleChoice.SelectedItem.Equals("Yes") && txbIncome.Text != "" && txbTaxDeductions.Text != "" && txbGroceries.Text != "" && txbWaterAndLight.Text != "" && txbTravelCosts.Text != "" && txbCellphone.Text != "" && txbOtherExpenses.Text != "")
                {
                    // Available cash with Home loan & Vehicle
                    resultLoan = income - (tax + MonthlyExpenseValue() + rent + vehicleValue() + HomeLoanValue());
                    MessageBox.Show("R" + resultLoan.ToString(), "Available Cash", MessageBoxButton.OK, MessageBoxImage.Information);
                    lbBudgetDetails.Items.Add("Income: " + "\t\t\tR" + income.ToString());
                    lbBudgetDetails.Items.Add("Tax: " + "\t\t\t\tR" + tax.ToString());
                    lbBudgetDetails.Items.Add("Total Expenses: " + "\t\tR" + MonthlyExpenseValue().ToString());
                    lbBudgetDetails.Items.Add("Rent: " + "\t\t\t\tR" + rent.ToString());
                    lbBudgetDetails.Items.Add("Monthly Vehicle Debit: " + "\tR" + vehicleValue().ToString());
                    lbBudgetDetails.Items.Add("Monthly Home Debit : " + "\tR" + HomeLoanValue().ToString());
                    lbBudgetDetails.Items.Add("Available Cash: " + "\t\tR" + Math.Round(resultLoan, 2).ToString());

                }
                else if (radRent.IsChecked == true && cmbVehicleChoice.SelectedItem.Equals("Yes") && txbIncome.Text != "" && txbTaxDeductions.Text != "" && txbGroceries.Text != "" && txbWaterAndLight.Text != "" && txbTravelCosts.Text != "" && txbCellphone.Text != "" && txbOtherExpenses.Text != "")
                {
                    // Available cash with rent & Vehicle
                    result = income - (tax + MonthlyExpenseValue() + rent + vehicleValue());
                    MessageBox.Show("R" + resultLoan.ToString(), "Available Cash", MessageBoxButton.OK, MessageBoxImage.Information);
                    lbBudgetDetails.Items.Add("Income: " + "\t\t\tR" + income.ToString());
                    lbBudgetDetails.Items.Add("Tax: " + "\t\t\t\tR" + tax.ToString());
                    lbBudgetDetails.Items.Add("Total Expenses: " + "\t\tR" + MonthlyExpenseValue().ToString());
                    lbBudgetDetails.Items.Add("Rent: " + "\t\t\t\tR" + rent.ToString());
                    lbBudgetDetails.Items.Add("Monthly Vehicle Debit: " + "\tR" + vehicleValue().ToString());
                    lbBudgetDetails.Items.Add("Available Cash: " + "\t\tR" + Math.Round(result, 2).ToString());

                }
            }
            catch (Exception)
            {
                MessageBox.Show("You have entered an incorrect character in a field, Try again !" + "\n" + "OR" + "\n"
                    + "A required field is Empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        // ComboBox used for user selections
        private void cmbVehicleChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Hiding and displaying windows form components based on the user's selection
            string selectedChoice = cmbVehicleChoice.SelectedItem.ToString();
            if (selectedChoice.Equals("Yes"))
            {
                VehicleWindow window = new VehicleWindow();
                window.Show();
                // Enabling the Calculation button
                btnAvailabeCash.IsEnabled = true;
            }
            else if (selectedChoice.Equals("No"))
            {
                MessageBox.Show("Progress with other calculations");
                // Enabling the Calculation button
                btnAvailabeCash.IsEnabled = true;
            }
        }

        // Calculation button method used to invoke the warning and the available price methods
        private void btnAvailabeCash_Click(object sender, RoutedEventArgs e)
        {
            Warning();
            AvailableCash();

        }

        // This method directs the user to the savings window.
        private void btnSavings_Click(object sender, RoutedEventArgs e)
        {
            SavingsWindow window = new SavingsWindow();
            window.Show();
        }
    }
}
