using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Strategy could implement DI and IoC
/// Define a family of algorithms, encapsulate each one, and make them interchangeable.
/// Strategy lets the algorithm vary independently from clients that use it.
/// The classes and objects participating in this pattern are:
/// Strategy(SortStrategy)
///     declares an interface common to all supported algorithms.Context uses this interface to call the algorithm defined by a ConcreteStrategy
/// ConcreteStrategy(QuickSort, ShellSort, MergeSort)
///     implements the algorithm using the Strategy interface
/// Context  (SortedList)
///     is configured with a ConcreteStrategy object
///     maintains a reference to a Strategy object
///     may define an interface that lets Strategy access its data.
/// Reference dofactory.com
/// </summary>
namespace Strategy
{

    /// <summary>
    /// The 'Strategy' abstract class
    /// </summary>
    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    /// <summary>
    /// A 'ConcreteStrategy' class to be injected.
    /// </summary>
    class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort(); // Default is Quicksort

            Console.WriteLine("QuickSorted list ");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class to be injected.
    /// </summary>
    class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort(); // Default is ShellSort

            Console.WriteLine("ShellSorted list ");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class to be injected.
    /// </summary>
    class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort(); // Default is MergeSort

            Console.WriteLine("MergeSorted list ");
        }
    }


    /// <summary>
    /// The 'Context' class to initialize the strategy to be injected. 
    /// </summary>
    class SortedList
    {
        private List<string> _list = new List<string>();
        private SortStrategy _sortstrategy;//Abstract class cannot be instantiated.

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this._sortstrategy = sortstrategy;//Initialization
        }

        public void Add(string name)
        {
            _list.Add(name);
        }

        //Calls the override Sort method from the derived strategies.
        public void Sort()
        {
            _sortstrategy.Sort(_list);//Base:Sort

            // Iterate over list and display results
            foreach (string name in _list)
            {
                Console.WriteLine(" " + name);
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Startup class for Behavioral Strategy Design Pattern.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Context to be sorted follwoing different strategies.
            SortedList studentRecords = new SortedList();
            studentRecords.Add("Luis");
            studentRecords.Add("Paulo");
            studentRecords.Add("Sandra");
            studentRecords.Add("Maria");
            studentRecords.Add("Anna");

            //Initialize the Abstract Strategy instantiating its derived QuickSort Strategy and calls its Sort method.
            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();

            //Initialize the Abstract Strategy instantiating its derived ShellSort Strategy and calls its Sort method.
            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();

            //Initialize the Abstract Strategy instantiating its derived MergeSort Strategy and calls its Sort method.
            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();

            //Wait for user
            Console.ReadKey();

        }
    }
}
