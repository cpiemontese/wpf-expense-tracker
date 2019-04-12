using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExpenseTracker.Models;
using ExpenseTracker.Views;

namespace ExpenseTracker
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ExpenseDB expenseDB;

        public List<Expense> Expenses { get => expenseDB.Expenses; set => expenseDB.Expenses = value; }

        public MainWindow()
        {
            InitializeComponent();
            expenseDB = new ExpenseDB();
            expensesList.ItemsSource = Expenses;
        }

        public void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            Window addExpenseWindow = new AddExpenseView();
            addExpenseWindow.Show();
        }
    }
}
