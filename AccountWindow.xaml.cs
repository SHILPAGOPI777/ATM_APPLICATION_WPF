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
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        private Account account;

        public AccountWindow(Account selectedAccount)
        {
            InitializeComponent();
            account = selectedAccount;
            WelcomeTextBlock.Text = $"Welcome, {account.AccountName}";
        }

        private void CheckBalanceButton_Click(object sender, RoutedEventArgs e)
        {
            ActionMessage.Text = $"Account Balance: {account.InitialBalance}";
            account.AddTransaction($"Checked Balance: {account.InitialBalance}");
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            DepositWindow depositWindow = new DepositWindow(account);
            depositWindow.ShowDialog();
            ActionMessage.Text = "Balance updated!";
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            WithdrawWindow withdrawWindow = new WithdrawWindow(account);
            withdrawWindow.ShowDialog();
            ActionMessage.Text = "Balance updated!";
        }

        private void DisplayTransactionsButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionsWindow transactionsWindow = new TransactionsWindow(account);
            transactionsWindow.ShowDialog();
        }

        private void ExitAccountButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }

}
