//=================================================================================
// Program:   Credit Card Generator
// Dissemination of this information or reproduction of this material is strictly
// forbidden unless prior written permission is obtained from Luis Vieira
//
// This software is distributed WITHOUT ANY WARRANTY; without even
// the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
//
//================================================================================/
// Class:   _Default (User Interface to support user interactions:
// User Interactions: Generates and Validates Credit Card Numbers.
// Objective: Decouple the UI Layer from the Business Logic Layer.
// Author  Luis Vieira
// Date	   2018-02-28
// (url:joaolsvieira@gmail.com)
//================================================================================/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CreditCard.Factory;
using CreditCard.Utility;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            ICardNumberGenerator cardNumberGenerator = CardNumberGenerator.Instance;
            //Populates Credit Card Number Examples.
            this.lblMc.Text = cardNumberGenerator.GetCardNumber(Constants.CardIssuer.MasterCard).Replace(" ", "-");
            this.lblVisa.Text = cardNumberGenerator.GetCardNumber(Constants.CardIssuer.Visa).Replace(" ", "-");
            this.lblDisc.Text = cardNumberGenerator.GetCardNumber(Constants.CardIssuer.Discover).Replace(" ", "-");
            this.lblAmex.Text = cardNumberGenerator.GetCardNumber(Constants.CardIssuer.AmericanExpress).Replace(" ", "-");
            this.lblDin.Text = cardNumberGenerator.GetCardNumber(Constants.CardIssuer.Diners).Replace(" ", "-");
            this.lblJCB.Text = cardNumberGenerator.GetCardNumber(Constants.CardIssuer.JCB).Replace(" ", "-");
        }
    }

    /// <summary>
    /// Action to Validate Credit Card Number.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnValidate_Click(object sender, EventArgs e)
    {
        ICardNumberGenerator cardNumberGenerator = CardNumberGenerator.Instance;

        if (txtCard.Text.Length > 0)
        {
            string cardNum = txtCard.Text;

            if (cardNumberGenerator.IsValidCreditCardNumber(cardNum))
            {
                Constants.CardIssuer? cardType= cardNumberGenerator.GetCardTypeFromNumber(cardNum);
                string strCardType = (cardType == null) ? "Unknown" : cardType.ToString();

                showMessage(String.Format("You have entered a valid card number. The card type is {0}.", strCardType), true);
            }
            else
                showMessage("Card failed test. Please enter a valid card number.", false);

            if (cardNumberGenerator.IsRewardsCardNumber(cardNum))
            {
                Constants.CardIssuer? cardType = cardNumberGenerator.GetCardTypeFromNumber(cardNum);
                string strCardType = (cardType == null) ? "Unknown" : cardType.ToString();

                showMessage(String.Format("You have entered a reward card number. The card type is {0}.", strCardType), true);
            }
        }
        else
            showMessage("Please enter a card number first.", false);
    }

    /// <summary>
    /// Action to Show User Friendly Message.
    /// Valid or Invalid Card Information.
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="isSuccess"></param>
    protected void showMessage(string msg, bool isSuccess)
    {
        this.lblMsg.Text = msg;

        if (isSuccess)
            lblMsg.CssClass = "success";
        else
            lblMsg.CssClass = "fail";
    }

    /// <summary>
    /// Action to generate Credit Card Number.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        ICardNumberGenerator cardNumberGenerator = CardNumberGenerator.Instance;

        int index = dlCardName.SelectedIndex;
        string cardName = dlCardName.SelectedValue;

        txtCard.Text= cardNumberGenerator.GenerateCardNumber(cardName.Trim().Replace(" ",""));
    }

    
}