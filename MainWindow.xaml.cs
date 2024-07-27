using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATM_Application_WPF
{
   
    public partial class MainWindow : Window
    {
        public static Bank bank = new Bank();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            CreateAccountWindow createAccountWindow = new CreateAccountWindow(bank); //Main window containing create account and select account
            createAccountWindow.Show();
        }

        private void SelectAccountButton_Click(object sender, RoutedEventArgs e)
        {
            SelectAccountWindow selectAccountWindow = new SelectAccountWindow(bank);
            selectAccountWindow.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
    public class Account // created class and adding objects
    {
        public const int MaxTransactions = 100;
        public int TransactionCount { get; set; }
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public double AnnualInterestRate { get; set; }
        public double InitialBalance { get; set; }
        public string[] Transactions { get; set; }

        public Account(int accountNumber, double initialBalance, double annualInterestRate, string accountName = "My Account")
        {
            AccountName = accountName;
            AccountNumber = accountNumber;
            AnnualInterestRate = annualInterestRate;
            InitialBalance = initialBalance;
            Transactions = new string[MaxTransactions];
            Transactions[0] = $"Account created with initial balance: {initialBalance}"; // Creating array of transactions for account
            TransactionCount = 1;
        }

        public void AddTransaction(string transaction)
        {
            if (TransactionCount <= MaxTransactions) // Checking transactions reached maximum limit or not
            {
                Transactions[TransactionCount] = transaction;
                TransactionCount++;
            }
            else
            {
                Console.WriteLine("Transaction limit reached. Cannot add more transactions.");
            }
        }
    }

    public class Bank
    {
        private const int MaxAccounts = 100; // Maximum account limit set to 100
        private int accountCount;
        private Account[] accounts;

        public Bank() // Class bank created
        {
            accounts = new Account[MaxAccounts];
            accountCount = 0;
            CreateDefaultAccounts(); // Default account created and count to be set
        }

        private void CreateDefaultAccounts()
        {
            for (int i = 0; i < 10; i++) // 10 default account is created 
            {
                accounts[accountCount] = new Account(100 + i, 100, 2.5); // account number will start from 100 and increment to 10 accounts 
                accountCount++;
            }
        }

        public void AddAccount(Account newAccount) // To limit maximum account limit to 100
        {
            if (accountCount < MaxAccounts)
            {
                
                accounts[accountCount++] = newAccount;
            }
            else
            {
                Console.WriteLine("Account limit reached. Cannot add more accounts.");
            }
        }

        public Account RetrieveAccount(int accountNumber)
        {
            for (int i = 0; i < accountCount; i++)
            {
                if (accounts[i].AccountNumber == accountNumber)
                {
                    return accounts[i];
                }
            }
            return null;
        }
    }
}