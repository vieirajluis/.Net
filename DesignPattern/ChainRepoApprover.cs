using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{

    /*
      -Handler   (ChainRepoApprover)
            defines an interface for handling the requests
            (optional) implements the successor link
      -ConcreteHandler   (Director, VicePresident, President)
            handles requests it is responsible for 
            can access its successor
            if the ConcreteHandler can handle the request, it does so; otherwise it forwards the request to its successor
       -Client   (Program Main)
            initiates the request to a ConcreteHandler object on the chain
     */

    /// <summary>
    /// Main Class to simulate Chain of Resposibility Approver
    /// (Chain of Responsibility: Staff can approve a purchase request or hand it off to a superior.
    /// </summary>
    abstract class ChainRepoApprover
    {
        protected ChainRepoApprover successor;

        public void SetSuccessor(ChainRepoApprover successor)
        {
            this.successor = successor;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }

    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    class Director : ChainRepoApprover
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}, amount of {2:C} ",
                  this.GetType().Name, purchase.Number,purchase.Amount);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    class VicePresident : ChainRepoApprover
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 40000.0)
            {
                Console.WriteLine("{0} approved request# {1}, amount of {2:C} ",
                  this.GetType().Name, purchase.Number, purchase.Amount);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    class President : ChainRepoApprover
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}, amount of {2:C} ",
                  this.GetType().Name, purchase.Number, purchase.Amount);
            }
            else
            {
                Console.WriteLine(
                  "Request# {0}, amount of {1:C} requires an executive meeting!",
                  purchase.Number, purchase.Amount);
            }
        }
    }

    /// <summary>
    /// Class holding request details
    /// </summary>
    class Purchase
    {
        private int _number;
        private double _amount;
        private string _purpose;

        // Constructor
        public Purchase(int number, double amount, string purpose)
        {
            this._number = number;
            this._amount = amount;
            this._purpose = purpose;
        }

        // Gets or sets purchase number
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        // Gets or sets purchase amount
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        // Gets or sets purchase purpose
        public string Purpose
        {
            get { return _purpose; }
            set { _purpose = value; }
        }
    }
}
