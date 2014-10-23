<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PlaceDetails.aspx.cs" Inherits="OnlineBooking.WebForms.Account.PlaceDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2 class="inline-heading col-lg-3"><%: this.CurrentPlace.Name %></h2>
        <div id="place-stars">
            <asp:Repeater ID="starsRepeater" runat="server">
                <ItemTemplate>
                    <asp:Image ImageUrl="~/Content/Images/star.png" Width="38" Height="35" runat="server" CssClass="starImage" />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <br />
    <div class="pull-right avatar">
        <asp:Image ImageUrl='<%#this.CurrentPlace.ImagePath%>' Id="PlaceImage"  Width="250" Height="250" runat="server" />
    </div>
    <div class="row inlile-row" >
        <span class="col-lg-4">Location: </span>
        <span class="col-lg-4 booking-det-value"><%: this.CurrentPlace.City.Name %>, <%: this.CurrentPlace.City.Country.Name %></span>
    </div>
    <br/>
    <div class="row inlile-row">
        <span class="col-lg-4">Phone Number: </span>
        <span class="col-lg-4 booking-det-value"><%:this.CurrentPlace.Phone %></span>
    </div>
    <br />
    <div class="row inlile-row">
        <span class="col-lg-4">Email: </span>
        <span class="col-lg-4 booking-det-value"><%:this.CurrentPlace.Email %></span>
    </div>
    <br />
    <div class="row inlile-row">
        <span class="col-lg-4">Capacity: </span>
        <span class="col-lg-4    booking-det-value"><%:this.CurrentPlace.Capacity %></span>
    </div>
    <br />
    <asp:Panel ID="AdminOptions" runat="server">
        <div class="row inline-row">
            <span class="col-lg-3">Nights: </span>    
            <span class="col-md-3">
                <asp:Button ID="AddNigthButton" runat="server" Text="Add" CssClass="btn btn-primary"
                            CommandName="AddNigthBtn"
                            CommandArgument="<%# this.CurrentPlace.Id %>"
                            OnCommand="AddNigthBtn_Command" />
            </span>
        </div>
    </asp:Panel>
    <div class="row well nights-top-margin">
        <table class="table table-striped table-hover ">
            <thead>
                <tr>
                    <th>Type</th>
                    <th>Basis</th>
                    <th>Price</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="NightsList" runat="server" ItemType="OnlineBooking.WebForms.Models.Night">
                    <ItemTemplate>
                        <tr>
                            <td><%#: Item.Type %></td>
                            <td><%#: Item.Basis %></td>
                            <td><%#: Item.Price %></td>  
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

            <br />

        <div class="row">
            <span class="col-md-3">
                <asp:Button ID="BookBtn" runat="server" Text="Book" CssClass="btn btn-success" OnCommand="BookBtn_Command"  />
            </span>       
        </div>
    </div>


</asp:Content>
