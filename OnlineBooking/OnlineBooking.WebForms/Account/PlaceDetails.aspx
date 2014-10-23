<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PlaceDetails.aspx.cs" Inherits="OnlineBooking.WebForms.Account.PlaceDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <h2 class="inline-heading col-lg-3"><%: this.currentPlace.Name %></h2>

        <asp:Repeater ID="starsRepeater" runat="server">
            <ItemTemplate>
                <asp:Image ImageUrl="~/images/star.png" runat="server" CssClass="starImage" />
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <br />
    <div class="row">
        <span class="col-lg-3">Phone Number: </span>
        <span class="col-lg-2"><%:this.currentPlace.Phone %></span>
    </div>
    <br />
    <div class="row">
        <span class="col-lg-3">Email: </span>
        <span class="col-lg-2"><%:this.currentPlace.Email %></span>
    </div>
    <br />
    <div class="row">
        <span class="col-lg-3">Capacity: </span>
        <span class="col-lg-2"><%:this.currentPlace.Capacity %></span>
    </div>
    <br />
    <div class="row">
        <span class="col-lg-3">Nights: </span>    

        <%--IF ADMIN OF THE PLACE--%>
        <span class="col-md-3">
            
            <asp:Button ID="AddNigthButton" runat="server" Text="Add" CssClass="btn btn-primary"
                        CommandName="AddNigthBtn"
                        CommandArgument="<%# this.currentPlace.Id %>"
                        OnCommand="AddNigthBtn_Command" />
        </span>
        <%--====================================--%>

    </div>
    <div class="row">
        <br />
        <div class="row">
            <span class="col-lg-offset-3 col-lg-3">Type </span>
            <span class="col-lg-3">Basis </span>
            <span class="col-lg-3">Price </span>
        </div>
        <br />
        <asp:ListView ID="nightsList" runat="server" ItemType="OnlineBooking.WebForms.Models.Night">
            <ItemTemplate>
                <div class="row" style="margin:5px">
                    <span class="col-lg-offset-3 col-lg-3"><%#: Item.Type %></span>
                    <span class="col-lg-3"><%#: Item.Basis %></span>
                    <span class="col-lg-1"><%#: Item.Price %></span>
                                 
                </div>
                
            </ItemTemplate>
        </asp:ListView>
        <div class="row">
            <span class="col-md-3">
                <asp:Button ID="BookBtn" runat="server" Text="Book" CssClass="btn btn-success" OnCommand="BookBtn_Command"  />
            </span>       
        </div>
    </div>


</asp:Content>
