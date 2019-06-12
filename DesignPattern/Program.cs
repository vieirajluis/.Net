using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            //Singleton
            SingletonLoadBalancer b1 = SingletonLoadBalancer.GetLoadBalancer();
            SingletonLoadBalancer b2 = SingletonLoadBalancer.GetLoadBalancer();
            SingletonLoadBalancer b3 = SingletonLoadBalancer.GetLoadBalancer();
            SingletonLoadBalancer b4 = SingletonLoadBalancer.GetLoadBalancer();

            if (b1==b2 && b2==b3 && b3==b4)
            {
                Console.WriteLine("Same instance\n");
            }

            //Load balance (e.g. 15th) server requests. 
            SingletonLoadBalancer balancer = SingletonLoadBalancer.GetLoadBalancer();
            for(int i=0;i<15;i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Request to: " + server);
            }
            Console.WriteLine("\n");

            //Facade
            FacadeMortgage mortgage = new FacadeMortgage();
            Customer customer = new Customer("Luis Vieira");
            bool eligible = mortgage.IsEligible(customer, 30000);

            Console.WriteLine("\n" + customer.Name + " has been " + (eligible ? "Approved" : "Rejected"));
            Console.WriteLine("\n");

            //Strategy
            StrategySort studentRecords = new StrategySort();

            studentRecords.Add("Samual");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Vivek");
            studentRecords.Add("Anna");

            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();
            Console.WriteLine("\n");

            //Chain of Responsibility
            ChainRepoApprover anna = new Director();
            ChainRepoApprover paul = new VicePresident();
            ChainRepoApprover bella = new President();
            anna.SetSuccessor(paul);
            paul.SetSuccessor(bella);

            // Generate and process purchase requests
            Purchase p = new Purchase(2034, 350.00, "Assets");
            anna.ProcessRequest(p);

            p = new Purchase(2035, 32590.10, "Project X");
            anna.ProcessRequest(p);

            p = new Purchase(2036, 42590.10, "Project Y");
            anna.ProcessRequest(p);

            p = new Purchase(2037, 122100.00, "Project Z");
            anna.ProcessRequest(p);
            Console.WriteLine("\n");

            //Factory Method
            //Note: constructors call Factory Method
            FactoryDocument[] documents = new FactoryDocument[2];
            documents[0] = new Resume();
            documents[1] = new Report();

            // Display document pages
            foreach (FactoryDocument document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");
                foreach (Page page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                }
            }

            Console.WriteLine("\n");

            //Abstract Factory Method
            AbstractFactoryProfile university = new University();
            Community comm = new Community(university);
            comm.RunActivities();

            AbstractFactoryProfile hgSchool = new HighSchool();
            comm = new Community(hgSchool);
            comm.RunActivities();

            AbstractFactoryProfile hospital = new Hospital();
            comm = new Community(hospital);
            comm.RunActivities();

            Console.ReadKey();

        }
    }
}
