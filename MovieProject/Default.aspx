<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:GridView
        ID="MovieGrid"
        OnSelectedIndexChanged="MovieGrid_SelectedIndexChanged"
        CssClass="table table-striped table-bordered table-condensed table-hover"
        runat="server"
        AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="MovieID" HeaderText="Movie ID" />
            <asp:BoundField DataField="MovieTitle" HeaderText="Movie Title" />
            <asp:BoundField DataField="MovieRating" HeaderText="Movie Rating" />
            <asp:BoundField DataField="ReleaseYear" HeaderText="Release Year" />
        </Columns>
    </asp:GridView>
    <asp:Panel runat="server" CssClass="col-md-10">
        <asp:TextBox ID="MovieIDTextBox" Text="Movie ID" CssClass="form-group" ReadOnly="true" runat="server" />
        <asp:TextBox ID="MovieTitleTextBox" Text="Movie Title" CssClass="form-group" ReadOnly="true" runat="server" />
        <asp:TextBox ID="MovieRatingTextBox" Text="Movie Rating" CssClass="form-group" ReadOnly="true" runat="server" />
        <asp:TextBox ID="YearReleasedTextBox" Text="Release Year" CssClass="form-group" ReadOnly="true" runat="server" />
    </asp:Panel>
</asp:Content>

