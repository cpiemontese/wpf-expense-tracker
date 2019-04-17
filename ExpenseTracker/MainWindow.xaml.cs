using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;
using ExpenseTracker.Models;
using ExpenseTracker.Views;
using Microsoft.Win32;

namespace ExpenseTracker
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ExpenseDB expenseDB;
        private string defaultFileName = "";

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
            if (dialog.ShowDialog() == true)
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
            if (dialog.ShowDialog() == true)
                expenseDB.Expenses[idx] = dialog.Expense;
        }

        private void RemoveExpense_Click(object sender, RoutedEventArgs e)
        {
            Expense clickedExpense = (sender as MenuItem).DataContext as Expense;
            expenseDB.Expenses.Remove(clickedExpense);
        }

        private void New_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void New_Executed(object sender, ExecutedRoutedEventArgs e) => AddExpense_Click(sender, e);

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (defaultFileName == "")
                RunSaveFileDialog();
            else
                WriteExpensesToFile(defaultFileName);
        }

        private void SaveAs_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void SaveAs_Executed(object sender, ExecutedRoutedEventArgs e) => RunSaveFileDialog();

        private void RunSaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = "xml",
                AddExtension = true,
                Filter = "Data Files (*.xml)|*.xml"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                WriteExpensesToFile(saveFileDialog.FileName);
                defaultFileName = saveFileDialog.FileName;
            }
        }

        private void WriteExpensesToFile(string fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                XmlSerializer x = new XmlSerializer(Expenses.GetType());
                x.Serialize(file, Expenses);
            }
        }

        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                DefaultExt = "xml",
                AddExtension = true,
                Filter = "Data Files (*.xml)|*.xml"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamReader file = new StreamReader(openFileDialog.FileName))
                {
                    XmlSerializer x = new XmlSerializer(Expenses.GetType());
                    Expenses = x.Deserialize(file) as ObservableCollection<Expense>;
                }
                defaultFileName = openFileDialog.FileName;
            }
        }
    }
}
