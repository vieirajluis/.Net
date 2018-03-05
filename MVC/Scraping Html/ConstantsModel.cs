//=================================================================================
// Program:   Ontario Gabinet Ministers
// Dissemination of this information or reproduction of this material is strictly
// forbidden unless prior written permission is obtained from TELOIP/Luis Vieira
//
// This software is distributed WITHOUT ANY WARRANTY; without even
// the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
//
//================================================================================/
// Class:   Constants (To define constant values accessible inside and/or outside of the application)
// Objective: Supports the Generation and Validation of Ontario Gabinet Ministers Pages. 
// Author  Luis Vieira
// Date	   2018-03-02
// (url:joaolsvieira@gmail.com)
//================================================================================/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OntarioGabinet.Models
{
    /// <summary>
    /// Summary description for Constants
    /// </summary>
    public class ConstantsModel
    {
        #region Utility
        /// <summary>
        /// Ontario Gabinet Web Page
        /// </summary>
        public static readonly string urlGabinet = "https://www.ontario.ca/page/meet-secretarys-team";

        /// <summary>
        /// Gabinet Error Message Description
        /// </summary>
        public static readonly string errorMessageGabinetModel = "Error in Gabinet Model ";
        #endregion

        #region View
        /// <summary>
        /// About View Title
        /// </summary>
        public static readonly string aboutTitle = "Ontario Cabinet Ministers.";
        /// <summary>
        /// Gabinet View Title
        /// </summary>
        public static readonly string gabinetTitle = "Deputy Ministers";
        /// <summary>
        /// Home Page View Title
        /// </summary>
        public static readonly string indextTitle = "Home Page";

        #endregion
    }
}
