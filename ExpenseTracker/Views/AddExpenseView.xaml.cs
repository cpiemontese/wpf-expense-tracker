using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExpenseTracker.Views
{
    /// <summary>
    /// Logica di interazione per AddExpenseView.xaml
    /// </summary>
    public partial class AddExpenseView : Window
    {
        private Expense expense;

        public Expense Expense
        {
            get => expense;
            set => expense = value;
        }


        public AddExpenseView()
        {
            InitializeComponent();
            DataContext = this;
            Expense = new Expense(0.0f, DateTime.Today, "");
        }

        // TODO: add constructor with arguments to modify previous expenses i.e. populate with args

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            // validate Expense before adding it to the db
            Window newWindow = new Window
            {
                Content = Expense.Amount
            };
            newWindow.Show();
        }
    }
}
