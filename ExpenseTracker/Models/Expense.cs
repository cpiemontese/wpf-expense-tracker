using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        public Expense() : this(0.0f, DateTime.Today, "") { }

        public Expense(float amount, DateTime date, string category) : this(amount, date, category, "") { }

        public Expense(float amount, DateTime date, string category, string description)
        {
            Amount = amount;
            Date = date;
            Category = category;
            Description = description;
        }

        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
