using System.Linq;
using System.Web.Mvc;

using SalesReport.Models.Data;


namespace SalesReport.Controllers
{
    public class HomeController : Controller
    {
        private readonly SalesDBContext salesDatabase;

        //Constructor Dependency Injection to instantiate SalesDBContext.
        public HomeController(SalesDBContext _salesDatabase)
        {
            this.salesDatabase = _salesDatabase;
        }


        public ActionResult Index()
        {
            return View();
        }

        //Get Sales
        public ActionResult Sales()
        {
     
            return View(salesDatabase.Sales.ToList());
        }

    }
}