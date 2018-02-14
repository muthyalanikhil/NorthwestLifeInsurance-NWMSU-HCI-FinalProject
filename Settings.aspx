<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Settings.aspx.cs" Inherits="Settings" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3 style="text-align: center;">Manage Users</h3>
    <br />
    <asp:GridView ID="usersGV" runat="server" OnRowDataBound="usersGV_RowDataBound" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Style="color: #333333; width: 98%; margin-left: 10px;">
        <AlternatingRowStyle BackColor="#f2f4f7" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="user Id" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"></asp:BoundField>
            <asp:BoundField DataField="userName" HeaderText="User Name" />
            <asp:BoundField DataField="role" HeaderText="user Id" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"></asp:BoundField>
            <asp:BoundField DataField="isBlocked" HeaderText="user Id" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"></asp:BoundField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="resetPassword" OnClick="resetPassword_Click" runat="server" Text="Reset Password" CssClass="btn btn-success"></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="userRole" OnClick="userRole_Click" runat="server" Text="Make Agent" CssClass="btn btn-success"></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="blockUser" OnClick="blockUser_Click" runat="server" Text="Blocked" CssClass="btn btn-danger"></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#6399c5" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6399c5" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#eeeeee" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>
