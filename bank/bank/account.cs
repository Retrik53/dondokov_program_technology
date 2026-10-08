using System.Text;

namespace bank
{
    public class account // класс - потомок класса object => можно переопределить виртуальные методы в этом классе
    {
        private readonly decimal _minimumBalance;

        private static int staccnum = 1000000000;

        public string number
        {
            get;
            private set;
        }
        private List<transaction> alltransactions = new List<transaction>();
        public string Owner
        {
            get; private set;
        }
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


        public account(string inowner, decimal inbalance): this(inowner,inbalance, 0)
        {
        }

        public account(string inowner, decimal inbalance, decimal minimumBalance)
        {

            Owner = inowner;
            deposit(inbalance, DateTime.UtcNow, "initial balance\n");
            number = staccnum.ToString();
            staccnum++;
            _minimumBalance = minimumBalance;

            if (inbalance > 0) deposit(inbalance, DateTime.UtcNow, "Initial balance");
        }

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

        public void Withdraw(decimal amount, DateTime date, string note)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

            transaction? overdraftTransaction = CheckWithdrawalLimit(balance - amount < _minimumBalance);

            transaction? withdrawal = new(-amount, date, note);

            alltransactions.Add(withdrawal);
        }

        protected virtual transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn) throw new InvalidOperationException("Not sufficient rubles for this withdrawal");
            else return default;
        }

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
        public virtual void PerformMonthAndTransactions()
        {
            
        }

        //public override string ToString()
        //{
        //    return $"Type: {GetType().Name}\tOwner: {Owner}\t Account Number: {number}\t Balance: {balance}";
        //}

        public override string ToString() => $"Type: {GetType().Name}\tOwner: {Owner}\t Account Number: {number}\t Balance: {balance}";

    }
}
