namespace bank
{
    /// <summary>
    /// Подарочный счёт с возможностью ежемесячного автоматического пополнения.
    /// </summary>
    public class GiftCardAccount : account
    {
        /// <summary>Сумма ежемесячного автоматического пополнения (0 — пополнение отключено).</summary>
        private readonly decimal _monthlyDeposit = 0m;

        /// <summary>
        /// Создаёт подарочный счёт.
        /// </summary>
        /// <param name="owner">ФИО владельца.</param>
        /// <param name="initialBalance">Начальный баланс счёта.</param>
        /// <param name="monthlyDeposit">Сумма ежемесячного пополнения. По умолчанию 0.</param>
        public GiftCardAccount(string name, decimal initialBalance, decimal MonthlyDeposit = 0) : base(name, initialBalance)
        {
            _monthlyDeposit = MonthlyDeposit;
        }

        /// <summary>
        /// Пополняет счёт на сумму, заданную при создании счёта.
        /// </summary>
        public override void PerformMonthAndTransactions()
        {
            if (_monthlyDeposit != 0) 
            {
                deposit(_monthlyDeposit, DateTime.UtcNow, "Add monthly deposit");
            }
        }

        /// <summary>
        /// Возвращает строковое представление подарочного счёта.
        /// </summary>
        /// <returns>Строка базового класса с добавлением суммы ежемесячного пополнения.</returns>
        public override string ToString() => base.ToString()+$"monthly Deposit: {_monthlyDeposit}";
    }
}
