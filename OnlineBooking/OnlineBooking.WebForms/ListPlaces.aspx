<%@ Page Title="Search Results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPlaces.aspx.cs" Inherits="OnlineBooking.WebForms.ListPlaces" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <section id="add-city-form">
            <asp:ObjectDataSource ID="OdsPlaces" runat="server"
                TypeName="OnlineBooking.WebForms.Models.Place" SelectMethod="GetAll">
                <SelectParameters>
                    <asp:QueryStringParameter Name="country" QueryStringField="Country" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <div id="main-grid">
                <asp:GridView ID="PlacesList" DataSourceID="OdsPlaces" runat="server"
                    AllowPaging="true" AllowSorting="true">
                </asp:GridView>
            </div>
        </section>
    </div>
</asp:Content>
