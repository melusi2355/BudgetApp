using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    public class Expenses
    {
        // Parent class variable declaration
        private string description;
        private DateTime dateTimeCreated;

        // Parent class Constructor
        public Expenses(string description, DateTime dateTimeCreated)
        {
            this.description = description;
            this.dateTimeCreated = dateTimeCreated;
        }

        // Parent class Empty Constructor
        public Expenses() { }

        // Properties
        public string Description { get => description; set => description = value; }
        public DateTime DateTimeCreated { get => dateTimeCreated; set => dateTimeCreated = value; }
    }
}
