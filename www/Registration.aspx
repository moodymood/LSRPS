<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGuest.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="RegistrationHeadContent" ContentPlaceHolderID="headGuest" Runat="Server">
</asp:Content>

<asp:Content ID="RegistrationBodyContent" ContentPlaceHolderID="bodyGuest" Runat="Server">

    <div>      
        <table>
            <tr>
                <td class="auto-style1">Username</td>
                <td>
                    <asp:TextBox id="UserNameRegistration" OnChange="UserNameRegistrationChange();" runat="server" MaxLength="25" Width="190px"></asp:TextBox>  
        
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Date of Birth</td>
                <td>
                    <asp:DropDownList ID="ddlYear" runat="server" CausesValidation="True" ValidationGroup="UserName" onchange = "PopulateDays()" />
                    <asp:DropDownList ID="ddlMonth" runat="server" CausesValidation="True" ValidationGroup="UserName"  onchange = "PopulateDays()" />
                    <asp:DropDownList ID="ddlDay" CausesValidation="True" ValidationGroup="UserName" runat="server" />
                </td>
            </tr>        
            <tr>
                 <td class="auto-style1"></td>
                 <td>
                     or<asp:LinkButton ID="LoginButton" runat="server" CausesValidation="False" PostBackUrl="~/Login.aspx"> login</asp:LinkButton>
                 </td>
            </tr>
            <tr>
                <td class="auto-style1"></td> 
                <td style="padding-left: 120px;" >
                    <asp:Button ID="RegistrationButton" OnClick="User_Registration_Click" CausesValidation="True" ValidationGroup="UserName"  Text="Register" runat="server"/> 
                </td>
            </tr>
        </table>    
    </div>  

    <div class="DDmessageError">
        <asp:Label ID="RegistrationMessage" Text="" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredValidator" runat="server" ControlToValidate="UserNameRegistration"
            ErrorMessage="Username can't be blank" Display="Dynamic" ValidationGroup="UserName" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" 
            ValidationExpression="^[a-zA-Z0-9]{5,25}$" ControlToValidate="UserNameRegistration"
            ErrorMessage="Choose only letter/digits, at least five"  Display="Dynamic" ValidationGroup="UserName" /> 
    </div>    

<script type="text/javascript">

    function PopulateDays() { 
        var ddlMonth = document.getElementById("<%=ddlMonth.ClientID%>");
        var ddlYear = document.getElementById("<%=ddlYear.ClientID%>");
        var ddlDay = document.getElementById("<%=ddlDay.ClientID%>");
        var y = ddlYear.options[ddlYear.selectedIndex].value;
        var m = ddlMonth.options[ddlMonth.selectedIndex].value;
        var dayCount = 32 - new Date(ddlYear.options[ddlYear.selectedIndex].value, ddlMonth.options[ddlMonth.selectedIndex].value - 1, 32).getDate();
        ddlDay.options.length = 0;
        for (var i = 1; i <= dayCount; i++) {
            AddOption(ddlDay, i, i);
        } 
    }

    function AddOption(ddl, text, value) {
        var opt = document.createElement("OPTION");
        opt.text = text;
        opt.value = value;
        ddl.options.add(opt);
    }

    function UserNameRegistrationChange() {
        // Do nothing if client validation is not active
        if (typeof (Page_Validators) == "undefined") return;
        // Change the color of the label
        bodyGuest_RegistrationMessage.textContent = "";
    }

</script>

</asp:Content>

