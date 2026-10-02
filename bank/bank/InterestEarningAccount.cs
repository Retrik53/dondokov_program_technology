using System;
using System.Collections.Generic;
using System.Text;

namespace bank
{
    internal class InterestEarningAccount: account
    {
        public InterestEarningAccount(string name, decimal initialBalance) 
            : base(name, initialBalance) 
        { 
        
        }


        //Ключевое слово virtual позволяет в дочернем классе предоставить другую реализацию метода PerformMonthAndTransactions()
        public override void PerformMonthAndTransactions()
        {
            decimal interest = balance * 0.02m;
            deposit(interest, DateTime.UtcNow, "Apply month interest");
        }
    }
}

