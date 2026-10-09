using System.Text;

namespace bank
{
    /// <summary>
    /// Базовый банковский счёт: хранит владельца, номер и историю операций.
    /// </summary>
    public class account // класс - потомок класса object => можно переопределить виртуальные методы в этом классе
    {
        /// <summary>Минимально допустимый баланс счёта.</summary>
        private readonly decimal _minimumBalance;

        /// <summary>Счётчик для генерации уникальных номеров счетов.</summary>
        private static int staccnum = 1000000000;

        /// <summary>Уникальный номер счёта.</summary>
        public string number
        {
            get;
            private set;
        }

        /// <summary>Журнал всех операций по счёту.</summary>
        private List<transaction> alltransactions = new List<transaction>();

        /// <summary>ФИО владельца счёта.</summary>
        public string Owner
        {
            get; private set;
        }

        /// <summary>
        /// Текущий баланс счёта, вычисляемый как сумма всех операций.
        /// </summary>
        public decimal balance
        {
            get 
            {
                decimal balance = 0;
                foreach (var transaction in alltransactions) 
                {
                    balance += transaction.Amount;
                }
                return balance;
            }
            private set;
        }

        public Status ServiceLevel { get; set; } = new RegularLevel();


        /// <summary>
        /// Создаёт счёт с нулевым минимальным балансом.
        /// </summary>
        /// <param name="owner">ФИО владельца.</param>
        /// <param name="initialBalance">Начальный баланс счёта.</param>
        public account(string inowner, decimal inbalance): this(inowner,inbalance, 0)
        {
        }
        
        /// <summary>
        /// Создаёт счёт с явно заданным минимально допустимым балансом.
        /// </summary>
        /// <param name="owner">ФИО владельца.</param>
        /// <param name="initialBalance">Начальный баланс счёта.</param>
        /// <param name="minimumBalance">Минимально допустимый баланс (может быть отрицательным для кредитных счетов).</param>
        public account(string inowner, decimal inbalance, decimal minimumBalance, Status serviceLevel)
        {

            Owner = inowner;
            deposit(inbalance, DateTime.UtcNow, "initial balance\n");
            number = staccnum.ToString();
            staccnum++;
            _minimumBalance = minimumBalance;
            ServiceLevel = serviceLevel;

            if (inbalance > 0) deposit(inbalance, DateTime.UtcNow, "Initial balance");
        }

        /// <summary>
        /// Пополняет счёт на указанную сумму.
        /// </summary>
        /// <param name="amount">Сумма пополнения. Должна быть положительной.</param>
        /// <param name="date">Дата операции.</param>
        /// <param name="note">Комментарий к операции.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Бросается, если <paramref name="amount"/> меньше нуля.
        /// </exception>
        public void deposit(decimal  amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Баланс не может быть отрицательным");
            }
            var dep = new transaction(amount, date, note);
            alltransactions.Add(dep);
            Console.WriteLine($"На счет было начислено: {dep.Amount}\nДата:{dep.date}\nСообщение:{dep.note}");
        }

        //public void Withdraw(decimal amount, DateTime date, string note)
        //{
        //    if (amount <= 0)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(amount), "Неверный ввод");
        //    }
        //    if (amount > balance)
        //    {
        //        throw new InvalidOperationException("Недостаточно средств");
        //    }

        //    var dep = new transaction(-amount,date, note);
        //    alltransactions.Add(dep);
        //}


        /// <summary>
        /// Списывает указанную сумму со счёта.
        /// </summary>
        /// <param name="amount">Сумма списания. Должна быть положительной.</param>
        /// <param name="date">Дата операции.</param>
        /// <param name="note">Комментарий к операции.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Бросается, если <paramref name="amount"/> меньше или равен нулю.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Бросается, если после списания баланс опустится ниже минимально допустимого.
        /// </exception>
        public void Withdraw(decimal amount, DateTime date, string note)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

            transaction? overdraftTransaction = CheckWithdrawalLimit(balance - amount < _minimumBalance);

            transaction? withdrawal = new(-amount, date, note);

            alltransactions.Add(withdrawal);
        }

        /// <summary>
        /// Проверяет, допустимо ли списание, приводящее к выходу за минимальный баланс.
        /// </summary>
        /// <param name="isOverdrawn">Истина, если списание превышает минимально допустимый баланс.</param>
        /// <returns>Дополнительная операция (например, комиссия) либо <c>null</c>, если она не нужна.</returns>
        /// <exception cref="InvalidOperationException">
        /// Бросается, если перерасход недопустим для данного типа счёта.
        /// </exception>
        protected virtual transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn) throw new InvalidOperationException("Not sufficient rubles for this withdrawal");
            else return default;
        }

        /// <summary>
        /// Формирует текстовый отчёт по всем операциям счёта.
        /// </summary>
        /// <returns>Многострочная строка с датой, суммой, балансом и комментарием каждой операции.</returns>
        public string GetAccountHistory() 
        {
            var report = new StringBuilder();

            decimal balance = 0;
            report.AppendLine("Data\t\tAmount\tBalance\tNote");
            foreach (var item in alltransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.date.ToShortDateString()}\t" + $"{item.Amount}\t{balance}\t{item.note}");
            }
            return report.ToString();
        }

        //Ключевое слово virtual позволяет в дочернем классе предоставить другую реализацию метода PerformMonthAndTransactions()


        /// <summary>
        /// Выполняет операции, начисляемые в конце месяца.
        /// </summary>
        /// <remarks>
        /// Базовая реализация ничего не делает; переопределяется в наследниках.
        /// </remarks>
        public virtual void PerformMonthAndTransactions()
        {
            
        }

        /// <summary>
        /// Возвращает строковое представление счёта.
        /// </summary>
        /// <returns>Строка с типом, владельцем, номером и балансом счёта.</returns>
        public override string ToString() => $"Type: {GetType().Name}\tOwner: {Owner}\t Account Number: {number}\t Balance: {balance}";

    }
}
