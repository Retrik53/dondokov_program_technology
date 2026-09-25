using System;
using System.Collections.Generic;
using System.Text;

namespace bank
{
    internal record transaction(decimal Amount, DateTime date, string note)
    {

    }
}
