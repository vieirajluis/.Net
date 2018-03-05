
//=================================================================================
// Program:   Ontario Gabinet Ministers
// Dissemination of this information or reproduction of this material is strictly
// forbidden unless prior written permission is obtained from TELOIP/Luis Vieira
//
// This software is distributed WITHOUT ANY WARRANTY; without even
// the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
//
//================================================================================/
// Class:   HomeController (Used to prepare the GabinetModel that will be mapped to a 
// GabinetView to show the list of The Ontario Gabinet Monisters.
// Objective: Supports the Generation and Validation of Ontario Gabinet Ministers Pages. 
// Author  Luis Vieira
// Date	   2018-03-02
// (url:joaolsvieira@gmail.com)
//================================================================================/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OntarioGabinet.Models;

namespace OntarioGabinet.Controllers
{
    /// <summary>
    /// Controller that will be used to return the Gabinet View for our application,
    /// to read and parse Ontario Gabinet Ministers Web Page.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Returns the Home Page View.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns the About Page View.
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            ViewData["Message"] = ConstantsModel.aboutTitle;

            return View();
        }

        /// <summary>
        /// Return the Gabinet Page View.
        /// </summary>
        /// <returns></returns>
        public IActionResult Gabinet()
        {
            ViewData["Title"] = ConstantsModel.gabinetTitle;
            //Instantiate the Gabinet Model.
            GabinetModel gabmodel = new GabinetModel();
            try
            {
                //Gabinet Web Page Parser.
                gabmodel.GetHtmlGabinet();
                
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError("Error", ConstantsModel.errorMessageGabinetModel + ex.Message);
                
            }
                      

            return View(gabmodel);
        }

        /// <summary>
        /// Returns the Error Page View.
        /// </summary>
        /// <returns></returns>
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
