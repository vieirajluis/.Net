using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesReport.Controllers;
using SalesReport.Models.Data;
using SalesReport.Models.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace SalesReport.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTest
    {

        

        [TestMethod()]
        public void SalesTest()
        {
            //Check string.
            Assert.AreEqual("HomeController", "HomeController");
        }

        [TestMethod]
        public void ReturnViewData()
        {
            
            Sales actual = GetSalesById(5136);
            Sales expected = new Sales { DealNumber = 5136 };
            //Assert if a new Sale record exists, and/or is a duplicated key.
            Assert.AreEqual(expected.DealNumber , actual.DealNumber );
        }

        //Function to create a new sales record.
        public Sales GetSalesById(int id)
        {
            SalesReportTest.TestDBContext db = new SalesReportTest.TestDBContext();

            try
            {


                var newData = new Sales
                {
                    DealNumber = id,
                    DealershipName = "Rahima Skinner",
                    CustomerName = "Seven Star Dealership",
                    Vehicle = "2009 Lamborghini Gallardo Carbon Fiber LP-560",
                    Price = decimal.Parse("169.900"),
                    Date = DateTime.Parse("1/14/2018")

                };

                db.Sales.Add(newData);
                db.SaveChanges();

            }
            catch(InvalidOperationException  ex)
            {
                throw ex;
            }
            return db.Set<Sales>().FirstOrDefault(x => x.DealNumber == id);
        }
    }
}