<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CountryEdit.aspx.cs" Inherits="CM.GeoManagement.WebForms.CountryEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="form-group">
    <asp:Label runat="server" Text="Country Code"></asp:Label>
    <asp:TextBox ID="countryCode" CssClass="form-control" runat="server"></asp:TextBox>
    </div>    
    
    <div class="form-group">
        <asp:Label runat="server" Text="Country Name"></asp:Label>
        <asp:TextBox ID="countryName" CssClass="form-control" runat="server"></asp:TextBox>
     </div>

    <asp:Button runat="server" CssClass="btn btn-primary" 
                OnClick="OnSaveClick" 
                Text="Save" />
</asp:Content>
