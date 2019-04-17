using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        private float amount;
        private DateTime date;
        private string category;
        private string description = "";

        public Expense(float amount, DateTime date, string category)
        {
            Amount = amount;
            Date = date;
            Category = category;
        }

        public Expense(float amount, DateTime date, string category, string description)
        {
            Amount = amount;
            Date = date;
            Category = category;
            Description = description;
        }

        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
