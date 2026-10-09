using System;
using System.Collections.Generic;
using System.Text;

namespace bank
{
    internal class RegularLevel : Status
    {
        public override decimal InterestRate => 0m;

        public override decimal MonthlyFee => 50m;
    }
}
