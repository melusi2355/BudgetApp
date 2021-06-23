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

namespace BudgetApp
{
    /// <summary>
    /// Interaction logic for VehicleWindow.xaml
    /// </summary>
    public partial class VehicleWindow : Window
    {
        public VehicleWindow()
        {
            InitializeComponent();
        }

        // Button used to store the data entered in a list to be accessible throughout the App
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string description = txbDescription.Text;
                string model = txbModel.Text;
                string make = txbMake.Text;
                double price = Convert.ToDouble(txbVehiclePrice.Text);
                double deposit = Convert.ToDouble(txbVehicleDepo.Text);
                int interest = Convert.ToInt32(txbVehicleIntRate.Text);
                double insurance = Convert.ToDouble(txbInsurancePrem.Text);
                DateTime dateTime = DateTime.Now;

                VehicleExpense vehicle = new VehicleExpense(description, dateTime, model, make, price, deposit, interest, insurance);

                if (txbDescription.Text != null && txbModel.Text != null && txbMake.Text != null && txbVehiclePrice.Text != null && txbVehicleDepo.Text != null && txbVehicleIntRate.Text != null && txbInsurancePrem.Text != null)
                {
                    MessageBox.Show("Your vehicle monthly cost is : R " + vehicle.MonthlyVehicleCost().ToString());
                    FinanceWorker.vehicleCalc.Add(vehicle.MonthlyVehicleCost());

                    this.Close();
                }

                else
                {
                    MessageBox.Show("Populate Fields with correct values");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
