<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="gameHeadContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="gameBodyContent" ContentPlaceHolderID="body" Runat="Server">

    <div id="GameDiv">
        <asp:Image ID="RPSLSImage" ImageUrl="DynamicData/Content/Images/RPSLS.png" runat="server"/>
        <br />
        <div class="DDgameInstr">
            <asp:Label ID="Instruction" Text="" runat="server" >[<asp:HyperLink ID="RulesLink" runat="server" NavigateUrl="http://en.wikipedia.org/wiki/Rock-paper-scissors-lizard-Spock">?</asp:HyperLink>] Make your choice:</asp:Label>
        </div> 
        <table class="DDGameTable" >      
            <tr>
                <td><div ID="ScissorsDiv" class="DDGameButton"><asp:LinkButton ID="ScissorsButton"  OnClick="PlayGame_Click" runat="server">Scissors</asp:LinkButton></div></td>
                <td><div ID="PaperDiv" class="DDGameButton"><asp:LinkButton ID="PaperButton"  OnClick="PlayGame_Click" runat="server">Paper</asp:LinkButton></div></td>
                <td><div ID="RockDiv" class="DDGameButton"><asp:LinkButton ID="RockButton"  OnClick="PlayGame_Click" runat="server">Rock</asp:LinkButton></div></td>     
                <td><div ID="LizardDiv" class="DDGameButton"><asp:LinkButton ID="LizardButton"  OnClick="PlayGame_Click" runat="server">Lizad</asp:LinkButton></div></td>
                <td><div ID="SpokDiv" class="DDGameButton"><asp:LinkButton ID="SpokButton" OnClick="PlayGame_Click" runat="server">Spok</asp:LinkButton></div></td>
            </tr>
        </table>        
    </div> 

    <div class="DDgameMessage">
        <asp:Label ID="RPSLSResult" Text="" runat="server" ></asp:Label>
    </div>

</asp:Content>
