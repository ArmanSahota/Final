using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Text.Json;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace Final
{
    internal class Data
    {
        public static UserAccount currentUser;

        public static List<UserAccount> accounts = new List<UserAccount>();

        public static string userInformation = "users.json";
        static string TransactionExtension = "_transaction.csv";

        
        static Data()
        {
            ReadUsers();
        }

        
        public static string UsersTransactions()
        {
            return currentUser.Name + TransactionExtension;
        }

        //load and save the .json file with usernames and passwords
        public static void Preload()
        {
            accounts.Add(new UserAccount("Jack", "jack", "Pot", 0));
            accounts.Add(new UserAccount("Johnny", "johnny", "Test", (UserAccount.Role)1));
            accounts.Add(new UserAccount("James", "james","LeBron", 0));
            accounts.Add(new UserAccount("Josh", "josh", "Drake", 0));
            accounts.Add(new UserAccount("Jaskaran", "jaskaran", "Jatt", 0));
            SaveUsers();
        } 

        // Add user to accounts and then save to json
        public static void AddUser(UserAccount account)
        {
            accounts.Add(account);
            SaveUsers();
        }

        // Save accounts
        public static void SaveUsers()
        {
            JsonSerializerOptions jso = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonManager = JsonSerializer.Serialize(accounts, jso);

            File.WriteAllText(Data.userInformation, jsonManager);
        }


        // Read the files
        public static void ReadUsers()
        {
            if (File.Exists(userInformation))
            {
                string listFromFile = File.ReadAllText(userInformation);
                accounts = JsonSerializer.Deserialize<List<UserAccount>>(listFromFile);
            }
            else
            {
                // File does not exist, create default user accounts
                Preload();
            }
        }
    }
}
