namespace bank
{
    /// <summary>
    /// Кредитный счёт, допускающий отрицательный баланс в пределах кредитного лимита.
    /// </summary>
    public class LineOfCreditAccount: account
    {
        /// <summary>
        /// Создаёт кредитный счёт с указанным лимитом.
        /// </summary>
        /// <param name="owner">ФИО владельца.</param>
        /// <param name="initialBalance">Начальный баланс счёта.</param>
        /// <param name="creditLimit">Кредитный лимит (положительное число).</param>
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditlimit): base(name, initialBalance, -creditlimit)
        {

        }
    }
}
