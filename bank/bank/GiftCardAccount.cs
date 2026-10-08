namespace bank
{
    public class GiftCardAccount : account
    {
        private readonly decimal _monthlyDeposit = 0m;

        public GiftCardAccount(string name, decimal initialBalance, decimal MonthlyDeposit = 0) : base(name, initialBalance)
        {
            _monthlyDeposit = MonthlyDeposit;
        }

        public override void PerformMonthAndTransactions()
        {
            if (_monthlyDeposit != 0) 
            {
                deposit(_monthlyDeposit, DateTime.UtcNow, "Add monthly deposit");
            }
        }

        public override string ToString() => base.ToString()+$"monthly Deposit: {_monthlyDeposit}";
    }
}
