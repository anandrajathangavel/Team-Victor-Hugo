<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddNight.aspx.cs" Inherits="OnlineBooking.WebForms.Account.AddNight" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <section id="create-place-form">
            <asp:PlaceHolder runat="server" ID="CreatePlacePlHolder">
                <div class="form-horizontal">
                    <h5>Add night to your place!</h5>
                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                    <hr />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="RoomTypeList" CssClass="col-md-2 control-label">Room type</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="RoomTypeList" CssClass="form-control form-control-tweak">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="RoomBasisList" CssClass="col-md-2 control-label">Room basis</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="RoomBasisList" CssClass="form-control form-control-tweak">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="RoomPrice" CssClass="col-md-2 control-label">Price per night</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="RoomPrice" TextMode="Number" CssClass="form-control  form-control-tweak" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="AddNightBtn" runat="server" Text="Add" OnClick="AddNightBtn_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </section>
    </div>
</asp:Content>

