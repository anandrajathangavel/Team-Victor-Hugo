<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineBooking.WebForms._Default" %>

<%@ Register src="~/Controls/LocationDropDown.ascx" tagname="LocationDropDown" tagprefix="place" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="home-intro" class="jumbotron">
        <h1><img src="/Content/Images/logo_title.png" width="280" height="69" alt="GoBook" /></h1>
        <p class="lead">Find the perfect place for your weekend adventure or well-planned holiday with just few clicks!</p>
        <p><a href="Account/Register" class="btn btn-primary btn-lg">Register Now &raquo;</a></p>
    </div>

    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <LoggedInTemplate>
            You are logged in now
        </LoggedInTemplate>
    </asp:LoginView>

    <div class="form-horizontal">
        <section id="search-form">
            <asp:PlaceHolder runat="server" ID="SearchPlHolder">
                <div class="form-horizontal">
                    <h2>Search</h2>
                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                    <div class="search-form-tw">
                        <place:LocationDropDown ID="LocationSelect" runat="server" />
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="Stars" CssClass="col-md-2 control-label">Stars</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="Stars" TextMode="Number" CssClass="form-control form-control-tweak" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-10">
                                c
                            </div>
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </section>
    </div>

    <div class="row">
         <asp:Repeater ID="DataListPlaces" runat="server"
            ItemType="OnlineBooking.WebForms.Models.Place">
            <ItemTemplate>
                <div class="col-md-4">
                    <h3><%#: Item.Name %></h3>
                    <p><%#: Item.City.Name %>, <%#: Item.City.Country.Name %></p>
                    <p>
                        <asp:LinkButton ID="DetailsBtn" runat="server" Text="View place" CssClass="btn btn-success"
                             CommandName="ViewDetails"
                             CommandArgument="<%#: Item.Id %>"
                             OnCommand="DetailsBtn_Command"  />
                    </p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
