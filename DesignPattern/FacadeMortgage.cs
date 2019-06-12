using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{

    /*
      -Facade   (FacadeMortgage)
            knows which subsystem classes are responsible for a request.
            delegates client requests to appropriate subsystem objects.
      -Subsystem classes   (Bank, Credit, Loan)
            implement subsystem functionality.
            handle work assigned by the Facade object.
            have no knowledge of the facade and keep no reference to it.
    */

    /// <summary>
    /// Main class to simulate Facade Mortgage 
    /// (Interface to subsystems: Bank, Credit, Loan)
    /// </summary>
    class FacadeMortgage
    {

        private Bank _bank = new Bank();
        private Loan _loan = new Loan();
        private Credit _credit = new Credit();

        public bool IsEligible(Customer _customer, int amount)
        {
            Console.WriteLine("{0} applies for {1:C} loan\n", _customer.Name, amount);

            bool eligible = true;
            //Check Applicant Status.
            if(!_bank.HasSufficientSavings(_customer,amount))
            {
                eligible = false;
            }
            else if (!_loan.HasNoBadLoans(_customer))
            {
                eligible = false;
            }
            else if (!_credit.HasGoodCredit(_customer))
            {
                eligible = false;
            }


            return eligible;
        }

    }

    /// <summary>
    /// Bank Class
    /// </summary>
    public class Bank
    {
        private readonly int saving=15000;

        public bool HasSufficientSavings(Customer c, int amount)
        {
            Console.WriteLine("Check bank for {0}, and saving of {1:C}!", c.Name, saving);
            return amount <= saving ? true : false;
             
        }
    }

    /// <summary>
    /// Credit Class
    /// </summary>
    public class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine("Check credit for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// Loan Class
    /// </summary>
    public class Loan
    {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine("Check loans for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// Customer Class
    /// </summary>
    public class Customer
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
}

