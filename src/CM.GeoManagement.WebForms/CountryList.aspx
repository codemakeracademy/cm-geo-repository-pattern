<%@ Page Title="Countries" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CountryList.aspx.cs" Inherits="CM.GeoManagement.WebForms.CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <table class="table">
        <% foreach (var country in Countries) { %>

            <tr><td><a href="CountryEdit?countryCode=<%= country.CountryCode %>"><%= country.CountryCode %></a></td><td><%= country.CountryName %></td></tr>

        <% } %>
    </table>

</asp:Content>
