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
            lock (this) { 
                if (this.balance < amount)
                    return false;
                balance -= amount;
                return true;
            }
        }

        public void Deposit(decimal amount) {
            lock (this) { 
                balance += amount;
            }
        }

        public bool Transferir(BanckAccount destinationAccount, decimal amount) {
            // Esto no se puede hacer ya que estamos creando un interbloqueo debido a que la 
            // cuenta this puede bloquear a la cuenta destino y al reves. Eso no puede ocurrir nunca.
            /*lock (this) {
                lock (destinationAccount) {
                    Thread.Sleep(100); // Simula procesamiento...
                    if (this.Withdraw(amount)) {
                        destinationAccount.Deposit(amount);
                        return true;
                    }
                    else
                        return false;
                }
            }*/

            // La forma de solucionar esto es hacer un lock de cada uno de los componentes por separado
            // en el metodo Deposit y Withdraw

            Thread.Sleep(100); // Simula procesamiento...
            if (this.Withdraw(amount))
            {
                destinationAccount.Deposit(amount);
                return true;
            }
            else
                return false;
        }


    

    }
}
