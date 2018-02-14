<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3 style="text-align: center;">Update your Profile</h3>
    <br />
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="userName" CssClass="col-md-2 control-label">Name: </asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="userName" CssClass="form-control" />
        </div>
    </div>
    <br /> <br />
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="email" CssClass="col-md-2 control-label">Email: </asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="email" CssClass="form-control" />
        </div>
    </div>
    <br /> <br />
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="addressLine1" CssClass="col-md-2 control-label">Address Line 1: </asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="addressLine1" CssClass="form-control" />
        </div>
    </div>
    <br /> <br />
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="addressLine2" CssClass="col-md-2 control-label">Address Line 2: </asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="addressLine2" CssClass="form-control" />
        </div>
    </div>
    <br /> <br />
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="phone" CssClass="col-md-2 control-label">Phone: </asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="phone" CssClass="form-control" />
        </div>
    </div>
    <br /> <br />
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <asp:Button runat="server" ID="updateProfile" OnClick="updateProfile_Click"
                Text="Update Profile" CssClass="btn btn-success" />
        </div>
    </div>
</asp:Content>
