<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:GridView
        ID="MovieGrid"
        onselectedindexchanged="MovieGrid_SelectedIndexChanged"
        runat="server"
        AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField ItemStyle-Width="150px" DataField="MovieID" HeaderText="Movie ID" />
            <asp:BoundField ItemStyle-Width="150px" DataField="MovieTitle" HeaderText="Movie Title" />
            <asp:BoundField ItemStyle-Width="150px" DataField="MovieRating" HeaderText="Movie Rating" />
            <asp:BoundField ItemStyle-Width="150px" DataField="ReleaseYear" HeaderText="Release Year" />
        </Columns>
    </asp:GridView>
    <asp:TextBox ID="MovieIDTextBox" Columns="2" MaxLength="3" Text="1" runat="server"/>
    <asp:TextBox ID="MovieTitleTextBox" Columns="2" MaxLength="3" Text="1" runat="server"/>
    <asp:TextBox ID="MovieRatingTextBox" Columns="2" MaxLength="3" Text="1" runat="server"/>
    <asp:TextBox ID="YearReleasedTextBox" Columns="2" MaxLength="3" Text="1" runat="server"/>
</asp:Content>

