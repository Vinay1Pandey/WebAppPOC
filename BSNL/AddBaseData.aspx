<%@ Page Title="AddBaseData" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBaseData.aspx.cs" Inherits="BSNL.AddBaseData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-12">
        <h1 class="page-header">Add Base Data</h1>
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
                                <label>Customer Name<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="fName" runat="server" MaxLength="50" CssClass="form-control" placeholder="Customer Name"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorfirstNameTextBox" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="fName"
                                    ValidationExpression="^[A-Za-z][A-Za-z. ]*$" ErrorMessage="Invalid Customer Name !" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="fName"
                                    ErrorMessage="Invalid Customer Name !" />
                            </div>
                            <label>Customer ID<span style="color: red;"> *</span></label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtCustID" runat="server" TextMode="Number" step="1" min="100000000" max="1000000000" CssClass="form-control" placeholder="Customer ID"></asp:TextBox>
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
                                <label>Contact Email<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="mail" runat="server" MaxLength="100" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="mail"
                                    ErrorMessage="Email can't be blank !" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="mail"
                                    ValidationExpression="^\w.+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" ErrorMessage="Invalid Email !" />
                            </div>

                            <div class="col-lg-6">
                                <label>Loyalty Score<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="txtLoyaltyScore" TextMode="Number" max="50" placeholder='Loyalty Score' min="0" CssClass="form-control" runat="server" step="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNoOfResources" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtLoyaltyScore"
                                    ErrorMessage="Loyalty Score can't be blank !" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Customer Type<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="ddlCustomerType" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0">Select Customer Type</asp:ListItem>
                                    <asp:ListItem Value="1">BUSINESS</asp:ListItem>
                                    <asp:ListItem Value="2">CENTRAL GOVT</asp:ListItem>
                                    <asp:ListItem Value="3">INDIVIDUAL</asp:ListItem>
                                    <asp:ListItem Value="4">PUBLIC INSTITUTION</asp:ListItem>
                                    <asp:ListItem Value="5">SERVICE</asp:ListItem>
                                    <asp:ListItem Value="6">STATE GOVT</asp:ListItem>

                                </asp:DropDownList>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRManager" runat="server" ControlToValidate="ddlCustomerType" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Customer Type !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-lg-6">
                                <label>Avg Revenue Score<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="txtAvgRevenueScore" runat="server" value="0" CssClass="form-control" MaxLength="4" placeholder="Connection Length in years"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtAvgRevenueScore"
                                    ErrorMessage="Avg Revenue Score can't be blank !" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtAvgRevenueScore"
                                    ValidationExpression="[0-9.]*$" ErrorMessage="Invalid Avg Revenue Score !" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Avg Monthly Billing<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="txtAvgMonthlyBilling" runat="server" value="0" CssClass="form-control" MaxLength="4" placeholder="Avg Monthly Billing"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtAvgMonthlyBilling"
                                    ErrorMessage="Avg Monthly Billing can't be blank !" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtAvgMonthlyBilling"
                                    ValidationExpression="[0-9.]*$" ErrorMessage="Invalid Avg Monthly Billing !" />
                            </div>
                            <div class="col-lg-6">
                                <label>Connection Type<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="ddlConnectionType" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0">Select Connection Type</asp:ListItem>
                                    <asp:ListItem Value="1">Emergency / Hot Line</asp:ListItem>
                                    <asp:ListItem Value="2">Government</asp:ListItem>
                                    <asp:ListItem Value="3">Private</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlConnectionType" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Connection Type !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>CustomerCategory<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="ddlCustomerCategory" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0">Select Customer Category</asp:ListItem>
                                    <asp:ListItem Value="1">CIP</asp:ListItem>
                                    <asp:ListItem Value="2">VIP</asp:ListItem>
                                    <asp:ListItem Value="3">VVIP</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRole" runat="server" ControlToValidate="ddlCustomerCategory" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select CustomerCategory !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-lg-6">
                                <label>Connection Activation Date<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="txtConnectionActivationDate" runat="server" CssClass="form-control" TextMode="Date" onkeypress="return false;"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtConnectionActivationDate"
                                    ErrorMessage="Connection Activation Date can't be blank !" />
                            </div>


                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Fixed Line<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="ddlFixedLine" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlFixedLine_SelectedIndexChanged" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0">Select Fixed Line Yes Or No</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="2">No</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlFixedLine" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Yes or No !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-lg-6">
                                <label>BB<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="ddlBB" AppendDataBoundItems="true" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlBB_SelectedIndexChanged" runat="server">
                                    <asp:ListItem Value="0">Select BB Yes Or No</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="2">No</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlBB" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Yes or No !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Mobile<span style="color: red;"> *</span></label>
                                <asp:DropDownList ID="ddlMobile" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlMobile_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0">Select Mobile Yes Or No</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="2">No</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlMobile" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="Please select Yes or No !" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-lg-6">
                                <label>Security Deposit Amt<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="txtSecurityDepositAmt" runat="server" value="0" CssClass="form-control" MaxLength="4" placeholder="Security Deposit Amt"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtSecurityDepositAmt"
                                    ErrorMessage="Security Deposit Amt can't be blank !" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtSecurityDepositAmt"
                                    ValidationExpression="[0-9.]*$" ErrorMessage="Invalid Security Deposit Amt !" />
                            </div>

                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Credit Limit<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="txtCreditLimit" runat="server" value="0" CssClass="form-control" MaxLength="4" placeholder="Credit Limit"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtCreditLimit"
                                    ErrorMessage="Credit Limit can't be blank !" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtCreditLimit"
                                    ValidationExpression="[0-9.]*$" ErrorMessage="Invalid Credit Limit !" />
                            </div>
                            <div class="col-lg-6">
                                <label>Defaults Or Year<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="txtDefaultsOrYear" runat="server" value="0" CssClass="form-control" MaxLength="4" placeholder="Credit Limit"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtDefaultsOrYear"
                                    ErrorMessage="Defaults Or Year can't be blank !" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtDefaultsOrYear"
                                    ValidationExpression="[0-9.]*$" ErrorMessage="Invalid Defaults Or Year !" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                                <label>Last Payment Date<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="txtLastPaymentDate" runat="server" CssClass="form-control" TextMode="Date" onkeypress="return false;"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtLastPaymentDate"
                                    ErrorMessage="Last Payment Date can't be blank !" />
                            </div>
                            <div class="col-lg-6">
                                <label>Connection Length<span style="color: red;"> *</span></label>
                                <asp:TextBox ID="txtConnectionLength" runat="server" value="0" CssClass="form-control" MaxLength="4" placeholder="Connection Length in years"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtConnectionLength"
                                    ErrorMessage="Experience can't be blank !" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" SetFocusOnError="true" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtConnectionLength"
                                    ValidationExpression="[0-9.]*$" ErrorMessage="Invalid Connection Length !" />
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
