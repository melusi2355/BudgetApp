using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp
{
    public class Savings
    {
        // Variables
        private string reason;
        private double amount;
        private DateTime date;
        private int years;
        private int interstRate;

        // Empty Constructor
        public Savings()
        {

        }

        // Savings class Constructor
        public Savings(string reason, double amount, DateTime date, int years, int interstRate)
        {
            this.reason = reason;
            this.amount = amount;
            this.date = date;
            this.years = years;
            this.interstRate = interstRate;
        }

        // Getters and Setters
        [Required]
        public string Reason { get => reason; set => reason = value; }
        [Required]
        public double Amount { get => amount; set => amount = value; }
        [Required]
        public DateTime Date { get => date; set => date = value; }
        [Required]
        public int Years { get => years; set => years = value; }
        [Required]
        [Range(1, 100, ErrorMessage = "Interst Rate must be between 1 and 100 %")]
        public int InterstRate { get => interstRate; set => interstRate = value; }

        // Caculating the monthly savings
        public double MonthlySavings()
        {
            double monthlySaving = 0;
            int months = Years * 12;
            monthlySaving = Amount / months;
            return Math.Round(monthlySaving, 2);
        }

        // Calculating the interests earned on the savings
        public double AmountEarned()
        {
            double savingsValue = 0;
            int n = Years;
            double i = (double)interstRate / (double)100;

            savingsValue = Amount * Math.Pow(1 + i, n);
            return Math.Round(savingsValue, 2);
        }
    }
}
