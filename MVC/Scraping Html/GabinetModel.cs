//=================================================================================
// Program:   Ontario Gabinet Ministers
// Dissemination of this information or reproduction of this material is strictly
// forbidden unless prior written permission is obtained from TELOIP/Luis Vieira
//
// This software is distributed WITHOUT ANY WARRANTY; without even
// the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
//
//================================================================================/
// Class:   GabinetModel (To read and parse Ontario Gabinet Ministers Web Page)
// Objective: Supports the Generation and Validation of Ontario Gabinet Ministers Pages. 
// Author  Luis Vieira
// Date	   2018-03-02
// (url:joaolsvieira@gmail.com)
//================================================================================/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;

namespace OntarioGabinet.Models
{
    /// <summary>
    /// HTML Parser and To Upload the Information of The Ontario Gabinet Ministers at Runtime.
    /// </summary>
    public class GabinetModel
    {
        /// <summary>
        /// List of current ministers names and headshot.
        /// </summary>
        public List<HtmlNode> NameList { get; set; }
        /// <summary>
        /// List of current ministers titles/bio.
        /// </summary>
        public List<HtmlNode> TitleList { get ; set; }
        /// <summary>
        /// List of current ministers names, titles and headshots.
        /// </summary>
        public List<HtmlNode> GabinetList { get; set; }


        /// <summary>
        /// Current Ministers Web Page Parser.
        /// </summary>
        public void GetHtmlGabinet()
        {
            //Web Page address          
            var url = ConstantsModel.urlGabinet;

            //Browser used for the webpage insteractions.
            PhantomJSDriver driver = new PhantomJSDriver();
           
            try
            {
              
                //Load a webpage in the current browser window.
                driver.Navigate().GoToUrl(url);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
               
                //Loads the HTML from the driver/browser.
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(driver.PageSource);
               
                //Gets the root node by its "div" descendants.
                var GabinetHTML = wait.Until(x=> doc.DocumentNode.Descendants("div")
                   .Where(node => node.GetAttributeValue("id", "")
                   .Equals("pagebody")).ToList());

                //Gets the name and headshot of the ministers by "h3" descendants.
                NameList = wait.Until(x => GabinetHTML[0].Descendants("h3")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Contains("top-padding")).ToList());

                //Gets the ttiles/bio of the ministers by "h3" descendants.
                TitleList = wait.Until(x => GabinetHTML[0].Descendants("p")
                        .Where(node => node.GetAttributeValue("class", "")
                        .Equals("clearfix")).ToList());

                GabinetList = NameList.Concat(TitleList).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {

                driver.Quit();
            }
            
          
            

           
        }
    }
}
