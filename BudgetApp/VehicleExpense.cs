using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    public class VehicleExpense : Expenses
    {
        // Variable declaration
        private string model;
        private string make;
        private double price;
        private double deposit;
        private int interest;
        private double insurance;

        // Variable declaration
        public VehicleExpense(string description, DateTime dateTimeCreated, string model, string make, double price, double deposit, int interest, double insurance)
            : base(description, dateTimeCreated)
        {
            this.Description = Description;
            this.DateTimeCreated = dateTimeCreated;
            this.model = model;
            this.make = make;
            this.price = price;
            this.deposit = deposit;
            this.interest = interest;
            this.insurance = insurance;
        }

        // Variable declaration
        public VehicleExpense() { }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Please enter a model name with a minimum of 2 chararcters and a maximum of 50")]
        public string Model { get => model; set => model = value; }
        [Required]
        public string Make { get => make; set => make = value; }
        [Required]
        public double Price { get => price; set => price = value; }
        [Required]
        public double Deposit { get => deposit; set => deposit = value; }
        [Required]
        [Range(1, 100, ErrorMessage = "Interst Rate must be between 1 and 100 %")]
        public int Interest { get => interest; set => interest = value; }
        [Required]
        public double Insurance { get => insurance; set => insurance = value; }


        // Calculating the monthly cost of buying a vehicle
        public double MonthlyVehicleCost()
        {
            double A = 0;
            double total = 0;
            double P = Price - Deposit;
            double i = ((double)Interest) / 100;
            // Years
            int n = 5;
            A = P * (1 + i * n);
            total = (A / 60) + Insurance;
            return Math.Round(total, 2);
        }

    }
}
