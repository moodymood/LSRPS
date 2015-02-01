<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGuest.master" AutoEventWireup="true" CodeFile="NotFound.aspx.cs" Inherits="Default2" %>

<asp:Content ID="NotFoundHeadContent" ContentPlaceHolderID="headGuest" Runat="Server">
</asp:Content>
<asp:Content ID="NotFoundBodyContent" ContentPlaceHolderID="bodyGuest" Runat="Server">
    <br />
    Page not found!
    <br /><br /><br />
    <asp:LinkButton ID="GoHome" runat="server" OnClick="Go_Back">Go Home</asp:LinkButton>

</asp:Content>

