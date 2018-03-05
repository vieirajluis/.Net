
//=================================================================================
// Program:   Credit Card Generator
// Dissemination of this information or reproduction of this material is strictly
// forbidden unless prior written permission is obtained from Luis Vieira
//
// This software is distributed WITHOUT ANY WARRANTY; without even
// the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
//
//================================================================================/
// Class:   CardNumberGenerator (Generates and Validates Credit Card Numbers)
// Objective: Decouple the UI Layer from the Business Logic Layer.
// Author  Luis Vieira
// Date	   2018-02-28
// (url:joaolsvieira@gmail.com)
//================================================================================/


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

using CreditCard.Utility;
namespace CreditCard.Factory
{
    /// <summary>
    /// Provides the ability to generate various card numbers.
    /// Generally used for testing but has the ability to generate valid 
    /// rewards card numbers.
    /// </summary>
    public class CardNumberGenerator:ICardNumberGenerator
    {

        /// <summary>
        /// CardNumberGenerator Singleton
        /// </summary>
        private static CardNumberGenerator instance;

        private CardNumberGenerator() { }

        public static CardNumberGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CardNumberGenerator();
                }
                return instance;
            }
        }

        #region Factory/Create Methods


        /// <summary>
        /// Generates a Credit Card number
        /// </summary>
        /// <param name="option">
        /// The Credit Card name selected by user.
        /// </param>
        /// <returns>The generated card number.</returns>
        /// LUIS VIEIRA UPDATE 2018-02-28: 
        /// Created (Class Constants to keep Regular Expressions to Check Card Numbers,
        /// Card Prefix and ENUM CardIssuer of Card Type)
        /// Created (Extended Method to generate Credit Card Numbers for
        /// all prefixes within this Test and requested by USER (See CreditCardSite Start Page).
        /// Ref: https://stevemorse.org/ssn/List_of_Bank_Identification_Numbers.html
        /// Ref: https://developer.paypal.com/docs/classic/payflow/payflow-pro/payflow-pro-testing/
        public string GenerateCardNumber(string option)
        {

            var cardNumber = new Stack<string>();
            switch (option)
            {
                case nameof(Constants.CardIssuer.Unknown):
                    break;
                case nameof(Constants.CardIssuer.AmericanExpress):
                    cardNumber.Push(GetCreditCardNumbers(Constants.AmexPrefixList, 15, 1).First());
                    break;
                case nameof(Constants.CardIssuer.Diners):
                    cardNumber.Push(GetCreditCardNumbers(Constants.DinersPrefixList, 14, 1).First());
                    break;
                case nameof(Constants.CardIssuer.Discover):
                    cardNumber.Push(GetCreditCardNumbers(Constants.DiscoverPrefixList, 16, 1).First());
                    break;
                case nameof(Constants.CardIssuer.Enroute):
                    cardNumber.Push(GetCreditCardNumbers(Constants.EnroutePrefixList, 15, 1).First());
                    break;
                case nameof(Constants.CardIssuer.JCBFifteen):
                    cardNumber.Push(GetCreditCardNumbers(Constants.Jcb15PrefixList, 15, 1).First());
                    break;
                case nameof(Constants.CardIssuer.JCBSixteen):
                    cardNumber.Push(GetCreditCardNumbers(Constants.Jcb16PrefixList, 16, 1).First());
                    break;
                case nameof(Constants.CardIssuer.MasterCard):
                    cardNumber.Push(GetCreditCardNumbers(Constants.MastercardPrefixList, 16, 1).First());
                    break;
                case nameof(Constants.CardIssuer.Rewards):
                    cardNumber.Push(GetCreditCardNumbers(Constants.RewardsPrefixList, 16, 1).First());
                    break;
                case nameof(Constants.CardIssuer.TgnGiftCard):
                    cardNumber.Push(GetCreditCardNumbers(Constants.TgnPrefixList, 16, 1).First());
                    break;
                case nameof(Constants.CardIssuer.TgnPromoCard):
                    cardNumber.Push(GetCreditCardNumbers(Constants.TgnPromoPrefixList, 16, 1).First());
                    break;
                case nameof(Constants.CardIssuer.Visa):
                    cardNumber.Push(GetCreditCardNumbers(Constants.VisaPrefixList, 16, 1).First());
                    break;
                case nameof(Constants.CardIssuer.Voyager):
                    cardNumber.Push(GetCreditCardNumbers(Constants.VoyagerPrefixList, 15, 1).First());
                    break;
                default:
                    break;
            }

            return cardNumber.Count > 0 ? cardNumber.Pop().ToString() : null;
        }

        /// <summary>
        /// Generates a card number based on the specifications provided.
        /// </summary>
        /// <param name="prefix">
        /// the start of the CC number as a string, any number
        ///  private of digits
        /// </param>
        /// <param name="length">
        /// length of the CC number to generate.
        /// * Typically 13 or 16
        /// </param>        
        /// <returns>
        /// The generated card number.
        /// </returns>
        public string CreateFakeCreditCardNumber(string prefix, int length)
        {
            var random = new Random();

            var ccnumber = prefix;

            while (ccnumber.Length < (length - 1))
            {
                var rnd = (random.NextDouble() * 1.0f - 0f);

                ccnumber += Math.Floor(rnd * 10);
            }

            // reverse number and convert to int
            var reversedCCnumberstring = ccnumber.ToCharArray().Reverse();

            var reversedCCnumberList = reversedCCnumberstring.Select(c => Convert.ToInt32(c.ToString(CultureInfo.InvariantCulture)));

            // calculate sum
            var sum = 0;
            var pos = 0;
            var reversedCCnumber = reversedCCnumberList.ToArray();

            while (pos < length - 1)
            {
                var odd = reversedCCnumber[pos] * 2;

                if (odd > 9)
                {
                    odd -= 9;
                }

                sum += odd;

                if (pos != (length - 2))
                {
                    sum += reversedCCnumber[pos + 1];
                }

                pos += 2;
            }

            // calculate check digit
            var checkdigit = Convert.ToInt32((Math.Floor((decimal)sum / 10) + 1) * 10 - sum) % 10;

            ccnumber += checkdigit;

            return ccnumber;
        }
        #endregion

        #region Read/Search Methods
        /// <summary>
        /// Returns the issuer of a card using its first four digits
        /// </summary>
        /// <param name="cardPrefix">
        /// The first four digits of a card number.
        /// </param>
        /// <returns>The card issuer name for a specified card if found. Returns Unknown, if not found.</returns>
        /// LUIS VIEIRA UPDATE 2018-02-28: 
        /// Created (Class Constants to Keep Card Prefix and ENUM CardIssuer of Card Type)
        /// Split (JCB Card Type Statement)
        /// Order of IF..ELSE statements.
        public Constants.CardIssuer GetCardIssuerNameByBin(string cardPrefix)
        {
            var firstTwoChars = cardPrefix.Substring(0, 2);
            var firstThreeChars = cardPrefix.Substring(0, 3);

            if (Constants.RewardsPrefixList.Contains(firstTwoChars) || Constants.RewardsPrefixList.Contains(cardPrefix))
            {
                return Constants.CardIssuer.Rewards;
            }

            if (Constants.AmexPrefixList.Contains(firstTwoChars))
            {
                return Constants.CardIssuer.AmericanExpress;
            }

            if (Constants.DinersPrefixList.Contains(firstThreeChars) || Constants.DinersPrefixList.Contains(firstTwoChars))
            {
                return Constants.CardIssuer.Diners;
            }

            if (Constants.DiscoverPrefixList.Contains(cardPrefix))
            {
                return Constants.CardIssuer.Discover;
            }

            if (Constants.EnroutePrefixList.Contains(cardPrefix))
            {
                return Constants.CardIssuer.Enroute;
            }

            if (Constants.Jcb15PrefixList.Contains(cardPrefix))
            {
                return Constants.CardIssuer.JCBFifteen;
            }

            if (Constants.Jcb16PrefixList.Contains(cardPrefix))
            {
                return Constants.CardIssuer.JCBSixteen;
            }

            if (Constants.MastercardPrefixList.Contains(firstTwoChars))
            {
                return Constants.CardIssuer.MasterCard;
            }

            if (Constants.VisaPrefixList.Contains(cardPrefix) || cardPrefix.Substring(0, 1) == "4")
            {
                return Constants.CardIssuer.Visa;
            }

            if (Constants.VoyagerPrefixList.Contains(cardPrefix))
            {
                return Constants.CardIssuer.Voyager;
            }

            if (Constants.TgnPromoPrefixList.Contains(firstTwoChars))
            {
                return Constants.CardIssuer.TgnPromoCard;
            }

            if (Constants.TgnPrefixList.Contains(firstTwoChars) || Constants.TgnPrefixList.Contains(cardPrefix))
            {
                return Constants.CardIssuer.TgnGiftCard;
            }



            return Constants.CardIssuer.Unknown;
        }

        /// <summary>
        /// The get credit card numbers.
        /// </summary>
        /// <param name="prefixList">
        /// The prefix list.
        /// </param>
        /// <param name="length">
        /// The length.
        /// </param>
        /// <param name="howMany">
        /// The how many.
        /// </param>        
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// LUIS VIEIRA UPDATE 2018-02-28: 
        /// Removed a Redundant Variable (var random = new Random();)
        public IEnumerable<string> GetCreditCardNumbers(IList<string> prefixList, int length, int howMany)
        {
            
            var result = new Stack<string>();

            var intRandom = new Random();

            for (int i = 0; i < howMany; i++)
            {
                int randomPrefix = intRandom.Next(0, prefixList.Count - 1);

                if (randomPrefix > 1)
                {
                    randomPrefix--;
                }

                string ccnumber = prefixList[randomPrefix];

                result.Push(CreateFakeCreditCardNumber(ccnumber, length));
            }

            return result;
        }

        /// <summary>
        /// The get credit card numbers.
        /// </summary>
        /// <param name="cardNum"></param>
        /// Card Number
        /// <returns>Credit Card Type</returns>
        /// LUIS VIEIRA UPDATE 2018-02-28: 
        /// Created (Class Constants to keep Regular Expressions to Check Card Numbers,
        /// Card Prefix and ENUM CardIssuer of Card Type)
        /// Created (NEW Method to return Credit Card by Type using REGEX. 
        /// If not found by REGEX will try to find using Card Prefix.
        /// Formatting Card Number before validations.
        public Constants.CardIssuer? GetCardTypeFromNumber(string cardNum)
        {
            cardNum = cardNum.Trim().Replace("-", "").Replace(" ", "");
           
            //Create new instance of Regex comparer with a
            //credit card regex pattern
            Regex cardGC = new Regex(Constants.cardRegex);

            //Compare the supplied card number with the regex
            //pattern and get reference regex named groups
            GroupCollection gc = cardGC.Match(cardNum).Groups;

            //Create new instance of Regex comparer with a
            //JCB credit card regex pattern
            Regex cardTestJCB = new Regex(Constants.carJCBRegex);

            //Compare the supplied JCB card number with the regex
            //pattern and get reference regex named groups
            GroupCollection gcJCB = cardTestJCB.Match(cardNum).Groups;

            //Create new instance of Regex comparer with a
            //Enroute credit card regex pattern
            Regex cardTestEnroute = new Regex(Constants.carEnrouteRegex);

            //Compare the supplied Enroute card number with the regex
            //pattern and get reference regex named groups
            GroupCollection gcEnroute = cardTestEnroute.Match(cardNum).Groups;

            //Compare each card type to the named groups to 
            //determine which card type the number matches
            if (gc[Constants.CardIssuer.AmericanExpress.ToString()].Success)
            {
                return Constants.CardIssuer.AmericanExpress;
            }
            else if (gc[Constants.CardIssuer.MasterCard.ToString()].Success)
            {
                return Constants.CardIssuer.MasterCard;
            }
            else if (gc[Constants.CardIssuer.Visa.ToString()].Success)
            {
                return Constants.CardIssuer.Visa;
            }
            else if (gc[Constants.CardIssuer.Discover.ToString()].Success)
            {
                return Constants.CardIssuer.Discover;
            }
            else if (gc[Constants.CardIssuer.Diners.ToString()].Success)
            {
                return Constants.CardIssuer.Diners;
            }
            else if (gc[Constants.CardIssuer.Enroute.ToString()].Success)
            {
                return Constants.CardIssuer.Enroute;
            }
            else if (gc[Constants.CardIssuer.Voyager.ToString()].Success)
            {
                return Constants.CardIssuer.Voyager;
            }
            else if (gcJCB[Constants.CardIssuer.JCB.ToString()].Success)
            {
                return Constants.CardIssuer.JCB;
            }
            else if (gcEnroute[Constants.CardIssuer.Enroute.ToString()].Success)
            {
                return Constants.CardIssuer.Enroute;
            }
            else
            {
                if (!(cardNum.Contains(".")))
                {
                    var cardPrefix = cardNum.Length > 4 ? cardNum.Substring(0, 4) : cardNum;

                    return GetCardIssuerNameByBin(cardPrefix);
                }
                else
                {
                    return Constants.CardIssuer.Unknown;
                }
            }
        }

        /// <summary>
        /// The helper to populate the UI Credit Card Test Fields.
        /// </summary>
        /// <param name="cardType"></param>
        /// <returns>Credit Card Number</returns>
        /// LUIS VIEIRA UPDATE 2018-02-28: 
        /// Created (Class Constants to keep Regular Expressions to Check Card Numbers,
        /// Card Prefix and ENUM CardIssuer of Card Type)
        /// Created (NEW Method to return Credit Card Number by its Type. 
        public string GetCardNumber(Constants.CardIssuer cardType)
        {
            //Return bogus CC number that passes Luhn and format tests
            switch (cardType)
            {
                case Constants.CardIssuer.AmericanExpress:
                    return Constants.AmericanExpress;
                case Constants.CardIssuer.Discover:
                    return Constants.Discover;
                case Constants.CardIssuer.MasterCard:
                    return Constants.MasterCard;
                case Constants.CardIssuer.Visa:
                    return Constants.Visa;
                case Constants.CardIssuer.Diners:
                    return Constants.Diners;
                case Constants.CardIssuer.JCB:
                    return Constants.JCB;
                default:
                    return null;
            }
        }
        #endregion

        #region Validation Methods
        /// <summary>
        /// Checks if a specified card number is a rewards card number.
        /// </summary>
        /// <param name="cardNumber">The card number to be checked.</param>
        /// <returns>
        /// True if the specified card number is a rewards card number, 
        /// false otherwise.
        /// </returns>
        /// LUIS VIEIRA UPDATE 2018-02-28: 
        /// Created (Class Constants to Keep Card Prefix and ENUM CardIssuer of Card Type)
        /// Formatting Card Number before validations.
        public bool IsRewardsCardNumber(string cardNumber)
        {
            cardNumber = cardNumber.Trim().Replace("-", "").Replace(" ", "").Replace(".", "");
            if (cardNumber.Length < 4)
            {
                throw new ApplicationException("Invalid card number.");
            }

            var cardPrefix = cardNumber.Length > 4 ? cardNumber.Substring(0, 4) : cardNumber;

            return GetCardIssuerNameByBin(cardPrefix) == Constants.CardIssuer.Rewards;
        }

        /// <summary>
        /// Validates whether a given credit card number passes the MOD 10 check.
        /// </summary>
        /// <param name="creditCardNumber">
        /// The credit card number.
        /// </param>
        /// <returns>
        /// True when valid, false otherwise.
        /// </returns>
        /// LUIS VIEIRA UPDATE 2018-02-28: 
        /// Formatting Card Number before validations.
        public bool IsValidCreditCardNumber(string creditCardNumber)
        {
            try
            {
                creditCardNumber = creditCardNumber.Trim().Replace("-", "").Replace(" ", "");
                var reversedNumber = creditCardNumber.ToCharArray().Reverse().ToList();

                var mod10Count = 0;
                for (var i = 0; i < reversedNumber.Count(); i++)
                {
                    var augend = Convert.ToInt32(reversedNumber.ElementAt(i).ToString(CultureInfo.InvariantCulture));

                    if (((i + 1) % 2) == 0)
                    {
                        var productstring = (augend * 2).ToString(CultureInfo.InvariantCulture);
                        augend = productstring.Select((t, j) => Convert.ToInt32(productstring.ElementAt(j).ToString(CultureInfo.InvariantCulture))).Sum();
                    }

                    mod10Count += augend;
                }

                if ((mod10Count % 10) == 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// Luhn algorithm for credit card check
        ///Adapted from code availabe on Wikipedia at
        ///http://en.wikipedia.org/wiki/Luhn_algorithm
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns>return true or false</returns>
        /// LUIS VIEIRA UPDATE 2018-02-28: 
        /// Created (NEW Method To Check if is a valid Credit Card Number)
        public bool LuhnCheck(string cardNumber)
        {
            // check whether input string is null or empty
            if (string.IsNullOrEmpty(cardNumber))
            {
                return false;
            }

            int sumOfDigits = cardNumber.Where((e) => e >= '0' && e <= '9')
                            .Reverse()
                            .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                            .Sum((e) => e / 10 + e % 10);


            return sumOfDigits % 10 == 0;
        }
        #endregion



    }
}
