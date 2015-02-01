<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGuest.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="LoginHeaderContent" ContentPlaceHolderID="headGuest" Runat="Server">
</asp:Content>

<asp:Content ID="LoginHeaderBody" ContentPlaceHolderID="bodyGuest" Runat="Server">
    
    <div>     
          <table class="DDUserTable">
            <tr>
                <td class="auto-style1">Username</td>
                <td>
                    <asp:TextBox ID="UserNameLogin" OnChange="UserNameLoginChange();" Text="" MaxLength="25" runat="server" Width="190px"/>

                </td>
            <tr>
                <td class="auto-style1"></td>
                <td>
                    or<asp:LinkButton ID="RegistrationButton"  CausesValidation="false"  runat="server" PostBackUrl="~/Registration.aspx"> register</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td style="padding-left: 120px;">
                    <asp:Button ID="LoginButton" OnClick="UserLogin_Click" CausesValidation="true" ValidationGroup="userName" Text="Log In" runat="server"/>
                </td>
            </tr>
          </table>   
    </div>
    <div class="DDmessageError">
        <asp:Label ID="LoginMessage" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredValidator" runat="server" ControlToValidate="UserNameLogin"
            ErrorMessage="Username can't be blank" Display="Dynamic" ValidationGroup="userName" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" 
            ValidationExpression="^[a-zA-Z0-9]{5,25}$" Display="Dynamic" ControlToValidate="UserNameLogin"
            ErrorMessage="Choose only letter/digits, at least five" ValidationGroup="userName" />
    </div>
  
    
    
    
    <script type="text/javascript">

        function UserNameLoginChange() {
            // Do nothing if client validation is not active
            if (typeof (Page_Validators) == "undefined") return;
            // Change the color of the label
            bodyGuest_LoginMessage.textContent = "";
        }
    </script>  

</asp:Content>

