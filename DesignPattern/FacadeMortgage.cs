using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Provide a unified interface to a set of interfaces in a subsystem. 
/// Façade defines a higher-level interface that makes the subsystem easier to use.
/// Provide a unified interface to a set of interfaces in a subsystem. Façade defines a higher-level interface 
/// that makes the subsystem easier to use.
/// The classes and objects participating in this pattern are:
///Facade(MortgageApplication)
///  knows which subsystem classes are responsible for a request.
///  delegates client requests to appropriate subsystem objects.
///Subsystem classes   (Bank, Credit, Loan)
///  implement subsystem functionality.
///  handle work assigned by the Facade object.
///  have no knowledge of the facade and keep no reference to it.
///  Reference dofactory.com
/// </summary>
namespace Facade
{
    //           |          -> Class A
    // Facade -> |Subsystem -> Class B
    //           |          -> Class C

    /// <summary>
    /// The 'Subsystem ClassA' class
    /// </summary>
    class Bank
    {
        public bool HasSufficientSavings(Customer c, int amount)
        {
            Console.WriteLine("Check bank for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// The 'Subsystem ClassB' class
    /// </summary>
    class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine("Check credit for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// The 'Subsystem ClassC' class
    /// </summary>
   class Loan
   {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine("Check loans for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// Customer class
    /// </summary>
    class Customer
    {
        private string _name;

        // Constructor
        public Customer(string name)
        {
            this._name = name;
        }

        // Gets the name
        public string Name
        {
            get { return _name; }
        }
    }

    /// <summary>
    /// The 'Facade' class
    /// High-level Unified Facade Interface. Centralizing the connection of the subsystems.
    /// </summary>
    class Mortgage
    {
        private Bank _bank = new Bank();//Connect to Bank Class 
        private Loan _loan = new Loan();//Connect to Loan Class 
        private Credit _credit = new Credit();//Connect to Credit Class 

        public bool IsEligible(Customer cust, int amount)
        {
            Console.WriteLine("{0} applies for {1:C} loan\n",
              cust.Name, amount);

            bool eligible = true;

            // Check creditworthyness of applicant
            if (!_bank.HasSufficientSavings(cust, amount))
            {
                eligible = false;
            }
            else if (!_loan.HasNoBadLoans(cust))
            {
                eligible = false;
            }
            else if (!_credit.HasGoodCredit(cust))
            {
                eligible = false;
            }

            return eligible;
        }
    }

    /// <summary>
    /// Startup class for Structural Facade Design Pattern.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Facade
            Mortgage morgage = new Mortgage();

            //Evaluate mortgage eligibility for customer.
            Customer customer = new Customer("Luis Vieira");
            //This Facade instance allows to check:
            //If the Bank HasSufficientSavings, if Loan HasNoBadLoans and if Credit HasGoodCredit,
            //using one unified interface.
            bool eligible = morgage.IsEligible(customer, 150000);

            Console.WriteLine("\n" + customer.Name + " has been " + (eligible ? "Approved" : "Rejected"));

            //Wait for user.
            Console.ReadKey();
        }
    }
}
