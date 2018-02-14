<%@ Page Title="Northwest Insurance" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="text-align: center;"><%: Title %></h2>
    <div class="row">
        <div class="col-md-6" style="border-right: 1px solid #c9ced2;">
            <br /><br /><br />
            <h5 style="font-size:  15px;line-height:25px;font-weight: 200;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Northwest Insurance can help you find coverage that's right for 
                you and your loved ones. Our life planning videos and calculator 
                can help you understand your options, and figure out how much and 
                what kind is right for you, before getting your life insurance quote.</h5>
            <br /><br /><br /><br /><br /><br />
        </div>
        <div class="col-md-6">
            <iframe width="560" height="315" src="https://www.youtube.com/embed/wxQR5kokq68?start=12" frameborder="0" gesture="media" allow="encrypted-media" allowfullscreen></iframe>
        </div>
    </div>
</asp:Content>
