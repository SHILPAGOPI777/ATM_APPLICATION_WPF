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
    
    public partial class SelectAccountWindow : Window //To select Account details
    {
        private Bank _bank;
        public SelectAccountWindow(Bank bank)
        {
            InitializeComponent();
            _bank = bank;
        }

        private void SelectAccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(AccountNumberTextBox.Text, out int accountNumber))
            {
                Account selectedAccount = _bank.RetrieveAccount(accountNumber); //Display selected account
                if (selectedAccount != null)
                {
                    AccountWindow accountWindow = new AccountWindow(selectedAccount);
                    accountWindow.Show();
                    Close();
                }
                else
                {
                    SelectAccountMessage.Text = "Account not found.";
                }
            }
            else
            {
                SelectAccountMessage.Text = "Invalid account number."; // Check for invalid account numbers
            }
        }
    }
   

}
