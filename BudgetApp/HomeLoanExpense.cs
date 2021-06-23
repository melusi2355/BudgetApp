using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    public class HomeLoanExpense : Expenses
    {
        // Variables 
        private double purchasePriceProperty;
        private double deposit;
        private int interestRate;
        private int noOfMonthly;

        public HomeLoanExpense()
        {

        }

        // HomeLoan class Constructor
        public HomeLoanExpense(string description, DateTime dateTimeCreated, double purchasePriceProperty, double deposit, int interestRate, int noOfMonthly)
             : base(description, dateTimeCreated)
        {
            this.Description = Description;
            this.DateTimeCreated = dateTimeCreated;
            this.PurchasePriceProperty = purchasePriceProperty;
            this.Deposit = deposit;
            this.InterestRate = interestRate;
            this.NoOfMonthly = noOfMonthly;

        }

        // Getters and Setters
        [Required]
        public double PurchasePriceProperty { get => purchasePriceProperty; set => purchasePriceProperty = value; }
        [Required]
        public double Deposit { get => deposit; set => deposit = value; }
        [Required]
        [Range(1, 100, ErrorMessage = "Interst Rate must be between 1 and 100 %")]
        public int InterestRate { get => interestRate; set => interestRate = value; }
        [Required]
        [Range(240, 360, ErrorMessage = "Number of months must be between 240 and 360")]
        public int NoOfMonthly { get => noOfMonthly; set => noOfMonthly = value; }

        // Caculating the loan amount
        public double LoanCalculation()
        {
            double amount = 0;
            double principalAmount = PurchasePriceProperty - Deposit;
            double interest = ((double)InterestRate) / 100;
            int n = NoOfMonthly / 12;
            amount = (principalAmount * (1 + interest * n));
            double loan = amount / NoOfMonthly;
            return Math.Round(loan, 2);
        }

    }
}
