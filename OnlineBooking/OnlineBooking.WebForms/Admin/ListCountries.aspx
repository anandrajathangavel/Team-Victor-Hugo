﻿<%@ Page Title="All Countries" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListCountries.aspx.cs" Inherits="OnlineBooking.WebForms.Admin.ListCountries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <%--<asp:ObjectDataSource ID="OdsCountries" runat="server"
            TypeName="OnlineBooking.WebForms.Services.CountryServices" SelectMethod="GetAll" UpdateMethod="UpdateCountry" >
            <UpdateParameters>
                <asp:DynamicControlParameter ControlId="CountriesList" Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>--%>
        <div id="main-grid">
            <asp:GridView ID="CountriesList" runat="server"
                AutoGenerateEditButton="true"
                AutoGenerateColumns="false"
                AllowPaging="true"
                AllowSorting="true"
                OnRowEditing="CountriesList_RowEditing"
                OnRowCancelingEdit="CountriesList_RowCancelingEdit"
                OnRowUpdating="CountriesList_RowUpdating"
                OnPageIndexChanging="CountriesList_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ReadOnly="true" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
