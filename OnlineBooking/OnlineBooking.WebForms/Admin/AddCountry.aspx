<%@ Page Title="Add Country" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCountry.aspx.cs" Inherits="OnlineBooking.WebForms.Admin.AddCountry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <section id="add-country-form">
            <asp:PlaceHolder runat="server" ID="AddCountryPlHolder">
                <div class="form-horizontal">
                    <h5>Add new country to the master list.</h5>
                    <hr />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="CountryName" CssClass="col-md-2 control-label">Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="CountryName" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="CountryNameValidator" ControlToValidate="CountryName"
                                CssClass="text-danger"
                                Display="Dynamic"
                                ErrorMessage="The name field is required!"
                                runat="server">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="AddCountryBtn" runat="server" Text="Add" OnClick="AddCountryBtn_Click" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </section>
    </div>
</asp:Content>
