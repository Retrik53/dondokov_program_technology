namespace bank
{
    public abstract class Status
    {
        protected const decimal InterestSum = 10_000m;

        public abstract decimal InterestRate { get; }
        public abstract decimal MonthlyFee { get; }
        public virtual decimal Cashback => 0m;

        public virtual decimal Computeinterest(decimal balance)
        {
            if (balance > InterestSum)
            {
                return (balance - InterestSum) / InterestRate;
            }
            else
            {
                return 0m;
            }
        }
    }
}
