namespace OOPoldHWzad2
{
    // Interface for common operations
    public interface IAccount
    {
        void Deposit(double amount);
        double CalculateInterest(int numberOfMonths);
    }

    // Customer class - abstract base for Individual and Company
    public abstract class Customer
    {
        public string Name { get; set; }
    }

    // Individual class - inherits from Customer
    public class Individual : Customer
    {
        public Individual(string name)
        {
            Name = name;
        }
    }

    // Company class - inherits from Customer
    public class Company : Customer
    {
        public Company(string name)
        {
            Name = name;
        }
    }

    // Abstract Account class implementing IAccount
    public abstract class Account : IAccount
    {
        public Customer Customer { get; set; }
        public double Balance { get; protected set; }
        public double InterestRate { get; set; }

        public Account(Customer customer, double balance, double interestRate)
        {
            Customer = customer;
            Balance = balance;
            InterestRate = interestRate;
        }

        // Abstract method to calculate interest, to be overridden by subclasses
        public abstract double CalculateInterest(int numberOfMonths);

        public virtual void Deposit(double amount)
        {
            Balance += amount;
        }
    }

    // DepositAccount class - inherits from Account
    public class DepositAccount : Account
    {
        public DepositAccount(Customer customer, double balance, double interestRate)
            : base(customer, balance, interestRate)
        { }

        // Deposit accounts can withdraw and deposit money
        public void Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient funds for withdrawal.");
            }
        }

        // Override interest calculation for DepositAccount
        public override double CalculateInterest(int numberOfMonths)
        {
            if (Balance > 0 && Balance < 1000)
            {
                return 0;  // No interest for balances less than 1000
            }
            return numberOfMonths * InterestRate;
        }
    }

    // LoanAccount class - inherits from Account
    public class LoanAccount : Account
    {
        public LoanAccount(Customer customer, double balance, double interestRate)
            : base(customer, balance, interestRate)
        { }

        // Override interest calculation for LoanAccount
        public override double CalculateInterest(int numberOfMonths)
        {
            if (Customer is Individual && numberOfMonths <= 3)
            {
                return 0;  // No interest for the first 3 months for individuals
            }
            if (Customer is Company && numberOfMonths <= 2)
            {
                return 0;  // No interest for the first 2 months for companies
            }
            return numberOfMonths * InterestRate;
        }
    }

    // MortgageAccount class - inherits from Account
    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, double balance, double interestRate)
            : base(customer, balance, interestRate)
        { }

        // Override interest calculation for MortgageAccount
        public override double CalculateInterest(int numberOfMonths)
        {
            if (Customer is Company && numberOfMonths <= 12)
            {
                return (numberOfMonths * InterestRate) / 2;  // ½ interest for the first 12 months for companies
            }
            if (Customer is Individual && numberOfMonths <= 6)
            {
                return 0;  // No interest for the first 6 months for individuals
            }
            return numberOfMonths * InterestRate;
        }
    }

    // Program class to test the functionality
    public class Program
    {
        public static void Main()
        {
            // Create customers
            Customer individual = new Individual("John Doe");
            Customer company = new Company("Tech Corp");

            // Create different accounts
            Account depositAccount = new DepositAccount(individual, 1500, 0.05);
            Account loanAccount = new LoanAccount(individual, 5000, 0.07);
            Account mortgageAccount = new MortgageAccount(company, 10000, 0.04);

            // Deposit some money into accounts
            depositAccount.Deposit(500);
            loanAccount.Deposit(1000);
            mortgageAccount.Deposit(2000);

            // Test interest calculation for each account
            Console.WriteLine($"Deposit Account Interest for 6 months: {depositAccount.CalculateInterest(6)}");
            Console.WriteLine($"Loan Account Interest for 4 months: {loanAccount.CalculateInterest(4)}");
            Console.WriteLine($"Mortgage Account Interest for 15 months: {mortgageAccount.CalculateInterest(15)}");
        }
    }

}
