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

        public ObservableCollection<Expense> Expenses { get => expenseDB.Expenses; set => expenseDB.Expenses = value; }

        public MainWindow()
        {
            InitializeComponent();
            expenseDB = new ExpenseDB();
            expensesList.ItemsSource = Expenses;
        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            AddExpenseView dialog = new AddExpenseView();
            bool? ok = dialog.ShowDialog();
            // shouldn't really do it like this but it's fine for now
            if (ok is bool)
                expenseDB.Expenses.Add(dialog.Expense);
        }

        private void ModifyExpense_Click(object sender, RoutedEventArgs e)
        {
            Expense clickedExpense = null;
            if (sender is Button clickedBtn)
                clickedExpense = clickedBtn.DataContext as Expense;
            else if (sender is MenuItem clickedItem)
                clickedExpense = clickedItem.DataContext as Expense;

            if (clickedExpense is null)
                return;

            int idx = expenseDB.Expenses.IndexOf(clickedExpense);
            AddExpenseView dialog = new AddExpenseView(clickedExpense);
            bool? ok = dialog.ShowDialog();
            // shouldn't really do it like this but it's fine for now
            if (ok is bool)
                expenseDB.Expenses[idx] = dialog.Expense;
        }

        private void RemoveExpense_Click(object sender, RoutedEventArgs e)
        {
            Expense clickedExpense = (sender as MenuItem).DataContext as Expense;
            expenseDB.Expenses.Remove(clickedExpense);
        }
    }
}
