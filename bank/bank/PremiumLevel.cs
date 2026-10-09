using System;
using System.Collections.Generic;
using System.Text;

namespace bank
{
    internal class PremiumLevel : Status
    {
        public override decimal InterestRate => 0.01m;
        public override decimal MonthlyFee => 0m;
    }
}
