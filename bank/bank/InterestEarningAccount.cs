namespace bank
{
    /// <summary>
    /// Сберегательный счёт с начислением процентов в конце месяца.
    /// </summary>
    public class InterestEarningAccount: account
    {
        /// <summary>
        /// Создаёт сберегательный счёт.
        /// </summary>
        /// <param name="owner">ФИО владельца.</param>
        /// <param name="initialBalance">Начальный баланс счёта.</param>
        public InterestEarningAccount(string name, decimal initialBalance)
            : base(name, initialBalance) { }



        //Ключевое слово virtual позволяет в дочернем классе предоставить другую реализацию метода PerformMonthAndTransactions()

        /// <summary>
        /// Начисляет проценты на текущий баланс по ставке 2% годовых.
        /// </summary>
        public override void PerformMonthAndTransactions()
        {
            decimal interest = balance * 0.02m;
            deposit(interest, DateTime.UtcNow, "Apply month interest");
        }
    }
}

