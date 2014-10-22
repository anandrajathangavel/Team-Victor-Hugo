<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineBooking.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="home-intro" class="jumbotron">
        <h1>GoBook</h1>
        <p class="lead">Find the perfect place for your weekend adventure or well-planned holiday with just few clicks!</p>
        <p><a href="Account/Register" class="btn btn-primary btn-lg">Register Now &raquo;</a></p>
    </div>

    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <LoggedInTemplate>
            You are logged in now
        </LoggedInTemplate>
    </asp:LoginView>

    <div class="row">
         <asp:Repeater ID="DataListPlaces" runat="server"
            ItemType="OnlineBooking.WebForms.Models.Place">
            <ItemTemplate>
                <div class="col-md-4">
                    <h2><%#: Item.Name %></h2>
                    <p><%#: Item.City.Name %>, <%#: Item.City.Country.Name %></p>
                    <p><a class="btn btn-default" href="#">To the place</a></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
