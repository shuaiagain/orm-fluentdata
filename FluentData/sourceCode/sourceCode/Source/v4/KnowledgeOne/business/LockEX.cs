using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeOne.business
{
    /// <summary>
    /// lock 关键字的使用
    /// </summary>
    public class LockEX
    {
        public void Test()
        {
            Account account = new Account(50);
            var tasks = new Task[3];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() => RandomlyUpdate(account));
            }

            Task.WaitAll(tasks);
        }

        public void RandomlyUpdate(Account account)
        {
            var random = new Random();
            for (int i = 0; i < 5; i++)
            {
                var amount = random.Next(1, 100);
                bool doCredit = random.NextDouble() < 0.5;
                if (doCredit)
                    account.Credit(amount);
                else
                    account.Debit(amount);
            }
        }
    }

    public class Account
    {
        private readonly object _balanceLock = new object();

        private decimal _balance;

        public Account(decimal initialBalance)
        {
            _balance = initialBalance;
        }

        public decimal Debit(decimal amount)
        {
            lock (_balanceLock)
            {
                if (_balance >= amount)
                {
                    Console.WriteLine($"Balance before debt :{_balance,5}");
                    Console.WriteLine($"Amount to remove :{amount,5}");
                    _balance = _balance - amount;
                    Console.WriteLine($"Balance after debt:{_balance,5}\n");

                    return amount;
                }

                return 0;
            }
        }

        public void Credit(decimal amount)
        {
            lock (_balanceLock)
            {
                Console.WriteLine($"Balance before credit :{_balance,5}");
                Console.WriteLine($"Amount to add :{amount,5}");
                _balance += amount;
                Console.WriteLine($"Balance after credit:{_balance,5}\n");
            }
        }
    }
}
