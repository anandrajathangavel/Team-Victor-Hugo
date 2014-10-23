<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LocationDropDown.ascx.cs" Inherits="OnlineBooking.WebForms.Controls.LocationDropDown" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="CountriesList" CssClass="col-md-2 control-label">Country</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="CountriesList" AutoPostBack="true" OnSelectedIndexChanged="CountriesList_SelectedIndexChanged" CssClass="form-control form-control-tweak">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="CitiesList" CssClass="col-md-2 control-label">City</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="CitiesList" CssClass="form-control form-control-tweak">
                </asp:DropDownList>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
