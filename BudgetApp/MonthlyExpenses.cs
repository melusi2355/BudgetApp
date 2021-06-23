using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    public class MonthlyExpenses : Expenses
    {
        // Variables 
        private double groceries;
        private double waterAndLights;
        private double travel;
        private double cellPhoneAndTelephone;
        private double otherExpenses;

        public MonthlyExpenses() { }

        // Parent class Constructor
        public MonthlyExpenses(double groceries, double waterAndLights, double travel, double cellPhoneAndTelephone, double otherExpenses)
        {
            this.Groceries = groceries;
            this.WaterAndLights = waterAndLights;
            this.Travel = travel;
            this.CellPhoneAndTelephone = cellPhoneAndTelephone;
            this.OtherExpenses = otherExpenses;
        }

        // Getters and Setters
        [Required]
        public double Groceries { get => groceries; set => groceries = value; }
        [Required]
        public double WaterAndLights { get => waterAndLights; set => waterAndLights = value; }
        [Required]
        public double Travel { get => travel; set => travel = value; }
        [Required]
        public double CellPhoneAndTelephone { get => cellPhoneAndTelephone; set => cellPhoneAndTelephone = value; }
        [Required]
        public double OtherExpenses { get => otherExpenses; set => otherExpenses = value; }

        // Calculating the monthly expenses
        public double getMonthlyExpenses()
        {
            double results = 0;
            results = Groceries + WaterAndLights + Travel + CellPhoneAndTelephone + OtherExpenses;
            return results;
        }
    }
}
