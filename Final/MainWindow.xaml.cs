using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using ClassLibrary;
using CsvHelper;
namespace Final
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Data.Preload();

        }

        private void Loginbtn_Click(object sender, RoutedEventArgs e)
        {
            ValidUser();
        }

        public void ValidUser()
        {
            string userName = UsernameTxt.Text;
            string password = PasswordTxt.Text;


            for (int i = 0; i < Data.accounts.Count; i++)
            {
                if (Data.accounts[i].IsUser(userName))
                {
                    if (Data.accounts[i].ValidUser(userName, password))
                    {

                        Data.currentUser = Data.accounts[i];
                        if (Data.currentUser.UserRole == 0)
                        {
                            UserWindow uw = new UserWindow();
                            uw.Show();
                        }
                        else if (Data.currentUser.UserRole == (UserAccount.Role)1)
                        {
                            AdminWindow aw = new AdminWindow();
                            aw.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid username or password");
                    }
                }
            }
        }

    }
}
