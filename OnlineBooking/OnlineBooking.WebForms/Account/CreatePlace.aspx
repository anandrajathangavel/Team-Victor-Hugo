﻿<%@ Page Title="Create a Place" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePlace.aspx.cs" Inherits="OnlineBooking.WebForms.Account.CreatePlace" %>

<%@ Register src="~/Controls/LocationDropDown.ascx" tagname="LocationDropDown" tagprefix="place" %>

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
                            <asp:RequiredFieldValidator  ID="RequiredFieldValidatorPlaceName" ControlToValidate="PlaceName" runat="server"      Display="Dynamic" ErrorMessage="The place name is required!" CssClass="text-danger" /><br/>
                        </div>
                        <asp:Label runat="server" AssociatedControlID="PlaceName" CssClass="col-md-2 control-label">Picture</asp:Label>
                        <div class="col-md-10">
                            <asp:FileUpload ID="FileUploadControl" runat="server" CssClass="form-control form-control-tweak"/>
                        </div>
                    </div>
                    <place:LocationDropDown ID="Location" runat="server" />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Stars" CssClass="col-md-2 control-label">Stars</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Stars" TextMode="Number" CssClass="form-control form-control-tweak" />
                            <asp:RangeValidator ID="StarsRangeValidator" ControlToValidate="Stars"
                                Type="Integer" MinimumValue="1" MaximumValue="6" CssClass="text-danger" Display="Dynamic"
                                ErrorMessage="Please enter an integer <br /> between 1 and 6.<br />"
                                runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Capacity" CssClass="col-md-2 control-label">Capacity</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Capacity" TextMode="Number" CssClass="form-control form-control-tweak" />
                            <asp:RangeValidator ID="CapacityRangeValidator" ControlToValidate="Capacity"
                                Type="Integer" MinimumValue="1" MaximumValue="10000" CssClass="text-danger" Display="Dynamic"
                                ErrorMessage="Please enter an integer <br /> between 1 and 10 000.<br />"
                                runat="server" />
                        </div>
                    </div>
                    <br/>
                    <h4>Additional Information</h4>
                    <hr />
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
