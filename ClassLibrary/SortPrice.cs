﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SortPrice : IComparer<Transaction>
    {
        // Sort by price
        public int Compare(Transaction x, Transaction y)
        {
             return x.Price.CompareTo(y.Price);
        }
    }
}
