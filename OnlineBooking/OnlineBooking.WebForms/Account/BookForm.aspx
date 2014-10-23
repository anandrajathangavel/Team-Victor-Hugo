<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="BookForm.aspx.cs" Inherits="OnlineBooking.WebForms.Account.BookForm" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <section id="create-place-form">
            <asp:PlaceHolder runat="server" ID="CreatePlacePlHolder">
                <div class="form-horizontal">
                    <h5>Make your reservation</h5>
                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                    <hr />

                    <div class="form-group">
                        <span class="col-md-2 control-label">Arriving date</span>
                        <div class="col-md-10">
                            <input type="date" name="ArrivingDate" id="ArrivingDate" runat="server" class="form-control form-control-tweak" />
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <span class="col-md-2 control-label">Departure date</span>
                        <div class="col-md-10">
                            <input type="date" name="DeppartureDate" id="DepartureDate" runat="server" class="form-control form-control-tweak" />
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="DataListNights" CssClass="col-md-2 control-label">Nigth options</asp:Label>
                        <div class="col-md-10">
                            <%--<asp:DropDownList runat="server" ID="NightsList" AutoPostBack="true" CssClass="form-control form-control-tweak"></asp:DropDownList>--%>
                            <div class="row">
                                <span class="col-lg-offset-3 col-lg-3">Type </span>
                                <span class="col-lg-3">Basis </span>
                                <span class="col-lg-3">Price </span>
                            </div>
                            <br />

                            <asp:Repeater ID="DataListNights" runat="server"
                                ItemType="OnlineBooking.WebForms.Models.Night">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <asp:Button ID="CreateReservation" runat="server" Text="Create Reservation" CssClass="btn btn-primary"
                                                CommandName="ViewDetails"
                                                CommandArgument="<%#: Item.Id %>"
                                                OnCommand="CreateReservation_Command1" />
                                        </div>
                                        <br />  
                                        <span class="col-lg-3"><%#:Item.Type %></span>
                                        <span class="col-lg-3"><%#:Item.Basis %></span>
                                        <span class="col-lg-3"><%#:Item.Price %></span>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>


                </div>
            </asp:PlaceHolder>
        </section>
    </div>
</asp:Content>

