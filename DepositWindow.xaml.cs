using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ATM_Application_WPF
{
    /// <summary>
    /// Interaction logic for DepositWindow.xaml
    /// </summary>
    public partial class DepositWindow : Window
    {
        private Account account;

        public DepositWindow(Account selectedAccount)
        {
            InitializeComponent();
            account = selectedAccount;
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(AmountTextBox.Text, out double amount))
            {
                account.InitialBalance += amount;
                account.AddTransaction($"Deposited: {amount}");
                DepositMessage.Text = "Deposit successful!";
            }
            else
            {
                DepositMessage.Text = "Invalid amount. Please try again.";
            }
        }
    }

}
