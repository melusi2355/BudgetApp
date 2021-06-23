using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    public class FinanceWorker
    {
        // Lists declaration

        public static List<HomeLoanExpense> HomeLoanList = new List<HomeLoanExpense>();
        public static List<HomeLoanExpense> expensesDesc;
        public static List<double> vehicleCalc = new List<double>();
        public static List<double> loanCalc = new List<double>();
        public static List<double> expenseCalc = new List<double>();
        public static List<double> savingsCalc = new List<double>();
        public static List<double> savingsFutureValue = new List<double>();
    }
}
