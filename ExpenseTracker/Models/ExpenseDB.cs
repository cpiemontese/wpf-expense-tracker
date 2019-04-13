using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class ExpenseDB
    {
        private const int DBSize = 10;
        private ObservableCollection<Expense> expenses;
        private string[] categories = { "health", "self-care", "food", "home", "clothing" };

        public ObservableCollection<Expense> Expenses
        {
            get { return expenses; }
            set { expenses = value; }
        }

        public ExpenseDB()
        {
            Random rng = new Random();
            Expenses = new ObservableCollection<Expense>();
            DateTime start = new DateTime(2000, 1, 1);
            int range = (DateTime.Today - start).Days;
            for (int i = 0; i < DBSize; i++)
            {
                Expenses.Add(
                    new Expense(
                        rng.Next(1, 100),
                        start.AddDays(rng.Next(range)),
                        categories[rng.Next(categories.Length)]
                        )
                    );
            }
        }
    }
}
