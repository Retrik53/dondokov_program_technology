using System.Security.Principal;

namespace bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            account acc1 = new account("Дондоков Базар", 19547);
            account acc2 = new account("Шмидт Петр", 809);

            Console.WriteLine($"Owner: {acc1.Owner}\nBalance:{acc1.balance}\nNumber:{acc1.number}");
            Console.WriteLine();
            Console.WriteLine($"Owner: {acc2.Owner}\nBalance:{acc2.balance}\nNumber:{acc2.number}");
            Console.WriteLine();

            acc1.deposit(500, DateTime.UtcNow, "niggers");
            Console.WriteLine(acc1.balance);

            acc1.Withdraw(1000, DateTime.UtcNow, "");
            Console.WriteLine(acc1.balance);

            Console.WriteLine(acc1.GetAccountHistory());
            try
            {
                acc2.Withdraw(1000, DateTime.UtcNow, "");
                Console.WriteLine(acc2.balance);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            InterestEarningAccount interestearning = new("Bazar", 3210);
            interestearning.deposit(2000m, DateTime.UtcNow, ":0");
            interestearning.Withdraw(2000m, DateTime.UtcNow, ":0");
            interestearning.PerformMonthAndTransactions();
            Console.WriteLine(interestearning); //== Console.WriteLine(interestearning.ToString);
            Console.WriteLine(interestearning.GetAccountHistory());

            LineOfCreditAccount LineOfCredit = new LineOfCreditAccount("Bazar", 0, 1000m);
            LineOfCredit.Withdraw(500m, DateTime.UtcNow, "credit");

            GiftCardAccount giftcard = new GiftCardAccount("Bazar", 1000m, 5000m);

            List<account> accounts = new List<account>();
            accounts.Add(acc1);
            accounts.Add(acc2);
            accounts.Add(interestearning);
            accounts.Add(LineOfCredit);
            accounts.Add(giftcard);

            foreach (account account in accounts)
            {
                Console.WriteLine(account);
                account.PerformMonthAndTransactions();
                Console.WriteLine(account.GetAccountHistory());
            }

            var acc52 = new account("Дондоков Б.З.", 15_000m,new RegularLevel())
            {
                ServiceLevel = new VIPLevel()
            };

            acc52.Withdraw(2_000m, DateTime.UtcNow, "Покупка");
            acc52.PerformMonthAndTransactions();

            Console.WriteLine(acc52);
            Console.WriteLine(acc52.GetAccountHistory());
        }
    }
}
