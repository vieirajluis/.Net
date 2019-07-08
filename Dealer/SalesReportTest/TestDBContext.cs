using System.Data.Entity;


using SalesReport.Models.Entity;

namespace SalesReportTest
{
    //DbContext for test.
    public class TestDBContext:DbContext
    {
        public TestDBContext()
       : base("name=DefaultConnection")//Connecting Sales Database
        {
        }

        public virtual DbSet<Sales> Sales { get; set; }
    }
}
