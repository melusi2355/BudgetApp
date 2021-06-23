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
using System.ComponentModel.DataAnnotations;

namespace BudgetApp
{
    /// <summary>
    /// Interaction logic for HomeLoanWindow.xaml
    /// </summary>
    public partial class HomeLoanWindow : Window
    {
        public HomeLoanWindow()
        {
            InitializeComponent();
        }

        // Button used to store the data entered in a list to be accessible throughout the App
        private void btnSaveLoanValues_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string description = txbDescription.Text;
                DateTime dateTime = DateTime.Now;
                double price = Convert.ToDouble(txbPropertyPrice.Text);
                double deposit = Convert.ToDouble(txbTotalDeposit.Text);
                int rate = Convert.ToInt32(txbInterestRate.Text);
                int months = Convert.ToInt32(txbMonths.Text);

                HomeLoanExpense homeLoan = new HomeLoanExpense(description, dateTime, price, deposit, rate, months);

                if (txbDescription.Text != null && txbPropertyPrice.Text != null && txbTotalDeposit.Text != null && txbInterestRate.Text != null && txbMonths.Text != null)
                {
                    MessageBox.Show("Your home calculation will be : R" + homeLoan.LoanCalculation().ToString());
                    FinanceWorker.loanCalc.Add(homeLoan.LoanCalculation());
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Populate all your fields");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
