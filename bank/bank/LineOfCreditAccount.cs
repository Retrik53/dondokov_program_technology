namespace bank
{
    public class LineOfCreditAccount: account
    {
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditlimit): base(name, initialBalance, -creditlimit)
        {

        }
    }
}
