using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SortTime : IComparer<Transaction>
    {
        // Sort Time by ascending
        public int Compare(Transaction x, Transaction y)
        {
            return x.TransactionTime.CompareTo(y.TransactionTime);
        }
    }
}
