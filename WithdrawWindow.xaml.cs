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
    /// Interaction logic for WithdrawWindow.xaml
    /// </summary>
    public partial class WithdrawWindow : Window
    {
        private Account account;

        public WithdrawWindow(Account selectedAccount)
        {
            InitializeComponent();
            account = selectedAccount;
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(AmountTextBox.Text, out double amount))
            {
                if (amount <= account.InitialBalance)
                {
                    account.InitialBalance -= amount;
                    account.AddTransaction($"Withdrew: {amount}");
                    WithdrawMessage.Text = "Withdrawal successful!";
                }
                else
                {
                    WithdrawMessage.Text = "Insufficient balance. Please try again.";
                }
            }
            else
            {
                WithdrawMessage.Text = "Invalid amount. Please try again.";
            }
        }
    }

}
