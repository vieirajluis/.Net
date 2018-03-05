<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="radA" %>
<%@ Register Assembly="RadInput.Net2" Namespace="Telerik.WebControls" TagPrefix="radI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Credit Card Generator</title>
    <style type="text/css">
        body {
            font-family: Arial, Sans-Serif;
            background: #000 url(/images/innerBkgnd.png) repeat-x 0 0;
            color: darkblue;
            background:transparent linear-gradient();
        }

        #wrapper, #footer {
            background: transparent no-repeat 0 0;
            padding: 10px;
            margin: 25px auto 0px auto;
            width: 780px;
            height: 400px;
            text-align: center;
        }

        #footer {
            height: 30px;
            color: #777;
            background: transparent;
        }

            #footer a {
                color: #999;
            }

        .success, .fail {
            display: block;
            padding: 3px;
            margin: 3px;
            border: solid 1px darkgreen;
            background-color: Green;
            color: White;
        }

        .fail {
            background-color: Red;
            border: solid 1px darkred;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
           
            <p style="text-align: left;">
                To validate the credit card generator, please enter a credit card number in the textbox below. If you do 
    not want to use a real credit card number, you can use one of these fake numbers:    
            </p>
            <ul style="text-align: justify;">
                <li><b>MasterCard:</b>
                    <asp:Label runat="server" ForeColor="Green" ID="lblMc"></asp:Label></li>
                <li><b>Visa:</b>
                    <asp:Label runat="server" ForeColor="Green" ID="lblVisa"></asp:Label></li>
                <li><b>American Express:</b>
                    <asp:Label runat="server" ForeColor="Green" ID="lblAmex"></asp:Label></li>
                <li><b>Discover:</b>
                    <asp:Label runat="server" ForeColor="Green" ID="lblDisc"></asp:Label></li>
                 <li><b>Diners Club:</b>
                    <asp:Label runat="server" ForeColor="Green" ID="lblDin"></asp:Label></li>
                <li><b>JCB:</b>
                    <asp:Label runat="server" ForeColor="Green" ID="lblJCB"></asp:Label></li>
                
               
            </ul>
            <br /><br /><br />
          <p style="text-align: left; ">
                <asp:Label runat="server" ID="lblCardName"  AssociatedControlID="dlCardName"  Text="Generate Number:" Font-Bold="true" />
                <asp:DropDownList runat="server" ID="dlCardName"  ForeColor="DarkBlue"   Width="158px">
                     <asp:ListItem>American Express</asp:ListItem>
                     <asp:ListItem>Diners</asp:ListItem>
                     <asp:ListItem>Discover</asp:ListItem>
                     <asp:ListItem>Enroute</asp:ListItem>
                     <asp:ListItem>JCB Sixteen</asp:ListItem>
                     <asp:ListItem>JCB Fifteen</asp:ListItem>
                     <asp:ListItem>MasterCard</asp:ListItem>
                     <asp:ListItem>Rewards</asp:ListItem>
                     <asp:ListItem>Tgn Gift Card</asp:ListItem>
                     <asp:ListItem>Tgn Promo Card</asp:ListItem>
                     <asp:ListItem>Visa</asp:ListItem>
                     <asp:ListItem>Voyager</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:Button runat="server" ID="btnGenerate"  ForeColor="DarkBlue"  Text="Generate Number"
                    OnClick="btnGenerate_Click" />
            </p>
            <p style="text-align: left; ">
                <asp:Label runat="server" ID="lblCardText"  AssociatedControlID="txtCard"  Text="Card Number:" Font-Bold="true" />
                <radI:RadTextBox runat="server" ID="txtCard" Width="190px" EmptyMessage="Enter number">
                    <FocusedStyle Font-Size="12px" />
                    <EmptyMessageStyle Font-Size="12px" ForeColor="darkgray" />
                    <HoveredStyle Font-Size="12px" />
                    <EnabledStyle Font-Size="12px" />
                </radI:RadTextBox>
                &nbsp;<asp:Button runat="server" ID="btnValidate" Width="123px" ForeColor="DarkBlue"  Text="Validate Number"
                    OnClick="btnValidate_Click" />
            </p>
            <p>
                <asp:Label runat="server" ID="lblMsg"></asp:Label>
            </p>
        </div>
     
            <div id="footer">
                
                    <div class="w-copyright">Copyright © 2018 Luis Vieira Assignment . Rights reserved.
                                      
                        <br /><br />
                       </div>
                    
                
            </div>

            <radA:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="AjaxLoadingPanel1">
                <AjaxSettings>
                    <radA:AjaxSetting AjaxControlID="btnValidate">
                        <UpdatedControls>
                            <radA:AjaxUpdatedControl ControlID="lblMsg" />
                        </UpdatedControls>
                    </radA:AjaxSetting>
                    <radA:AjaxSetting AjaxControlID="btnGenerate">
                        <UpdatedControls>
                            <radA:AjaxUpdatedControl ControlID="txtCard" />
                        </UpdatedControls>
                    </radA:AjaxSetting>
                </AjaxSettings>
            </radA:RadAjaxManager>
            <radA:AjaxLoadingPanel ID="AjaxLoadingPanel1" runat="server" BackColor="white" Transparency="30" MinDisplayTime="400">
                
            </radA:AjaxLoadingPanel>
    </form>

</body>

</html>
