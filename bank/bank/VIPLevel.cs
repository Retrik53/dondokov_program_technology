using System;
using System.Collections.Generic;
using System.Text;

namespace bank
{
    internal class VIPLevel : Status
    {
        public override decimal InterestRate => 0.03m;
        public override decimal MonthlyFee => 0m;
        public override decimal Cashback => 0.05m;
    }
}
