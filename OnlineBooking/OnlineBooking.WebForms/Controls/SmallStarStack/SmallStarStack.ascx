<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SmallStarStack.ascx.cs" Inherits="OnlineBooking.WebForms.Controls.SmallStarStack.SmallStarStack" %>

<div id="star-stack">
    <asp:Repeater ID="StarStack" runat="server">
        <ItemTemplate>
            <div class="small-star"></div>
        </ItemTemplate>
    </asp:Repeater>
</div>