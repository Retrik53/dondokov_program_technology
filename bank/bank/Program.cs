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

        }
    }
}
