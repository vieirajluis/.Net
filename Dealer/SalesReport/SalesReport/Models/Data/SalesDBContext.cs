using System;
using System.Data.Entity;
using System.Linq;

using SalesReport.Models.Entity;

namespace SalesReport.Models.Data
{
    /// <summary>
    /// Database class to keep Sales information.
    /// </summary>
    public class SalesDBContext:DbContext
    {
        public SalesDBContext()
        : base("name=SalesDBContext")
        {
        }

        public virtual DbSet<Sales> Sales { get; set; }
    }
}