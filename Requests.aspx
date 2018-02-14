<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Requests.aspx.cs" Inherits="Requests" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <style type="text/css">
        .hiddencol {
            display: none;
        }
    </style>
    <h3 style="text-align: center;">Current Requests</h3>
    <br />
    <asp:GridView ID="requestsGV" runat="server" OnRowDataBound="requestsGV_RowDataBound" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Style="color: #333333; width: 98%; margin-left: 10px;">
        <AlternatingRowStyle BackColor="#f2f4f7" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="userId" HeaderText="user Id" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"></asp:BoundField>
            <asp:BoundField DataField="policyId" HeaderText="policy Id" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"></asp:BoundField>
            <asp:BoundField DataField="userName" HeaderText="User Name" />
            <asp:BoundField DataField="email" HeaderText="Email" />
            <asp:BoundField DataField="policyName" HeaderText="Policy Name"></asp:BoundField>
            <asp:BoundField DataField="policyPremium" HeaderText="Premium" />
             <asp:BoundField DataField="isAccepted" HeaderText="status" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"></asp:BoundField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="changeStatus" runat="server" Text="Pending" CssClass="btn btn-danger" OnClick="changeStatus_Click"></asp:Button>
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
