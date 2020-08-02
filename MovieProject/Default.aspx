<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:GridView runat="server" ID="GridView1"
        ItemType="MovieProject.App_Code.Models.Movie" DataKeyNames="MovieID" 
        SelectMethod="MovieGrid_GetData"
        AutoGenerateColumns="false">
        <Columns>
            <asp:DynamicField DataField="MovieID" />
            <asp:DynamicField DataField="MovieTitle" />
            <asp:DynamicField DataField="MovieRating" />
            <asp:DynamicField DataField="ReleaseYear" />                  
        </Columns>
    </asp:GridView>
</asp:Content>

