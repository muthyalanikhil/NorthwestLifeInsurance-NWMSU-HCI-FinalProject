<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Payments.aspx.cs" Inherits="Payments" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <style>
        .panel-title {
            display: inline;
            font-weight: bold;
        }

        .checkbox.pull-right {
            margin: 0;
        }

        .pl-ziro {
            padding-left: 0px;
        }
    </style>   
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-xs-12 col-md-4" style="max-width: 300px;">
                <h3 style="text-align: center;">Payment Portal</h3>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Payment Details
                    </h3>
                        <div class="checkbox pull-right">
                            <label>
                                <input type="checkbox" />
                                Remember       
                            </label>
                        </div>
                    </div>
                    <div class="panel-body">
                            <div class="form-group">
                                <label for="cardNumber">
                                    CARD NUMBER</label>
                                <div class="input-group">
                                    <input type="text" class="form-control" id="cardNumber" placeholder="Valid Card Number"
                                        required autofocus />
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-7 col-md-7">
                                    <div class="form-group">
                                        <label for="expityMonth">
                                            EXPIRY DATE</label>
                                        <div class="col-xs-6 col-lg-6 pl-ziro">
                                            <input type="text" class="form-control" id="expityMonth" placeholder="MM" required />
                                        </div>
                                        <div class="col-xs-6 col-lg-6 pl-ziro">
                                            <input type="text" class="form-control" id="expityYear" placeholder="YY" required />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-5 col-md-5 pull-right">
                                    <div class="form-group">
                                        <label for="cvCode">
                                            CV CODE</label>
                                        <input type="password" class="form-control" id="cvCode" placeholder="CV" required />
                                    </div>
                                </div>
                            </div>
                    </div>
                </div>
                <br />
                <asp:Button runat="server" ID="pay" OnClick="pay_Click" Text="Pay" CssClass="btn btn-success btn-lg btn-block" />
            </div>
            <div class="col-md-4">
            </div>
        </div>
    </div>
</asp:Content>
