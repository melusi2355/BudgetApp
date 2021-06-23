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
    /// Interaction logic for SavingsWindow.xaml
    /// </summary>
    public partial class SavingsWindow : Window
    {
        public SavingsWindow()
        {
            InitializeComponent();
        }

        // Button used to store the data entered in a list to be accessible throughout the App
        private void btnSaveLoanValues_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string reason = txbReason.Text;
                double amount = Convert.ToDouble(txbAmount.Text);
                DateTime date = Convert.ToDateTime(dtpDate.SelectedDate.Value.Date.ToShortDateString());
                int years = Convert.ToInt32(txbYears.Text);
                int interstRate = Convert.ToInt32(txbInterestRate.Text);

                Savings savings = new Savings(reason, amount, date, years, interstRate);
                if (txbReason.Text != null && txbAmount.Text != null && dtpDate.Text != null && txbYears.Text != null && txbInterestRate.Text != null)
                {
                    MessageBox.Show("Reason : " + savings.Reason + "\n" + "Amount: " + savings.Amount + "\n" + "Date Created : " + savings.Date + "\n"
                        + "Interest Rate: " + savings.InterstRate + " %" + "\n" + "Years : " + savings.Years + "\n" + "You will need to save : R "
                        + savings.MonthlySavings().ToString() + " Every Month to reach your Goal" + "\n"
                     + "Your future value including interest : R " + savings.AmountEarned().ToString());
                    FinanceWorker.savingsCalc.Add(savings.MonthlySavings());
                    FinanceWorker.savingsFutureValue.Add(savings.AmountEarned());

                    this.Close();
                }

                else
                {
                    MessageBox.Show("Populate all the fields with correct values");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
