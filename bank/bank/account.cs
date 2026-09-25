using System.Buffers;

namespace bank
{
    internal class account
    {
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

        public string number
        {
            get;
            private set;
        }
        private static int staccnum = 1000000000;
        public account(string inowner, decimal inbalance)
        {

            Owner = inowner;
            deposit(inbalance, DateTime.UtcNow, "initial balance\n");
            number = staccnum.ToString();
            staccnum++;
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

        public void Withdraw(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Неверный ввод");
            }
            if (amount > balance)
            {
                throw new InvalidOperationException("Недостаточно средств");
            }

            var dep = new transaction(-amount,date, note);
            alltransactions.Add(dep);
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
    }
}
