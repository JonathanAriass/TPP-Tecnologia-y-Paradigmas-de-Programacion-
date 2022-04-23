using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TPP.Laboratory.Concurrency.Lab10
{

    public class BanckAccount
	{
        private decimal balance;
        private string accountNumber;

        public BanckAccount(string accountNumber, decimal balance = 0) {
            this.balance = balance;
            this.accountNumber = accountNumber;
        }

        public string AccountNumber { get { return this.accountNumber; } }

        public bool Withdraw(decimal amount) {
            if (this.balance < amount)
                return false;
            balance -= amount;
            return true;
        }

        public void Deposit(decimal amount) {
            balance += amount;
        }

        public bool Transferir(BanckAccount destinationAccount, decimal amount) {
            lock (this) {
                lock (destinationAccount) {
                    Thread.Sleep(100); // Simula procesamiento...
                    if (this.Withdraw(amount)) {
                        destinationAccount.Deposit(amount);
                        return true;
                    }
                    else
                        return false;
                }
            }
        }


    

    }
}
