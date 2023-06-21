using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;
using ClassLibrary;
using CsvHelper;

namespace Final
{

    public partial class UserWindow : Window
    {
        public static List<Transaction> transactions = new List<Transaction>();
        public UserWindow()
        {
            InitializeComponent();
            DisplayCurrentUser();
            CreateNewFile(Data.UsersTransactions());
            ReadTransactions();
            DisplayUserTransactions();
        }

        
        // create and load file
        private void CreateNewFile(string filePath)
        {
            FileStream tryout = File.OpenWrite(filePath);
            tryout.Close();
            tryout.Dispose();
        }

        void DisplayCurrentUser()
        {
            lblCurrentUser.Content = $"Current User: {Data.currentUser.Name}";
        }
        void DisplayUserTransactions()
        {
            lvUserTransactions.ItemsSource = transactions;
        }
        private void SortNameBtn_Click(object sender, RoutedEventArgs e)
        {
            transactions.Sort();
            UpdateListView();
        }

        private void SortTimeBtn_Click(object sender, RoutedEventArgs e)
        {
            SortTime tst = new SortTime();
            transactions.Sort(tst);
            UpdateListView();
        }

        private void SortPriceBtn_Click(object sender, RoutedEventArgs e)
        {
            SortPrice tsp = new SortPrice();
            transactions.Sort(tsp);
            UpdateListView();
        }

        private void AddItemBtn_Click(object sender, RoutedEventArgs e)
        {
            string itemName = ItemNameTxt.Text;
            string userItemPrice = ItemPriceTxt.Text;
            
            Decimal.TryParse(userItemPrice, out decimal itemPrice);
            transactions.Add(new Transaction(itemName, itemPrice));
            UpdateListView();
        }

        private void SaveCSVBtn_Click(object sender, RoutedEventArgs e)
        {
            string filePath = NewFileTxt.Text + ".csv";
            WriteTransactions(filePath);
        }

        // Updates the listview
        public void UpdateListView()
        {
            lvUserTransactions.Items.Refresh();
        }
        // When called saves transaction list to the users csv
        public void WriteTransactions(string filePath)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {
                // .WriteRecords(list);
                csvWriter.WriteRecords(transactions);
                writer.Flush();
            }
        }

        // Loads the users specific csv
        public void ReadTransactions()
        {
            using (StreamReader sr = new StreamReader(Data.UsersTransactions()))
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                transactions = csv.GetRecords<Transaction>().ToList();
            }
        }
        
        // Saves user list to CSV and closes window

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            WriteTransactions(Data.UsersTransactions());
        }

        private async void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Did you save and are you sure you want to logout?", "Confirmation", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }

        }
    }
}
