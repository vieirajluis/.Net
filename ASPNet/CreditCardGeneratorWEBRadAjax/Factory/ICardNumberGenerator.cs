//=================================================================================
// Program:   Credit Card Generator
// Dissemination of this information or reproduction of this material is strictly
// forbidden unless prior written permission is obtained from Luis Vieira
//
// This software is distributed WITHOUT ANY WARRANTY; without even
// the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
//
//================================================================================/
// Class:   ICardNumberGenerator (Generates and Validates Credit Card Numbers)
// Objective: Decouple the UI Layer from the Business Logic Layer.
// Author  Luis Vieira
// Date	   2018-02-28
// (url:joaolsvieira@gmail.com)
//================================================================================/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCard.Utility;

namespace CreditCard.Factory
{

    
    public interface ICardNumberGenerator
    {
        /// <summary>
        /// Generates a Credit Card number
        /// </summary>
        /// <param name="option">
        /// The Credit Card name selected by user.
        /// </param>
        /// <returns>The generated card number.</returns>
        string GenerateCardNumber(string option);

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
        string CreateFakeCreditCardNumber(string prefix, int length);

        /// <summary>
        /// The helper to populate the UI Credit Card Test Fields.
        /// </summary>
        /// <param name="cardType"></param>
        /// <returns>Credit Card Number</returns>
        string GetCardNumber(Constants.CardIssuer cardType);

        /// <summary>
        /// The get credit card numbers.
        /// </summary>
        /// <param name="cardNum"></param>
        /// Card Number
        /// <returns>Credit Card Type</returns>
        Constants.CardIssuer? GetCardTypeFromNumber(string cardNum);

        /// <summary>
        /// Returns the issuer of a card using its first four digits
        /// </summary>
        /// <param name="cardPrefix">
        /// The first four digits of a card number.
        /// </param>
        /// <returns>The card issuer name for a specified card if found. Returns Unknown, if not found.</returns>
        Constants.CardIssuer GetCardIssuerNameByBin(string cardPrefix);

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
        IEnumerable<string> GetCreditCardNumbers(IList<string> prefixList, int length, int howMany);

        /// <summary>
        /// Validates whether a given credit card number passes the MOD 10 check.
        /// </summary>
        /// <param name="creditCardNumber">
        /// The credit card number.
        /// </param>
        /// <returns>
        /// True when valid, false otherwise.
        /// </returns>
        bool IsValidCreditCardNumber(string creditCardNumber);

        /// <summary>
        /// Checks if a specified card number is a rewards card number.
        /// </summary>
        /// <param name="cardNumber">The card number to be checked.</param>
        /// <returns>
        /// True if the specified card number is a rewards card number, 
        /// false otherwise.
        /// </returns>
        bool IsRewardsCardNumber(string cardNumber);

        /// <summary>
        /// Luhn algorithm for credit card check
        ///Adapted from code availabe on Wikipedia at
        ///http://en.wikipedia.org/wiki/Luhn_algorithm
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns>return true or false</returns>
        bool LuhnCheck(string cardNumber);

    }
}
