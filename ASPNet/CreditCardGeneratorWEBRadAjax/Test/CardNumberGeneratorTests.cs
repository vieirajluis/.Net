using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCard.Factory;
using CreditCard.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CreditCard.CardGenerator.Tests
{
    [TestClass()]
    public class CardNumberGeneratorTests
    {

        //According to PayPal, the valid test numbers that should be used
        //for testing card transactions are:
        //Credit Card Type              Credit Card Number
        //American Express              378282246310005
        //American Express              371449635398431
        //American Express Corporate    378734493671000
        //Diners Club                   30569309025904
        //Diners Club                   38520000023237
        //Discover                      6011111111111117
        //Discover                      6011000990139424
        //MasterCard                    5555555555554444
        //MasterCard                    5105105105105100
        //Visa                          4111111111111111
        //Visa                          4012888888881881
        //JCB	                        3530111333300000
        //JCB	                        3566002020360505
        //Src: https://developer.paypal.com/docs/classic/payflow/payflow-pro/payflow-pro-testing/
        //Src: https://stevemorse.org/ssn/List_of_Bank_Identification_Numbers.html
        //Src: https://en.wikipedia.org/wiki/Luhn_algorithm

        /// <summary>
        /// Test if a Credit Card Number is valid by its format. 
        /// </summary>
        [TestMethod()]
        public void IsValidCreditCardNumberTest()
        {
            ICardNumberGenerator cardNumberGenerator = CardNumberGenerator.Instance;

            string numDash = "4111-1111-1111-1111";
            string numSpace = "4111 1111 1111 1111";
            string numNoSpace = "4111111111111111";
            string numBadSep = "4111.1111.1111.1111";
            string numBadLen = "4111-1111-1111-111";

            Assert.IsTrue(cardNumberGenerator.IsValidCreditCardNumber(numDash), "IsValidNumber should allow numbers with dashes");
            Assert.IsTrue(cardNumberGenerator.IsValidCreditCardNumber(numSpace), "IsValidNumber should allow numbers with spaces");
            Assert.IsTrue(cardNumberGenerator.IsValidCreditCardNumber(numNoSpace), "IsValidNumber should allow numbers with no spaces");
            Assert.IsFalse(cardNumberGenerator.IsValidCreditCardNumber(numBadLen), "IsValidNumber should not allow numbers with too few numbers");
            Assert.IsFalse(cardNumberGenerator.IsValidCreditCardNumber(numBadSep), "IsValidNumber should not allow numbers with dot separators");

            
        }

        /// <summary>
        /// Test if a Credit Card Number is valid by its format and its type. 
        /// </summary>
        [TestMethod()]
        public void IsValidCreditCardTypeTest()
        {
            ICardNumberGenerator cardNumberGenerator = CardNumberGenerator.Instance;

            //Src: https://developer.paypal.com/docs/classic/payflow/payflow-pro/payflow-pro-testing/
            //Src: https://stevemorse.org/ssn/List_of_Bank_Identification_Numbers.html

            //American Express              378282246310005
            string amexCardDash = "3782-822463-10005";
            string amexCardSpace = "3782 822463 10005";
            string amexCardNoSpace = "378282246310005";
            string amexCardDot = "3782.822463.10005";

            Assert.IsTrue(Constants.CardIssuer.AmericanExpress== cardNumberGenerator.GetCardTypeFromNumber(amexCardDash), "IsValidNumber should allow Amex numbers with dashes");
            Assert.IsTrue(Constants.CardIssuer.AmericanExpress == cardNumberGenerator.GetCardTypeFromNumber(amexCardSpace), "IsValidNumber should allow Amex numbers with spaces");
            Assert.IsTrue(Constants.CardIssuer.AmericanExpress == cardNumberGenerator.GetCardTypeFromNumber(amexCardNoSpace), "IsValidNumber should allow Amex numbers with no spaces");
            Assert.IsFalse(Constants.CardIssuer.AmericanExpress == cardNumberGenerator.GetCardTypeFromNumber(amexCardDot), "IsValidNumber should not allow Amex numbers with decimals");

            //Visa                          4111111111111111
            //Visa                          4012888888881881
            string visaCardDash = "4111-1111-1111-1111";
            string visaCardSpace = "4111 1111 1111 1111";
            string visaCardNoSpace = "4012888888881881";
            string visaCardDot = "4012.8888.8888.1881";

            Assert.IsTrue(Constants.CardIssuer.Visa == cardNumberGenerator.GetCardTypeFromNumber(visaCardDash), "IsValidNumber should allow Visa numbers with dashes");
            Assert.IsTrue(Constants.CardIssuer.Visa == cardNumberGenerator.GetCardTypeFromNumber(visaCardSpace), "IsValidNumber should allow Visa numbers with spaces");
            Assert.IsTrue(Constants.CardIssuer.Visa == cardNumberGenerator.GetCardTypeFromNumber(visaCardNoSpace), "IsValidNumber should allow Visa numbers with no spaces");
            Assert.IsFalse(Constants.CardIssuer.Visa == cardNumberGenerator.GetCardTypeFromNumber(visaCardDot), "IsValidNumber should not allow Visa numbers with decimals");

            string mcCardDash = "5500-0000-0000-0004";
            string mcCardSpace = "5500 0000 0000 0004";
            string mcCardNoSpace = "5500000000000004";
            string mcCardDot = "5500.0000.0000.0004";

            Assert.IsTrue(Constants.CardIssuer.MasterCard == cardNumberGenerator.GetCardTypeFromNumber(mcCardDash), "IsValidNumber should allow MC numbers with dashes");
            Assert.IsTrue(Constants.CardIssuer.MasterCard == cardNumberGenerator.GetCardTypeFromNumber(mcCardSpace), "IsValidNumber should allow MC numbers with spaces");
            Assert.IsTrue(Constants.CardIssuer.MasterCard == cardNumberGenerator.GetCardTypeFromNumber(mcCardNoSpace), "IsValidNumber should allow MC numbers with no spaces");
            Assert.IsFalse(Constants.CardIssuer.MasterCard == cardNumberGenerator.GetCardTypeFromNumber(mcCardDot), "IsValidNumber should not allow MC numbers with decimals");

            //Discover                      6011111111111117
            //Discover                      6011000990139424
            string discoverCardDash = "6011-1111-1111-1117";
            string discoverCardSpace = "6011 1111 1111 1117";
            string discoverCardNoSpace = "6011111111111117";
            string discoverCardDot = "6011.1111.1111.1117";

            Assert.IsTrue(Constants.CardIssuer.Discover == cardNumberGenerator.GetCardTypeFromNumber(discoverCardDash), "IsValidNumber should allow Discover numbers with dashes");
            Assert.IsTrue(Constants.CardIssuer.Discover == cardNumberGenerator.GetCardTypeFromNumber(discoverCardSpace), "IsValidNumber should allow Discover numbers with spaces");
            Assert.IsTrue(Constants.CardIssuer.Discover == cardNumberGenerator.GetCardTypeFromNumber(discoverCardNoSpace), "IsValidNumber should allow Discover numbers with no spaces");
            Assert.IsFalse(Constants.CardIssuer.Discover == cardNumberGenerator.GetCardTypeFromNumber(discoverCardDot), "IsValidNumber should not allow Discover numbers with decimals");

            //Diners Club                   30569309025904
            //Diners Club                   38520000023237
            string dinersCardDash = "3056-930902-5904";
            string dinersCardSpace = "3056 930902 5904";
            string dinersCardNoSpace = "30569309025904";
            string dinersCardDot = "3056.930902.5904";

            Assert.IsTrue(Constants.CardIssuer.Diners == cardNumberGenerator.GetCardTypeFromNumber(dinersCardDash), "IsValidNumber should allow Diners numbers with dashes");
            Assert.IsTrue(Constants.CardIssuer.Diners == cardNumberGenerator.GetCardTypeFromNumber(dinersCardSpace), "IsValidNumber should allow Diners numbers with spaces");
            Assert.IsTrue(Constants.CardIssuer.Diners == cardNumberGenerator.GetCardTypeFromNumber(dinersCardNoSpace), "IsValidNumber should allow Diners numbers with no spaces");
            Assert.IsFalse(Constants.CardIssuer.Diners == cardNumberGenerator.GetCardTypeFromNumber(dinersCardDot), "IsValidNumber should not allow Diners numbers with decimals");

            //JCB	                        3530111333300000
            //JCB	                        3566002020360505
            string jcbCardDash = "3566-0020-2036-0505";
            string jcbCardSpace = "3566 0020 2036 0505";
            string jcbCardNoSpace = "3566002020360505";
            string jcbCardDot = "3566.0020.2036.0505";

            Assert.IsTrue(Constants.CardIssuer.JCB == cardNumberGenerator.GetCardTypeFromNumber(jcbCardDash), "IsValidNumber should allow JCB numbers with dashes");
            Assert.IsTrue(Constants.CardIssuer.JCB == cardNumberGenerator.GetCardTypeFromNumber(jcbCardSpace), "IsValidNumber should allow JCB numbers with spaces");
            Assert.IsTrue(Constants.CardIssuer.JCB == cardNumberGenerator.GetCardTypeFromNumber(jcbCardNoSpace), "IsValidNumber should allow JCB numbers with no spaces");
            Assert.IsFalse(Constants.CardIssuer.JCB == cardNumberGenerator.GetCardTypeFromNumber(jcbCardDot), "IsValidNumber should not allow JCB numbers with decimals");
        }

        /// <summary>
        /// Test the type of the card against its number.
        /// </summary>
        [TestMethod()]
        public void GetCardTypeFromNumberTest()
        {
            ICardNumberGenerator cardNumberGenerator = CardNumberGenerator.Instance;

            string visaNum = "4111-1111-1111-1111";
            string amexNum = "3782-822463-10005";
            string mcNum = "5105-1051-0510-5100";
            string discoverNum = "6011-1111-1111-1117";
            string dinersNum = "3056-930902-5904";
            string jcbNum = "3566-0020-2036-0505";

            Assert.AreEqual(Constants.CardIssuer.Visa, cardNumberGenerator.GetCardTypeFromNumber(visaNum), "GetCardTypeFromNumber should return Visa");
            Assert.AreEqual(Constants.CardIssuer.AmericanExpress, cardNumberGenerator.GetCardTypeFromNumber(amexNum), "GetCardTypeFromNumber should return American Express");
            Assert.AreEqual(Constants.CardIssuer.MasterCard, cardNumberGenerator.GetCardTypeFromNumber(mcNum), "GetCardTypeFromNumber should return MasterCard");
            Assert.AreEqual(Constants.CardIssuer.Discover, cardNumberGenerator.GetCardTypeFromNumber(discoverNum), "GetCardTypeFromNumber should return Discover");
            Assert.AreEqual(Constants.CardIssuer.Diners, cardNumberGenerator.GetCardTypeFromNumber(dinersNum), "GetCardTypeFromNumber should return Diners");
            Assert.AreEqual(Constants.CardIssuer.JCB, cardNumberGenerator.GetCardTypeFromNumber(jcbNum), "GetCardTypeFromNumber should return JCB");
        }

        /// <summary>
        /// Test against Luhn algorithm.
        /// https://en.wikipedia.org/wiki/Luhn_algorithm
        /// </summary>
        [TestMethod()]
        public void LuhnCheck()
        {
            ICardNumberGenerator cardNumberGenerator = CardNumberGenerator.Instance;

            string visaNum = "4111-1111-1111-1111";
            string amexNum = "3782-822463-10005";
            string mcNum = "5105-1051-0510-5100";
            string discoverNum = "6011-1111-1111-1117";
            string dinersNum = "3056-930902-5904";
            string jcbNum = "3566-0020-2036-0505";

            Assert.IsTrue(cardNumberGenerator.LuhnCheck(visaNum), "LuhnCheck should return true for this Visa number");
            Assert.IsTrue(cardNumberGenerator.LuhnCheck(amexNum), "LuhnCheck should return true for this American Express number");
            Assert.IsTrue(cardNumberGenerator.LuhnCheck(mcNum), "LuhnCheck should return true for this Master Card number");
            Assert.IsTrue(cardNumberGenerator.LuhnCheck(discoverNum), "LuhnCheck should return true for this Discover number");
            Assert.IsTrue(cardNumberGenerator.LuhnCheck(dinersNum), "LuhnCheck should return true for this Diners number");
            Assert.IsTrue(cardNumberGenerator.LuhnCheck(jcbNum), "LuhnCheck should return true for this JCB number");

            string visaInvalid = "4111-0000-0000-0000";

            Assert.IsFalse(cardNumberGenerator.LuhnCheck(visaInvalid), "PassesLuhnTest should return false for this number");

        }

        }
}