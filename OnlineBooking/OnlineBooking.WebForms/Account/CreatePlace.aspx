<%@ Page Title="Create a Place" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePlace.aspx.cs" Inherits="OnlineBooking.WebForms.Account.CreatePlace" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <section id="create-place-form">
            <asp:PlaceHolder runat="server" ID="CreatePlacePlHolder">
                <div class="form-horizontal">
                    <h5>If you are an owner of a hotel/motel, you can add it to our database via this form</h5>
                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                    <hr />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PlaceName" CssClass="col-md-2 control-label">Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PlaceName" CssClass="form-control" />
<%--                            <asp:RequiredFieldValidator runat="server" ControlToValidate="password"
                                CssClass="text-danger" ErrorMessage="The password field is required."
                                Display="Dynamic" ValidationGroup="SetPassword" />
                            <asp:ModelErrorMessage runat="server" ModelStateKey="NewPassword" AssociatedControlID="password"
                                CssClass="text-danger" SetFocusOnError="true" />--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="CountriesList" CssClass="col-md-2 control-label">Country</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="CountriesList" AutoPostBack="true" OnSelectedIndexChanged="CountriesList_SelectedIndexChanged" CssClass="form-control form-control-tweak">
                            </asp:DropDownList>
<%--                            <asp:RequiredFieldValidator runat="server" ControlToValidate="confirmPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required."
                                ValidationGroup="SetPassword" />--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="CitiesList" CssClass="col-md-2 control-label">City</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="CitiesList" CssClass="form-control form-control-tweak">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Stars" CssClass="col-md-2 control-label">Stars</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Stars" TextMode="Number" CssClass="form-control form-control-tweak" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Capacity" CssClass="col-md-2 control-label">Capacity</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Capacity" TextMode="Number" CssClass="form-control form-control-tweak" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" TextMode="Email" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Phone" CssClass="col-md-2 control-label">Phone</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Phone" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="CreatePlaceBtn" runat="server" Text="Create" ValidationGroup="SetPassword" OnClick="CreatePlace_Click" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </section>
    </div>
</asp:Content>
