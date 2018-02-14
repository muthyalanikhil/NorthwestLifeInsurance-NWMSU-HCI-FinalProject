<%@ Page Title="user" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="UserView.aspx.cs" Inherits="UserView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div><h3 style="text-align: center;">All Policies</h3>
        <asp:GridView ID="policyListGV" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Style="color: #333333; width: 98%; margin-left: 10px;">
            <AlternatingRowStyle BackColor="#f2f4f7" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"></asp:BoundField>
                <asp:BoundField DataField="policyName" HeaderText="Policy Name" />
                <asp:BoundField DataField="description" HeaderText="Description" />
                <asp:BoundField DataField="amount" HeaderText="Amount"></asp:BoundField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="buyPolicy" runat="server" Text="Buy" CssClass="btn btn-primary" OnClick="buyPolicy_Click"></asp:Button>
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
   </div>
    <hr />
    <div>
        <h3 style="text-align: center;">Active policies under your account</h3>
        <asp:GridView ID="activePoliciesGV" runat="server" OnRowDataBound="activePoliciesGV_RowDataBound" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Style="color: #333333; width: 98%; margin-left: 10px;">
            <AlternatingRowStyle BackColor="#f2f4f7" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"></asp:BoundField>
                <asp:BoundField DataField="policyName" HeaderText="Policy Name" />
                <asp:BoundField DataField="amount" HeaderText="Amount"></asp:BoundField>
                <asp:BoundField DataField="isAccepted" HeaderText="Status"></asp:BoundField>
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
    </div>
</asp:Content>