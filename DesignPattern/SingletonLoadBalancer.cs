using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{

    /*
     -Singleton   (SingletonLoadBalancer)
     defines an Instance operation that lets clients access its unique instance. Instance is a class operation.
     responsible for creating and maintaining its own unique instance.
    */

    /// <summary>
    /// The 'Singleton' class
    /// </summary>
    public class SingletonLoadBalancer
    {
        private static SingletonLoadBalancer _instance;
        //Lock synchonization object
        private static object synlock = new object();

        private List<string> _servers = new List<string>();
        private Random _random = new Random();

        protected SingletonLoadBalancer()
        {
            //List of available servers.
            _servers.Add("ServerI");
            _servers.Add("ServerII");
            _servers.Add("ServerIII");
            _servers.Add("ServerIV");
            _servers.Add("ServerV");
        }

       

        public static SingletonLoadBalancer GetLoadBalancer()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (_instance==null)
            {
                lock(synlock)
                {
                    if(_instance==null)
                    {
                        _instance = new SingletonLoadBalancer();
                    }
                }
            }

            return _instance;
        }

        //Random LoadBalancer
        public string Server
        {
            get {
                int r = _random.Next(_servers.Count());
                return _servers[r].ToString();
            }
        }
    }
}




