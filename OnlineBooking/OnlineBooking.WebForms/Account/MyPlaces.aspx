<%@ Page Title="My Places" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyPlaces.aspx.cs" Inherits="OnlineBooking.WebForms.Account.MyPlaces" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <section id="add-city-form">
            <asp:ObjectDataSource ID="OdsPlaces" runat="server"
                TypeName="OnlineBooking.WebForms.Services.PlaceServices" SelectMethod="GetUserPlaces">
                <SelectParameters>
                    <asp:Parameter Name="currentUser" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <div id="main-grid">
                <asp:GridView ID="PlacesList" DataSourceID="OdsPlaces" runat="server"
                    AutoGenerateColumns="false"
                    AllowPaging="true"
                    AllowSorting="true">
                    <Columns>
                        <asp:HyperLinkField 
                            DataTextField="Name" 
                            HeaderText="Place Name" 
                            SortExpression="Name" 
                            DataNavigateUrlFields="ID"
                            DataNavigateUrlFormatString="Account/PlaceDetails?placeId={0}" />
                        <asp:BoundField DataField="Location" HeaderText="Location"
                            SortExpression="Location" />
                        <asp:BoundField DataField="Stars" HeaderText="Stars"
                            SortExpression="Stars" />
                        <asp:BoundField DataField="Capacity" HeaderText="Capacity"
                            SortExpression="Capacity" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone"
                            SortExpression="Phone" />
                    </Columns>
                </asp:GridView>
            </div>
        </section>
    </div>
</asp:Content>
