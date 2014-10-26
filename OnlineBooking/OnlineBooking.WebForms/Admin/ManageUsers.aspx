<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="OnlineBooking.WebForms.Admin.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <asp:ObjectDataSource   ID="AllUsers" runat="server"
                            TypeName="OnlineBooking.WebForms.Services.UsersService"
                            SelectMethod="GetAll">
    </asp:ObjectDataSource>
    
    <div id="main-grid">
        <asp:GridView ID="UsersList" DataSourceID="AllUsers" runat="server"
            OnRowCommand="UsersList_RowCommand"
            AutoGenerateColumns="false"
            AllowPaging="true"
            AllowSorting="true">
            <Columns>
                <asp:BoundField DataField="Id" 
                                HeaderText="Id"
                                SortExpression="Id" />

                <asp:BoundField DataField="UserName" 
                                HeaderText="Username"
                                SortExpression="UserName" />
                <asp:BoundField DataField="IsAdmin" 
                                HeaderText="IsAdmin"
                                SortExpression="IsAdmin" />

                <asp:ButtonField ButtonType="Button"
                                ControlStyle-CssClass="btn btn-primary"
                                CommandName="ChangeRole"
                                HeaderText="Change role"
                                Text="Change Role" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
