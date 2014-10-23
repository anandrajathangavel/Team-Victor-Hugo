<%@ Page Title="My Reservations" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  EnableEventValidation="false"  CodeBehind="ReservationsAdministration.aspx.cs" Inherits="OnlineBooking.WebForms.Account.ReservationsAdministration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <table class ="table">
        <thead>
            <tr>
                <th>Place name</th>
                <th>Arriving date</th>
                <th>Departure date</th>
                <%--<th>Room type</th>--%>
                <%--<th>Room basis</th>--%>
                <th>Approve</th>
            </tr>
        </thead>
        <tbody>
            <asp:ListView runat="server" ID="ReservationList" ItemType="OnlineBooking.WebForms.Models.Reservation">
                <ItemTemplate>
                    <tr>
                        <td ><%#: Item.Place.Name %></td>
                        <td ><%#: string.Format("{0:dd/MMMM/yyyy}",Item.ArrivalDate) %></td>
                        <td ><%#: string.Format("{0:dd/MMMM/yyyy}",Item.DepartureDate) %></td>
                        <%--<td ><%#: Item.Night.Type %></td>--%>
                        <%--<td ><%#: Item.Night.Basis %></td>--%>
                        <td >
                            <asp:Button ID="ApproveReservation" runat="server" Text="Approve" CssClass="btn btn-primary"
                                        CommandName="ApproveReservation"
                                        CommandArgument="<%#: Item.Id %>"
                                        OnCommand="ApproveReservation_Command" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </tbody>
    </table>
</asp:Content>
