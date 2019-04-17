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
        private string[] categories = { "health", "self-care", "food", "home", "clothing" };

        private ObservableCollection<Expense> _expenses;
        public ObservableCollection<Expense> Expenses
        {
            get => _expenses;
            set
            {
                _expenses.Clear();
                foreach (Expense e in value)
                    _expenses.Add(e);
            }
        }


        public ExpenseDB()
        {
            Random rng = new Random();
            _expenses = new ObservableCollection<Expense>();
            DateTime start = new DateTime(2000, 1, 1);
            int range = (DateTime.Today - start).Days;
            for (int i = 0; i < DBSize; i++)
            {
                _expenses.Add(
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
