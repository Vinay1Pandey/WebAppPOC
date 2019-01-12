<%@ Page Title="BaseData" Language="C#" EnableEventValidation="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BaseData.aspx.cs" Inherits="BSNL.BaseData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">Base Data Details</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">

                <div class="panel-heading">
                    Base Data
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">
                    <div class="dataTable_wrapper table-responsive" style="overflow-y: scroll; height: 600px">
                        <asp:GridView ID="gvBaseData" runat="server" DataKeyNames="CustomerID" OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
                            CssClass="table table-striped table-bordered table-hover" AllowPaging="True" OnRowEditing="edit" ShowFooter="false" AllowSorting="true" AutoGenerateColumns="False"
                            OnRowDeleting="delete"
                            OnRowCancelingEdit="canceledit"
                            OnRowUpdating="update" EmptyDataText="No records to show" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="CustomerID" ReadOnly="true" HeaderText="Customer ID" />
                                <asp:BoundField DataField="CustomerName" ReadOnly="true" HeaderText="Customer Name" />
                                <asp:BoundField DataField="CustomerType" ReadOnly="true" HeaderText="Customer Type" />
                                <asp:BoundField DataField="ConnectionActivationDate" ReadOnly="true" HeaderText="Connection Activation Date" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="ConnectionLength" ReadOnly="true" HeaderText="Aconnection Length" />
                                <asp:BoundField DataField="LoyaltyScore" ReadOnly="true" HeaderText="Loyalty Score" />
                                <asp:BoundField DataField="AvgRevenueScore" ReadOnly="true" HeaderText="Avg Revenue Score" />
                                <asp:BoundField DataField="AvgMonthlyBilling" ReadOnly="true" HeaderText="Avg Monthly Billing" />
                                <asp:BoundField DataField="CustomerCategory" ReadOnly="true" HeaderText="Customer Category" />
                                <asp:BoundField DataField="ConnectionType" ReadOnly="true" HeaderText="Connection Type" />
                                <asp:BoundField DataField="FixedLine" ReadOnly="true" HeaderText="Fixed Line" />
                                <asp:BoundField DataField="BB" ReadOnly="true" HeaderText="Broadband" />
                                <asp:BoundField DataField="Mobile" ReadOnly="true" HeaderText="Mobile" />
                                <asp:BoundField DataField="SecurityDepositAmt" ReadOnly="true" HeaderText="Security Deposits" />
                                <asp:BoundField DataField="CreditLimit" ReadOnly="true" HeaderText="Credit Limit" />
                                <asp:BoundField DataField="DefaultsOrYear" ReadOnly="true" HeaderText="Defaults/Year" />
                                <asp:BoundField DataField="LastPaymentDate" ReadOnly="true" HeaderText="Last Payment Date" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="ContactEmail" HeaderText="Contact Email" />

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ButtonEdit" runat="server" CssClass="center-block" ImageUrl="~/Images/22.png" CommandName="Edit" CausesValidation="false" formnovalidate />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Images/yes.png" Width="25px" Height="25px" ID="ButtonUpdate" runat="server" CommandName="Update" CausesValidation="false" formnovalidate />
                                        <asp:ImageButton ImageUrl="~/Images/cross-red.png" Width="25px" Height="25px" ID="ButtonCancel" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" formnovalidate />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/images/trash.png" HeaderText="" />--%>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="DeleteButton" runat="server" CssClass="center-block" ImageUrl="~/Images/11.png"
                                            CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this Account?');"
                                            AlternateText="Delete" CausesValidation="false" formnovalidate />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>


                            <PagerSettings Mode="NumericFirstLast" NextPageImageUrl="~/Images/nextPage.png" PageButtonCount="5" />

                        </asp:GridView>
                    </div>
                    <!-- /.table-responsive -->
                    <asp:Button ID="btnAddNewRow" runat="server" CssClass="btn btn-success pull-right" Text="Add More" PostBackUrl="~/AddBaseData.aspx" />
                </div>
            </div>
            <!-- /.panel-body -->
        </div>
        <!-- /.panel -->
    </div>
</asp:Content>
