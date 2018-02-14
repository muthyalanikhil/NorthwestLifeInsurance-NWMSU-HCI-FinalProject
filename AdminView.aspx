<%@ Page Title="Admin" EnableEventValidation="true"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="AdminView.aspx.cs" Inherits="AdminView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       <style type="text/css">
        .hiddencol {
            display: none;
        }
    </style>
     <div class="form-horizontal">
        <h4>Create a new Policy.</h4>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="policyNameTB" CssClass="col-md-2 control-label">Policy Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="policyNameTB" CssClass="form-control" />
                <br />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="premiumAmountTB" CssClass="col-md-2 control-label">Premium Amount</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="premiumAmountTB" CssClass="form-control"/>
                <asp:RegularExpressionValidator ID="revNumber" runat="server" ControlToValidate="premiumAmountTB"
          ErrorMessage="Enter valid amount" ValidationExpression="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$"></asp:RegularExpressionValidator>
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="descriptionTB" CssClass="col-md-2 control-label">Policy Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="descriptionTB" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="CreatePolicy" OnClick="CreatePolicy_Click" Text="Create Policy" CssClass="btn btn-success" />
            </div>
        </div>
    </div>
    <br />
    <hr />
     <asp:GridView ID="policyListGV" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Style="color: #333333; width: 98%; margin-left: 10px;">
            <AlternatingRowStyle BackColor="#f2f4f7" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"></asp:BoundField>
                <asp:BoundField DataField="policyName" HeaderText="Policy Name" />
                <asp:BoundField DataField="description" HeaderText="Description" />
                <asp:BoundField DataField="amount" HeaderText="Amount"></asp:BoundField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="deletePolicy" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="deletePolicy_Click"></asp:Button>
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
