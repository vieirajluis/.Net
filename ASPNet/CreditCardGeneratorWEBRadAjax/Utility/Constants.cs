//=================================================================================
// Program:   Credit Card Generator
// Dissemination of this information or reproduction of this material is strictly
// forbidden unless prior written permission is obtained from Luis Vieira
//
// This software is distributed WITHOUT ANY WARRANTY; without even
// the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
//
//================================================================================/
// Class:   Constants (To define constant values accessible inside and/or outside of the application)
// Objective: Supports the Generation and Validation of Credit Cards. 
// Author  Luis Vieira
// Date	   2018-02-28
// (url:joaolsvieira@gmail.com)
//================================================================================/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CreditCard.Utility
{
    /// <summary>
    /// Summary description for Constants
    /// </summary>
    public class Constants
    {
        #region Constants to support the Factory/Create Methods
        // readonly satisfy the keyword const
        /// <summary>
        /// Prefix lists for American Express card numbers.
        /// </summary>
        public static readonly string[] AmexPrefixList = { "34", "37" };

        /// <summary>
        /// Prefix list for Diner's card numbers.
        /// </summary>
        public static readonly string[] DinersPrefixList = { "300", "301", "302", "303", "36", "38" };

        /// <summary>
        /// Prefix list for Discover card numbers.
        /// </summary>
        public static readonly string[] DiscoverPrefixList = { "6011" };

        /// <summary>
        /// Prefix list for ENROUTE card numbers.
        /// </summary>
        public static readonly string[] EnroutePrefixList = { "2014", "2149" };

        /// <summary>
        /// Prefix list for JCB 15 card numbers.
        /// </summary>
        public static readonly string[] Jcb15PrefixList = { "2100", "2131", "1800" };

        /// <summary>
        /// Prefix list of JCB 16 card numbers.
        /// </summary>
        public static readonly string[] Jcb16PrefixList = { "3088", "3096", "3112", "3158", "3337", "3528" };

        /// <summary>
        /// Prefix list for Mastercard numbers.
        /// </summary>
        public static readonly string[] MastercardPrefixList = { "51", "52", "53", "54", "55" };

        /// <summary>
        /// Prefix list for Visa card numbers.
        /// </summary>
        public static readonly string[] VisaPrefixList = { "4539", "4556", "4916", "4532", "4929", "40240071", "4485", "4716", "4" };

        /// <summary>
        /// Prefix list for Voyager card numbers.
        /// </summary>
        public static readonly string[] VoyagerPrefixList = { "8699" };

        /// <summary>
        /// Prefix list for TGN card numbers.
        /// </summary>
        /// <remarks>
        /// We keep these for historical purposes.
        /// </remarks>
        public static readonly string[] TgnPrefixList = { "99", "9999" };

        /// <summary>
        /// Prefix list for TGN promotional card numbers.
        /// </summary>
        /// <remarks>
        /// We keep these for historical purposes.
        /// </remarks>
        public static readonly string[] TgnPromoPrefixList = { "11" };

        /// <summary>
        /// Prefix list for Rewards card numbers.
        /// </summary>
        public static readonly string[] RewardsPrefixList = { "22", "2222" };
        #endregion
        
        #region Constants to support Verification and Validation
        /// <summary>
        /// Use the following Regex for testing your Credit Card Number.
        /// </summary>
        public const string cardRegex = "^(?:(?<Visa>4\\d{3})|(?<MasterCard>5[1-5]\\d{2})|(?<Discover>6011)|(?<Diners>(?:3[68]\\d{2})|(?:30[0-5]\\d))|(?<AmericanExpress>3[47]\\d{2}))([ -]?)(?(Diners)(?:\\d{6}\\1\\d{4})|(?(AmericanExpress)(?:\\d{6}\\1\\d{5})|(?:\\d{4}\\1\\d{4}\\1\\d{4})))$";
        public const string carJCBRegex = "^(?:(?<JCB>(?:2131|2100|1800)[ -]*\\d{6}[ -]*\\d{5}|3[0-3]\\d{2}[ -]*\\d{4}[ -]*\\d{4}[ -]*\\d{4}|35\\d{2}[ -]*\\d{4}[ -]*\\d{4}[ -]*\\d{4}))$";
        public const string carEnrouteRegex = "^(?:(?<Enroute>(?:2014|2149)[ -]*\\d{6}[ -]*\\d{5}|3[0-3]\\d{2}[ -]*\\d{4}[ -]*\\d{4}[ -]*\\d{4}))$";

        /// <summary>
        /// Constants variables used to illustrate a range of a major card schemes.
        /// These Credit Cards Numbers will be presented on the Start Page (UI) of the main application.
        /// According to PayPal, the valid test numbers that should be used
        /// for testing card transactions are:
        /// Credit Card Type              Credit Card Number
        /// American Express              378282246310005
        /// American Express              371449635398431
        /// American Express Corporate    378734493671000
        /// Diners Club                   30569309025904
        /// Diners Club                   38520000023237
        /// Discover                      6011111111111117
        /// Discover                      6011000990139424
        /// JCB	                          3530111333300000
        /// JCB	                          3566002020360505
        /// MasterCard                    5555555555554444
        /// MasterCard                    5105105105105100
        /// Visa                          4111111111111111
        /// Visa                          4012888888881881
        /// Src: https://developer.paypal.com/docs/classic/payflow/payflow-pro/payflow-pro-testing/
        /// </summary>
        public const string AmericanExpress = "3714 496353 98431";
        public const string Discover = "6011 1111 1111 1117";
        public const string MasterCard = "5105 1051 0510 5100";
        public const string Visa = "4111 1111 1111 1111";
        public const string Diners = "3056 930902 5904";
        public const string JCB = "3530 1113 3330 0000";
        #endregion

        #region Constants to support Read/Search Methods
        /// <summary>
        /// List of issued Credit Card Types
        /// </summary>
        public enum CardIssuer
        {
            Unknown,
            AmericanExpress,
            Diners,
            Discover,
            Enroute,
            JCB,
            JCBSixteen,
            JCBFifteen,
            MasterCard,
            Rewards,
            TgnGiftCard,
            TgnPromoCard,
            Visa,
            Voyager

        }
        #endregion


    }
}