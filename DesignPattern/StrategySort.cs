using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{

    /*
      -Strategy  (SortStrategy)
            declares an interface common to all supported algorithms. 
            Context uses this interface to call the algorithm defined by a ConcreteStrategy
     -ConcreteStrategy  (QuickSort, ShellSort, MergeSort)
            implements the algorithm using the Strategy interface
     -Context  (StrategySort)
            is configured with a ConcreteStrategy object
            maintains a reference to a Strategy object
            may define an interface that lets Strategy access its data.
     */

    /// <summary>
    /// Main class to simulate Strategy Sort 
    /// (Sorting strategies: Quicksort, Shellsort, Mergesort)
    /// </summary>
    class StrategySort
    {
        private List<string> _list = new List<string>();
        private SortStrategy _sortstrategy;

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this._sortstrategy = sortstrategy;
        }

        public void Add(string name)
        {
            _list.Add(name);
        }

        public void Sort()
        {
            _sortstrategy.Sort(_list);

            // Iterate over list and display results
            foreach (string name in _list)
            {
                Console.WriteLine(" " + name);
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// The 'Strategy' abstract class
    /// </summary>
    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
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
    /// A 'ConcreteStrategy' class
    /// </summary>
    class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.ShellSort(); not-implemented
            Console.WriteLine("ShellSorted list ");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.MergeSort(); not-implemented
            Console.WriteLine("MergeSorted list ");
        }
    }

}
