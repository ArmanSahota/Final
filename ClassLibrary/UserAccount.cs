using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class UserAccount
    {
        public enum Role { User, Admin }

        string _name;
        string _userName;
        string _password;
        Role _userRole;

        public string Name { get => _name; set => _name = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public Role UserRole { get => _userRole; set => _userRole = value; }

        public UserAccount(string name, string userName, string password, Role userRole)
        {
            _name = name;
            _userName = userName;
            _password = password;
            _userRole = userRole;
        }

        // Default Constructor Required for saving files
        public UserAccount()
        {

        }

        

        // Used for login 
        public bool IsUser(string userName)
        {
            if(_userName == userName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Used for login
        public bool ValidUser(string userName, string password)
        {
            if(_userName == userName && _password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
