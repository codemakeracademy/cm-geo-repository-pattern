<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CountryEdit.aspx.cs" Inherits="CM.GeoManagement.WebForms.CountryEdit" %>
<%@ Import Namespace="CM.GeoManagement.BusinessEntities" %>
<%@ Register Src="~/RegionControl.ascx" TagPrefix="cc" TagName="RegionControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="form-group">
        <asp:Label runat="server" Text="Country Code"></asp:Label>
        <asp:TextBox ID="countryCode" Text='<%# Country.CountryCode %>' CssClass="form-control" runat="server"></asp:TextBox>
    </div>    
    
    <div class="form-group">
        <asp:Label runat="server" Text="Country Name"></asp:Label>
        <asp:TextBox ID="countryName" Text='<%# Country.CountryName %>'  CssClass="form-control" runat="server"></asp:TextBox>
     </div>

    <asp:Button runat="server" CssClass="btn btn-primary" 
                OnClick="OnSaveClick" 
                Text="Save" />
    
    
    <asp:Button runat="server" CssClass="btn btn-default" 
                OnClick="AddRegion" 
                Text="Add Region" />

    <asp:Repeater ID="regionsRepeater" ItemType="CM.GeoManagement.BusinessEntities.Region" runat="server">
        <ItemTemplate>
            <asp:HiddenField ID="countryCode" Value='<%# Eval("CountryCode") %>' runat="server"/>

            <div class="form-group">
                <asp:Label runat="server" Text="Region Code"></asp:Label>
                <asp:TextBox ID="regionCode" Text='<%# Eval("RegionCode") %>' CssClass="form-control" runat="server"></asp:TextBox>
            </div>  
    
            <div class="form-group">
                <asp:Label runat="server" Text="Region Name"></asp:Label>
                <asp:TextBox ID="regionName" Text='<%# Eval("RegionName") %>'  CssClass="form-control" runat="server"></asp:TextBox>
            </div> 

        </ItemTemplate>
    </asp:Repeater>

  
</asp:Content>
