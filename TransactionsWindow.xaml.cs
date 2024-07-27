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
    
    public partial class TransactionsWindow : Window // View transaction Window & Actions.
    {
        public TransactionsWindow(Account account)
        {
            InitializeComponent();
            for (int i = 0; i < account.TransactionCount; i++)
            {
                TransactionsListBox.Items.Add(account.Transactions[i]);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close(); //Close Window
        }
    }

}
