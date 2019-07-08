
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

using SalesReport.Models.Util;

namespace SalesReport.Controllers
{
    public class UploadController : Controller
    {
        private readonly ICSVReader csvReader;

        //Constructor Dependency Injection to instantiate CSVReader.
        public UploadController(ICSVReader _csvReader)
        {
            this.csvReader = _csvReader;
        }

        // POST: Upload/Create
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase FileUpload)
        {
           
            try
            {
                //Check if there is a file.
                if (FileUpload != null && FileUpload.ContentLength > 0)
                {
                    // Check if the file ends with csv extenstion
                    if (FileUpload.FileName.EndsWith(".csv"))
                    {
                        // extract only the fielname
                        var fileName = Path.GetFileName(FileUpload.FileName);
                        // store the file inside of a temporary folder.
                        var path = Path.Combine(Server.MapPath(Constants.FILE_UPLOAD_PATH), fileName);
                        FileUpload.SaveAs(path);

                        //Call CSV reader.
                        csvReader.Reader(path);
                        

                    }
                    else
                        TempData["MessageError"] = "File Format is not Supported";
                }
                else
                    TempData["MessageError"] = "Please Upload a *.csv File";

                // Back to the first view
                return RedirectToAction("Sales", "Home");
            }
            catch (Exception ex)
            {
                TempData["MessageError"] = "Error:" + ex.Message;
                return RedirectToAction("Sales", "Home");
            }
        }

        
    }
}
