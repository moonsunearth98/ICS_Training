using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class WithdrawalDeposite_Account
    {
        class Accounts
        {
            private int accountNo;
            private string customerName;
            private string accountType;
            private char transactionType;
            private double balance;

            public Accounts(int accountNo, string customerName, string accountType)
            {
                this.accountNo = accountNo;
                this.customerName = customerName;
                this.accountType = accountType;
                this.balance = 0;
            }

            public char TransactionType
            {
                get { return transactionType; }
                set
                {
                    if (value == 'D' || value == 'W')
                    {
                        transactionType = value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid transaction type. Use 'D' for deposit or 'W' for withdrawal.");
                    }
                }
            }
            public double Amount { get; set; }
            public void Credit()
            {
                if (Amount <= 0)
                {
                    Console.WriteLine("Invalid amount. Amount must be greater than zero.");
                    return;
                }

                balance += Amount;
                Console.WriteLine($"Credited {Amount:C} to the account. New balance: {balance:C}");
            }

            public void Debit()
            {
                if (Amount <= 0)
                {
                    Console.WriteLine("Invalid debit amount. Amount must be greater than zero.");
                    return;
                }
                if (Amount <= balance)
                {
                    balance -= Amount;
                    Console.WriteLine($"Debited {Amount:C} from the account. New balance: {balance:C}");
                }
                else
                {
                    Console.WriteLine("Insufficient balance. Debit transaction failed.");
                }
            }
            public void ShowData()
            {
                Console.WriteLine($"Account No: {accountNo}");
                Console.WriteLine($"Customer Name: {customerName}");
                Console.WriteLine($"Account Type: {accountType}");
                Console.WriteLine($"Transaction Type: {TransactionType}");
                Console.WriteLine($"Balance: {balance:C}");
            }
        }
        class Program
        {
            static void Main()
            {
                Accounts account = new Accounts(27062001, "Prachi Baranwal", "Bob");
                while (true)
                {
                    Console.Write("Enter Transaction Type (D/W) or any other key to exit: ");
                    char transactionType = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();
                    if (transactionType != 'D' && transactionType != 'W')
                    {
                        break;
                    }
                    account.TransactionType = transactionType;
                    Console.Write("Enter Amount: ");
                    double amount;
                    if (!double.TryParse(Console.ReadLine(), out amount))
                    {
                        Console.WriteLine("Invalid amount. Amount must be a valid number.");
                        continue;
                    }
                    account.Amount = amount;
                    if (account.TransactionType == 'D')
                    {
                        account.Credit();
                    }
                    else if (account.TransactionType == 'W')
                    {
                        account.Debit();
                    }
                    account.ShowData();
                }
                Console.WriteLine("Transaction completed :-)");
                Console.ReadLine();
            }
        }
    }
}
