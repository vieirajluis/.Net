using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Singleton   (LoadBalancer)
/// defines an Instance operation that lets clients access its unique instance. Instance is a class operation.
/// responsible for creating and maintaining its own unique instance.
/// This structural code demonstrates the Singleton pattern which assures only a single instance (the singleton) of the class can be created.
///Reference dofactory.com
/// </summary>
namespace Singleton
{
    /// <summary>
    /// The Singleton class
    /// </summary>
    class LoadBalancerSingleton
    {
        private static LoadBalancerSingleton _instance;
        private List<string> _servers = new List<string>();
        private Random _random = new Random();
        private static object synckLockObj = new object();//Lock


        //Constructor is protected
        protected LoadBalancerSingleton()//or static Singleton
        {
            //List of available servers
            _servers.Add("ServerI");
            _servers.Add("ServerII");
            _servers.Add("ServerIII");
            _servers.Add("ServerIV");
            _servers.Add("ServerV");
        }

        public static LoadBalancerSingleton Instance()
        {

            //Lazy initialization.
            //Thread safe.
            /*Support multithreaded applications through
             'Double checked locking' pattern which (once
              the instance exists) avoids locking each
              time the method is invoked*/
            lock (synckLockObj)
            {
                if(_instance==null)
                {
                    _instance = new LoadBalancerSingleton();
                }

                return _instance;
            }
        }

        // Simple, but effective random load balancer
        public string Server
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r].ToString();
            }
        }
    }

    /// <summary>
    /// Startup class for Structual Singleton Design Pattern.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Constructor is protected -- cannot be instantiated as new.
            LoadBalancerSingleton b1 = LoadBalancerSingleton.Instance();
            LoadBalancerSingleton b2 = LoadBalancerSingleton.Instance();
            LoadBalancerSingleton b3 = LoadBalancerSingleton.Instance();
            LoadBalancerSingleton b4 = LoadBalancerSingleton.Instance();

            // Same instance?
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            // Load balance 15 server requests
            LoadBalancerSingleton balancer = LoadBalancerSingleton.Instance();
            for (int i = 0; i < 20; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }

            // Wait for user
            Console.ReadKey();
        }
    }
}
