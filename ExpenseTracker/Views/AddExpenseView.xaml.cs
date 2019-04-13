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
        public Expense Expense { get; set; }

        public AddExpenseView() : this(new Expense(0.0f, DateTime.Today, "")) { }

        public AddExpenseView(Expense expenseToModify)
        {
            InitializeComponent();
            DataContext = this;
            Expense = expenseToModify;
        }

        // TODO: add constructor with arguments to modify previous expenses i.e. populate with args

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            amountTB.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            categoryTB.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (!(Validation.GetHasError(amountTB) || Validation.GetHasError(categoryTB)))
            {
                DialogResult = true;
                this.Close();
            }
        }
    }
}
