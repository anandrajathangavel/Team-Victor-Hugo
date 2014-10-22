<%@ Page Title="Add City" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCity.aspx.cs" Inherits="OnlineBooking.WebForms.Admin.AddCity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <section id="add-city-form">
            <asp:PlaceHolder runat="server" ID="AddCityPlHolder">
                <div class="form-horizontal">
                    <h5>Add new city to a corresponding country.</h5>
                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                    <hr />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="CountriesList" CssClass="col-md-2 control-label">Country</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="CountriesList" CssClass="form-control form-control-tweak">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="CityName" CssClass="col-md-2 control-label">City Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="CityName" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="AddCityBtn" runat="server" Text="Add" OnClick="AddCity_Click" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </section>
    </div>
</asp:Content>
