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
        public AddExpenseView()
        {
            InitializeComponent();
        }

        // TODO: usare il validate del binding
        private void ValidateAmountInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("([0-9]+)(\\.[0-9]*)?");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
