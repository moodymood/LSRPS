<%@ Page Title="" Language="C#" MasterPageFile="~/SIte.master" AutoEventWireup="true" CodeFile="Statistics.aspx.cs" Inherits="Statistics" %>

<asp:Content ID="statsHeadContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="statsBodyContent" ContentPlaceHolderID="body" Runat="Server">
    
    <h2 class="DDSubHeader">Global statistics</h2>
    
    <div>
        <asp:GridView ID="UserStatsGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="DDGridView" DataSourceID="UserStats" Width="450px" DataKeyNames="user_name" CellPadding="4" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" Font-Size="Small" AllowPaging="True" PageSize="12">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="user_name" HeaderText="User Name" SortExpression="user_name" ReadOnly="True" />
                <asp:BoundField DataField="won" HeaderText="Won games" SortExpression="won" />
                <asp:BoundField DataField="lost" HeaderText="Lost games" SortExpression="lost" />
                <asp:BoundField DataField="drawn" HeaderText="Drawn games" SortExpression="drawn" />  
                <asp:BoundField DataField="tot" HeaderText="Total games " SortExpression="tot" />        
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#888888" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#EBEBEB" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#CCCCCC" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <br />
        <asp:Button ID="ClearStatsButton" runat="server" Text="Clear my results" CssClass="DDBottomHyperLink"  OnClientClick="return confirm('Are you sure?');" OnClick="ClearStats_Click" />
        <br />
    </div>

    <div id="MessageDiv" class="DDmessageError">
        <asp:Label CssClass="MessageError" ID="DeleteStatsMessge" runat="server" Text=""></asp:Label>
    </div>    
    

<asp:SqlDataSource ID="UserStats" runat="server" ConnectionString="<%$ ConnectionStrings:RPSLSConnectionString %>" SelectCommand="SELECT [user_name], [won], [lost], [drawn], [tot] FROM [User]"></asp:SqlDataSource>

</asp:Content>