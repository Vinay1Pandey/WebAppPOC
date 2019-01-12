<%@ Page Title="AddRevenueData" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRevenueData.aspx.cs" Inherits="BSNL.AddRevenueData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <h1 class="page-header">Add Revenue Data</h1>
    </div>
    <!-- /.col-lg-12 -->

    <div class="row">

        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    Add New Data
                </div>
                <div class="panel-body">

                    <div class="form-group">

                        <div class="row">
                            <div class="col-lg-6">
                                <label>Bill Date<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="txtBillDate" runat="server" CssClass="form-control" TextMode="Date" onkeypress="return false;"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtBillDate"
                                    ErrorMessage="Bill Date can't be blank !" />
                            </div>
                            <div class="col-lg-6">
                                <label>Customer ID<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="txtCustID" runat="server" TextMode="Number" step="1" min="100000000" max="10000000000" CssClass="form-control" placeholder="Customer ID"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtCustID"
                                    ValidationExpression="^[0-9]+$" ErrorMessage="*Invalid Customer ID !" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtCustID"
                                    ErrorMessage="Invalid Customer ID !" />
                                <asp:Label ID="lblcustID" runat="server" ForeColor="Red"></asp:Label>

                            </div>


                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">

                            <div class="col-lg-6">
                                <label>Bill Amount<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="txtBillAmt" runat="server" value="0" CssClass="form-control" MaxLength="4" placeholder="Bill Amount"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtBillAmt"
                                    ErrorMessage="Bill Amount can't be blank !" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtBillAmt"
                                    ValidationExpression="[0-9.]*$" ErrorMessage="Invalid Bill Amount !" />
                            </div>
                            <div class="col-lg-6">
                                <label>Penalty<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="txtPenalty" runat="server" value="0" CssClass="form-control" MaxLength="4" placeholder="Avg Monthly Billing"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtPenalty"
                                    ErrorMessage="Penalty can't be blank !" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtPenalty"
                                    ValidationExpression="[0-9.]*$" ErrorMessage="Invalid Penalty !" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">

                            <div class="col-lg-6">
                                <label>Reminder<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="txtReminder" runat="server" value="0" TextMode="Number" step="1" min="0" max="1000000000" CssClass="form-control" placeholder="Reminder"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtReminder"
                                    ValidationExpression="^[0-9]+$" ErrorMessage="*Invalid Customer ID !" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtReminder"
                                    ErrorMessage="Invalid Customer ID !" />
                                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>

                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-3 pull-right">
                            <div class="col-sm-2s pull-right">
                                <asp:Button ID="UnDoButton" runat="server" Style="float: right;" CssClass="btn btn-danger btn-md" Text="Cancel" CausesValidation="false" PostBackUrl="~/Dashboard.aspx" />

                            </div>
                            <div class="col-sm-2s pull-left">
                                <asp:Button ID="btnSave" runat="server" Style="float: right;" CssClass="btn btn-success btn-md" Text="Save" OnClick="btnSave_Click" />
                            </div>
                        </div>

                    </div>
                </div>


            </div>

            <!-- /.col-lg-12 -->
        </div>

    </div>
</asp:Content>
