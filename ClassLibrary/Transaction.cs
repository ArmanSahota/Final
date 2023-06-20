using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Transaction : IComparable<Transaction>
    {
        DateTime _transactionTime;
        string _name;
        decimal _price;
        decimal _tax;
        decimal _total;

        
        public Transaction()
        {

        }

        public Transaction(string name, decimal price)
        {
            _transactionTime = DateTime.Now;
            _name = name;
            _price = price;
            _tax = (decimal).108;
            _total = price + price*_tax;
        }

        public DateTime TransactionTime { get => _transactionTime; }
        public string Name { get => _name; set => _name = value; }
        public decimal Price { get => _price; set => _price = value; }
        public decimal Tax { get => _tax; set => _tax = value; }
        public decimal Total { get => _total; }

       
        public int CompareTo(Transaction other)
        {
            return _name.CompareTo(other._name);
        }
    }
}
