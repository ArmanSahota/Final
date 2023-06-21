using ClassLibrary;
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

namespace Final
{
    public partial class AdminWindow : Window
    {
        //sets up the admin page
        public AdminWindow()
        {
            InitializeComponent();
            DisplayUserName();
            LoadComboBox();
            UpdateUser();
        }

       //add user button
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string username = UsernameTxtBox.Text;
            string password = PasswordTxtBox.Text;
            if (NameTextBox.Text != null && NameTextBox.Text != null && PasswordTxtBox.Text != null)
            {
                UserAccount.Role role = (UserAccount.Role)RolesCB.SelectedIndex;
                UserAccount newUser = new UserAccount(name, username, password, role);
                Data.AddUser(newUser);
                DisplayListView.Items.Refresh();
            }
        }

        //load the role combo box
        void LoadComboBox()
        {
            RolesCB.Items.Add("User");
            RolesCB.Items.Add("Admin");
            RolesCB.SelectedIndex = 0;
        }

       //update the users displayed on the displaylistview
        void UpdateUser()
        {
            DisplayListView.ItemsSource = Data.accounts;

        }
        //display the admin logged in's name
        void DisplayUserName()
        {
            CurrentUserTxt.Content = $"Current User: {Data.currentUser.Name}";
        }
    }
}
