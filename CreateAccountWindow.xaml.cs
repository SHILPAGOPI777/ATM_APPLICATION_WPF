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
    /// Interaction logic for CreateAccountWindow.xaml
    /// </summary>
    public partial class CreateAccountWindow : Window
    {
        private Bank _bank;
        public CreateAccountWindow(Bank bank)
        {
            InitializeComponent();
            _bank = bank;
        }

        private async void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            string accountName = AccountNameTextBox.Text;
            if (!int.TryParse(AccountNumberTextBox.Text, out int accountNumber) || accountNumber < 100 || accountNumber > 1000)
            {
                CreateAccountMessage.Text = "Invalid account number. Please try again.";
                return;
            }
            else if (_bank.RetrieveAccount(accountNumber) != null)
            {
                CreateAccountMessage.Text = "Account number already exists. Please try another.";
                return;
            }

            if (!double.TryParse(AnnualInterestRateTextBox.Text, out double annualInterestRate) || annualInterestRate >= 3.0)
            {
                CreateAccountMessage.Text = "Invalid interest rate. Please try again.";
                return;
            }

            if (!double.TryParse(InitialBalanceTextBox.Text, out double initialBalance))
            {
                CreateAccountMessage.Text = "Invalid initial balance. Please try again.";
                return;
            }

            Account newAccount = new Account(accountNumber, initialBalance, annualInterestRate, accountName);
            _bank.AddAccount(newAccount);
            CreateAccountMessage.Text = "Account created successfully!";
            await Task.Delay(3000); // Wait for 3 seconds

            // Close the window after delay
            this.Close();
        }
    }
}