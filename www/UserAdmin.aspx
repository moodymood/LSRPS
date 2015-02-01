<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserAdmin.aspx.cs" Inherits="UserAdmin" %>

<asp:Content ID="AdminHeadContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="AdminBodyContent" ContentPlaceHolderID="body" Runat="Server">
    
    <h2 class="DDSubHeader">Admin Panel</h2>

    <div>
        <p>This is your admin panel, here you can delete your account if you want.<br />
        N.B <b>if you delete your account you will loose all your statistics</b>.</p>
   
        <asp:Button ID="DeleteUserButton" runat="server" Text="Delete account" OnClientClick="return confirm('Are you sure?');" OnClick="DeleteUser_Click" />
    </div>
    
    <div id="MessageDiv" class="DDmessageError">
        <asp:Label ID="DeleteMessge" Text="" runat="server"></asp:Label>
    </div>    
    
</asp:Content>


